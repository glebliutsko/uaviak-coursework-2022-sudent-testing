using StudentTesting.Application.Utils;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using DbModel = StudentTesting.Database.Models;

namespace StudentTesting.Application.DTOModels
{
    public class TestDTO : OnPropertyChangeBase, ICloneable
    {
        #region Id
        private int? _id;
        public int? Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }
        #endregion

        #region Title
        private string _titie;
        public string Title
        {
            get => _titie;
            set => SetProperty(ref _titie, value);
        }
        #endregion

        #region Description
        private string _description;
        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }
        #endregion

        #region Questions
        private ObservableCollection<QuestionDTO> _questions;
        public ObservableCollection<QuestionDTO> Questions
        {
            get => _questions;
            set => SetProperty(ref _questions, value);
        }
        #endregion

        public object Clone()
        {
            return new TestDTO
            {
                Id = Id,
                Title = Title,
                Description = Description,
                Questions = new ObservableCollection<QuestionDTO>(Questions.Select(x => (QuestionDTO)x.Clone()).ToArray())
            };
        }

        public static TestDTO FromDb(DbModel.Test test)
        {
            return new TestDTO
            {
                Id = test.Id,
                Title = test.Title,
                Description = test.Description,
                Questions = new ObservableCollection<QuestionDTO>(test.Questions.Select(x => QuestionDTO.FromDb(x)).ToArray())
            };
        }
    }
}
