using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Win32;
using StudentTesting.Application.Commands.Sync;
using StudentTesting.Application.Database;
using StudentTesting.Application.DTOModels;
using StudentTesting.Application.Services;
using StudentTesting.Application.Services.ExcelReport;
using StudentTesting.Application.Utils;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using DbModel = StudentTesting.Database.Models;

namespace StudentTesting.Application.ViewModels.Test
{
    public class TestViewModel : OnPropertyChangeBase, IDataVisualizationViewModel
    {
        public event Action TestChanged;
        private DbModel.Test _test;

        public TestViewModel(DbModel.Test test)
        {
            PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(SelectedIndexQuestion))
                    SelectedQuestion = SelectedIndexQuestion <= -1 ? null : Test.Questions[SelectedIndexQuestion];

                if (e.PropertyName == nameof(SelectedQuestion))
                    SelectedIndexQuestion = Test.Questions.IndexOf(SelectedQuestion);
            };

            _test = test;

            PreviousQuestionCommand = new RelayCommand(x => GoRelativeCurrent(-1), x => CanGoRelative(-1));
            NextQuestionCommand = new RelayCommand(x => GoRelativeCurrent(1), x => CanGoRelative(1));
            AddQuestionCommand = new RelayCommand(x => AddQuestion());
            RemoveQuestionCommand = new RelayCommand(x => RemoveQuestion());
            SaveCommand = new RelayCommand(x => Save());
            AddAnswerCommand = new RelayCommand(x => AddAnswer());
            RemoveAnswerCommand = new RelayCommand(x => RemoveAnswer((AnswerDTO)x));
            UndoCommand = new RelayCommand(x => Undo());
            ReportListDebtorsCommand = new RelayCommand(x => ReportListDebtors());
        }

        #region Property
        #region Test
        private TestDTO _testDTO;
        public TestDTO Test
        {
            get => _testDTO;
            set => SetProperty(ref _testDTO, value);
        }
        #endregion

        #region SelectedIndexQuestion
        private int _selectedIndexQuestion;
        public int SelectedIndexQuestion
        {
            get => _selectedIndexQuestion;
            set => SetProperty(ref _selectedIndexQuestion, value);
        }
        #endregion

        #region SelectedQuestion
        private QuestionDTO _selectedQuestion;
        public QuestionDTO SelectedQuestion
        {
            get => _selectedQuestion;
            private set => SetProperty(ref _selectedQuestion, value);
        }
        #endregion
        #endregion

        #region Command
        public ICommand PreviousQuestionCommand { get; }
        public ICommand NextQuestionCommand { get; }
        public ICommand AddQuestionCommand { get; }
        public ICommand RemoveQuestionCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand AddAnswerCommand { get; }
        public ICommand RemoveAnswerCommand { get; }
        public ICommand UndoCommand { get; }
        public ICommand ReportListDebtorsCommand { get; }
        #endregion

        private void GoRelativeCurrent(int offset)
        {
            if (CanGoRelative(offset))
                SelectedIndexQuestion = SelectedIndexQuestion + offset;
        }

        private bool CanGoRelative(int offset)
        {
            var newIndex = SelectedIndexQuestion + offset;
            return newIndex >= 0 && newIndex < Test.Questions.Count;
        }

        private void AddQuestion()
        {
            var newQuestion = new QuestionDTO { Score = 1 };
            Test.Questions.Add(newQuestion);
            SelectedQuestion = newQuestion;
        }

        private void RemoveQuestion()
        {
            var indexOldElement = SelectedIndexQuestion;

            Test.Questions.Remove(SelectedQuestion);
            if (indexOldElement - 1 == -1 && Test.Questions.Count != 0)
                SelectedIndexQuestion = 0;
            else
                SelectedIndexQuestion = indexOldElement - 1;
        }

        private void AddAnswer()
        {
            if (SelectedQuestion == null)
                return;

            if (SelectedQuestion.Answers == null)
                SelectedQuestion.Answers = new ObservableCollection<AnswerDTO>();

            SelectedQuestion.Answers.Add(new AnswerDTO { IsCorrect = SelectedQuestion.Answers.Count == 0});
        }

        private void RemoveAnswer(AnswerDTO answer)
        {
            SelectedQuestion.Answers.Remove(answer);

            if (answer.IsCorrect && SelectedQuestion.Answers.Count != 0)
                SelectedQuestion.Answers[0].IsCorrect = true;
        }

        private void ReportListDebtors()
        {
            var dialog = new SaveFileDialog
            {
                Filter = "Excel Workbook (*.xlsx)|*.xlsx"
            };
            if (dialog.ShowDialog() != true)
                return;

            ReportDebtors.GenerateReport(new FileInfo(dialog.FileName), _test);
        }

        private void Save()
        {
            try
            {
                TestSaver.SaveTest(Test);
                UpdateData();
                TestChanged?.Invoke();
            }
            catch (TestSaverError e)
            {
                MessageBox.Show(e.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Undo()
        {
            UpdateData();
        }

        public void UpdateData()
        {
            SelectedIndexQuestion = -1;

            _test = DbContextKeeper.Saved.Tests
               .Include(x => x.Questions)
               .ThenInclude(x => x.Answers)
               .AsNoTracking()
               .FirstOrDefault(x => x.Id == _test.Id);
            Test = TestDTO.FromDb(_test);
        }
    }
}
