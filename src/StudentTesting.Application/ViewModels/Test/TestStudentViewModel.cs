using Microsoft.EntityFrameworkCore;
using StudentTesting.Application.Commands.Sync;
using StudentTesting.Application.Database;
using StudentTesting.Application.DTOModels;
using StudentTesting.Application.Utils;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using DbModels = StudentTesting.Database.Models;

namespace StudentTesting.Application.ViewModels.Test
{
    public class TestStudentViewModel : OnPropertyChangeBase, IDataVisualizationViewModel
    {
        private DbModels.Test _testDb;
        public TestStudentViewModel(DbModels.Test test)
        {
            PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(SelectedIndexQuestion))
                    SelectedQuestion = SelectedIndexQuestion <= -1 ? null : Test.Questions[SelectedIndexQuestion];

                if (e.PropertyName == nameof(SelectedQuestion))
                    SelectedIndexQuestion = Test.Questions.IndexOf(SelectedQuestion);
            };
            _testDb = test;
            PreviousQuestionCommand = new RelayCommand(x => GoRelativeCurrent(-1), x => CanGoRelative(-1));
            NextQuestionCommand = new RelayCommand(x => GoRelativeCurrent(1), x => CanGoRelative(1));
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
    }
}