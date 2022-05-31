using StudentTesting.Application.Utils;
using StudentTesting.Database.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace StudentTesting.Application.DTOModels
{
    public class QuestionDTO : OnPropertyChangeBase, ICloneable
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

        #region Score
        private int _score;
        public int Score
        {
            get => _score;
            set => SetProperty(ref _score, value);
        }
        #endregion

        #region Answers
        private ObservableCollection<AnswerDTO> _answer;
        public ObservableCollection<AnswerDTO> Answers
        {
            get => _answer;
            set => SetProperty(ref _answer, value);
        }
        #endregion

        public object Clone()
        {
            return new QuestionDTO
            {
                Id = Id,
                Content = Content,
                Score = Score,
                Answers = new ObservableCollection<AnswerDTO>(Answers.Select(x => (AnswerDTO)x.Clone()).ToArray())
            };
        }

        public static QuestionDTO FromDb(Question question)
        {
            return new QuestionDTO
            {
                Id = question.Id,
                Content = question.Content,
                Score = question.Score,
                Answers = new ObservableCollection<AnswerDTO>(question.Answers.Select(x => AnswerDTO.FromDb(x)).ToArray())
            };
        }
    }
}
