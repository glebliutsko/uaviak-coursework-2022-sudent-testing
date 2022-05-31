using StudentTesting.Application.Database;
using StudentTesting.Application.DTOModels;
using System;
using System.Linq;
using DbModel = StudentTesting.Database.Models;

namespace StudentTesting.Application.Services
{
    public static class TestSaver
    {
        private static DbModel.Answer ConvertAnswer(AnswerDTO answer, DbModel.Question question)
        {
            if (string.IsNullOrEmpty(answer.Content))
                throw new TestSaverError("Заполните все вопросы");

            DbModel.Answer answerDb;
            if (answer.Id == null)
            {
                answerDb = new DbModel.Answer();
                answerDb.Question = question;
                DbContextKeeper.Saved.Answers.Add(answerDb);
            }
            else
            {
                answerDb = DbContextKeeper.Saved.Answers.First(x => x.Id == answer.Id);
            }

            answerDb.Content = answer.Content;
            answerDb.IsCorrect = answer.IsCorrect;

            return answerDb;
        }

        private static DbModel.Question ConvertQuestion(QuestionDTO question, DbModel.Test test)
        {
            if (string.IsNullOrEmpty(question.Content))
                throw new TestSaverError("Введите вопрос.");

            DbModel.Question questionDb = null;
            if (question.Id == null)
            {
                questionDb = new DbModel.Question();
                questionDb.Test = test;
                DbContextKeeper.Saved.Questions.Add(questionDb);
            }
            else
            {
                questionDb = DbContextKeeper.Saved.Questions.First(x => x.Id == question.Id);
            }

            questionDb.Content = question.Content;
            questionDb.Order = -1;
            questionDb.Score = question.Score;

            return questionDb;
        }

        public static void SaveTest(TestDTO test)
        {
            // TODO: Вообще валидацию нужео проводить до всех действий, но мне насрать :).
            DbModel.Test testDb = null;
            if (test.Id == null)
            {
                testDb = new DbModel.Test();
            }
            else
                testDb = DbContextKeeper.Saved.Tests.First(x => x.Id == test.Id);

            testDb.Title = test.Title;
            testDb.Description = test.Description;

            var idsQuestion = test.Questions.Select(x => x.Id).Where(x => x != null).ToArray();
            var removedQuestion = DbContextKeeper.Saved.Questions.Where(x => !idsQuestion.Contains(x.Id) && x.Test == testDb).ToArray();
            DbContextKeeper.Saved.Questions.RemoveRange(removedQuestion);

            foreach (var question in test.Questions)
            {
                DbModel.Question questionDb = ConvertQuestion(question, testDb);

                var idsAnswer = question.Answers.Select(x => x.Id).Where(x => x != null).ToArray();
                var removedAnswer = DbContextKeeper.Saved.Answers.Where(x => !idsAnswer.Contains(x.Id) && x.Question == questionDb).ToArray();
                DbContextKeeper.Saved.Answers.RemoveRange(removedAnswer);

                foreach (var answer in question.Answers)
                {
                    DbModel.Answer answerDb = ConvertAnswer(answer, questionDb);
                }
            }

            DbContextKeeper.Saved.SaveChanges();
        }
    }

    [Serializable]
    internal class TestSaverError : Exception
    {
        public TestSaverError(string message) : base(message)
        { }
    }
}
