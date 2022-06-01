using Microsoft.EntityFrameworkCore;
using StudentTesting.Application.Commands.Sync;
using StudentTesting.Application.Database;
using StudentTesting.Application.DTOModels;
using StudentTesting.Application.Utils;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using DbModels = StudentTesting.Database.Models;

namespace StudentTesting.Application.ViewModels.Test
{
    public class TestStudentViewModel : OnPropertyChangeBase, IDataVisualizationViewModel, IRequestCloseViewModel
    {
        public event EventHandler OnRequestClose;
        private DbModels.Test _testDb;
        private readonly DbModels.User _user;

        public TestStudentViewModel(DbModels.Test test, DbModels.User user)
        {
            PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(SelectedIndexQuestion))
                    SelectedQuestion = SelectedIndexQuestion <= -1 ? null : Test.Questions[SelectedIndexQuestion];

                if (e.PropertyName == nameof(SelectedQuestion))
                    SelectedIndexQuestion = Test.Questions.IndexOf(SelectedQuestion);
            };

            _testDb = test;
            _user = user;
            PreviousQuestionCommand = new RelayCommand(x => GoRelativeCurrent(-1), x => CanGoRelative(-1));
            NextQuestionCommand = new RelayCommand(x => GoRelativeCurrent(1), x => CanGoRelative(1));
            DoneCommand = new RelayCommand(x => Done());
        }

        #region Propery
        #region Test
        private TestDTO _test;
        public TestDTO Test
        {
            get => _test;
            set => SetProperty(ref _test, value);
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
        public ICommand DoneCommand { get; }
        #endregion

        public void UpdateData()
        {
            _testDb = DbContextKeeper.Saved.Tests
                .Include(x => x.Questions)
                .ThenInclude(x => x.Answers)
                .FirstOrDefault(x => x.Id == _testDb.Id);

            Test = TestDTO.FromDb(_testDb);

            // TODO: Просто SelectedIndexQuestion = 0 не работает, ну и поэтому так.
            SelectedIndexQuestion = 1;
            Task.Run(() => { Task.Delay(100); SelectedIndexQuestion = 0; });
        }

        private void GoRelativeCurrent(int offset)
        {
            if (CanGoRelative(offset))
                SelectedIndexQuestion += offset;
        }

        private bool CanGoRelative(int offset)
        {
            var newIndex = SelectedIndexQuestion + offset;
            return newIndex >= 0 && newIndex < Test.Questions.Count;
        }

        private void Done()
        {
            if (!Test.Questions.All(q => q.Answers.Any(a => a.IsSelected)))
            {
                MessageBox.Show("Необходимо ответить на все вопросы.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            int score = 0;
            foreach (var question in Test.Questions)
            {
                bool result = question.Answers.All(x => x.IsCorrect == x.IsSelected);
                score += result ? question.Score : 0;
            }

            OnRequestClose?.Invoke(this, EventArgs.Empty);

            var attemt = new DbModels.Attempt
            {
                TestId = (int)Test.Id,
                StudentId = _user.Id,
                Score = score
            };
            DbContextKeeper.Saved.Attempts.Add(attemt);
            DbContextKeeper.Saved.SaveChanges();

            int allScore = Test.Questions.Sum(x => x.Score);
            MessageBox.Show($"Вы прошли тест на {score}/{allScore}", "Результат", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}