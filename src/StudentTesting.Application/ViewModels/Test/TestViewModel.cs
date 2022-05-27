using StudentTesting.Application.Commands.Sync;
using StudentTesting.Application.Database;
using StudentTesting.Application.Utils;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using DbModel = StudentTesting.Database.Models;

namespace StudentTesting.Application.ViewModels.Test
{
    public class TestViewModel : OnPropertyChangeBase, IDataVisualizationViewModel
    {
        public TestViewModel(DbModel.Test test)
        {
            PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(SelectedIndexQuestion))
                    SelectedQuestion = SelectedIndexQuestion == -1 ? null : Questions[SelectedIndexQuestion];

                if (e.PropertyName == nameof(SelectedQuestion))
                    SelectedIndexQuestion = Questions.IndexOf(SelectedQuestion);
            };

            Test = test;

            PreviousQuestionCommand = new RelayCommand(x => GoRelativeCurrent(-1), x => CanGoRelative(-1));
            NextQuestionCommand = new RelayCommand(x => GoRelativeCurrent(1), x => CanGoRelative(1));
            AddQuestionCommand = new RelayCommand(x => AddQuestion());
            RemoveQuestionCommand = new RelayCommand(x => RemoveQuestion());
        }

        #region Property
        #region Questions
        private ObservableCollection<DbModel.Question> _questions;
        public ObservableCollection<DbModel.Question> Questions
        {
            get => _questions;
            set => SetProperty(ref _questions, value);
        }
        #endregion

        #region Test
        private DbModel.Test _test;
        public DbModel.Test Test
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
        private DbModel.Question _selectedQuestion;
        public DbModel.Question SelectedQuestion
        {
            get => _selectedQuestion;
            private set => SetProperty(ref _selectedQuestion, value);
        }
        #endregion
        #endregion

        #region Command
        public ICommand PreviousQuestionCommand { get; }
        public ICommand NextQuestionCommand { get; }
        public ICommand AddQuestionCommand { get;  }
        public ICommand RemoveQuestionCommand { get; }
        #endregion

        private void GoRelativeCurrent(int offset)
        {
            var newIndex = SelectedIndexQuestion + offset;
            if (CanGoRelative(newIndex))
                SelectedIndexQuestion = newIndex;
        }

        private bool CanGoRelative(int offset)
        {
            var newIndex = SelectedIndexQuestion + offset;
            return newIndex >= 0 && newIndex < Questions.Count;
        }

        private void AddQuestion()
        {
            var newQuestion = new DbModel.Question { Order = -1 };
            Questions.Add(newQuestion);
            SelectedQuestion = newQuestion;
        }

        private void RemoveQuestion()
        {
            var indexOldElement = SelectedIndexQuestion;

            Questions.Remove(SelectedQuestion);
            if (indexOldElement - 1 == -1 && Questions.Count != 0)
                SelectedIndexQuestion = 0;
            else
                SelectedIndexQuestion = indexOldElement - 1;
        }

        public void UpdateData()
        {
            Questions = new ObservableCollection<DbModel.Question>();
            Questions.Add(new DbModel.Question()
            {
                Score = 1,
                Type = DbModel.TypeQuestion.ONE_ANSWER,
                Content = "x^2 + 2x + 5 = 3\nx = ?"
            });

            Questions.Add(new DbModel.Question()
            {
                Score = 1,
                Type = DbModel.TypeQuestion.MULTIPLE_ANSWER,
                Content = "Test 2"
            });

            SelectedIndexQuestion = 0;
        }
    }
}
