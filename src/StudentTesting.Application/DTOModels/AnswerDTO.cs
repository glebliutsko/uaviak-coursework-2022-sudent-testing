using StudentTesting.Application.Utils;
using StudentTesting.Database.Models;
using System;

namespace StudentTesting.Application.DTOModels
{
    public class AnswerDTO : OnPropertyChangeBase, ICloneable
    {
        #region Id
        private int? _id;
        public int? Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }
        #endregion

        #region Content
        private string _content;
        public string Content
        {
            get => _content;
            set => SetProperty(ref _content, value);
        }
        #endregion

        #region IsCorrect
        private bool _isCorrect;
        public bool IsCorrect
        {
            get => _isCorrect;
            set => SetProperty(ref _isCorrect, value);
        }
        #endregion

        // Нужен при прохождении теста студентом.
        // TODO: В иделале бы вынести в отдельную сущность, но мне насрать.
        #region IsSelected
        private bool _isSelected = false;
        public bool IsSelected
        {
            get => _isSelected;
            set => SetProperty(ref _isSelected, value);
        }
        #endregion

        public object Clone()
        {
            return new AnswerDTO
            {
                Id = Id,
                Content = Content,
                IsCorrect = IsCorrect
            };
        }

        public static AnswerDTO FromDb(Answer answer)
        {
            return new AnswerDTO
            {
                Id = answer.Id,
                Content = answer.Content,
                IsCorrect = answer.IsCorrect
            };
        }
    }
}
