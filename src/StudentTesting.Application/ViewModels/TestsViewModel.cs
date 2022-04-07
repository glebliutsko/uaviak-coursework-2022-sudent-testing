using StudentTesting.Application.Commands.Sync;
using StudentTesting.Database;
using StudentTesting.Database.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace StudentTesting.Application.ViewModels
{
    public class TestsViewModel : ViewModelBase
    {
        public TestsViewModel(StudentDbContext db) : base(db)
        {
            UpdateTests();

            AddNewTestCommand = new RelayCommand(x => AddNewTest());
        }

        #region Property
        #region Tests
        private ObservableCollection<Test> _tests;
        public ObservableCollection<Test> Tests
        {
            get => _tests;
            set => SetProperty(ref _tests, value);
        }
        #endregion

        #region SelectedTest
        private Test _selectedTest;
        public Test SelectedTest
        {
            get => _selectedTest;
            set
            {
                SetProperty(ref _selectedTest, value);
                if (value != null)
                    TestEditable = value;
            }
        }
        #endregion

        #region TestEditable
        private Test _testEditable;
        public Test TestEditable
        {
            get => _testEditable;
            set
            {
                SetProperty(ref _testEditable, value);

                InformationTestEditor = value == null
                    ? null
                    : new InformationTestEditorViewModel(_db, value);
            }
        }
        #endregion

        #region InformationTestEditor
        private InformationTestEditorViewModel _informationTestEditor;
        public InformationTestEditorViewModel InformationTestEditor
        {
            get => _informationTestEditor;
            set => SetProperty(ref _informationTestEditor, value);
        }
        #endregion
        #endregion

        #region Command
        public ICommand AddNewTestCommand { get; }
        #endregion
        private void UpdateTests()
        {
            Tests = new ObservableCollection<Test>(_db.Tests.ToList());
        }

        private void AddNewTest()
        {
            SelectedTest = null;
            TestEditable = new Test();
        }
    }
}
