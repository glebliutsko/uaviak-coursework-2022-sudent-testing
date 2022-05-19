using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentTesting.Database.Models
{
    public enum TypeQuestion
    {
        ONE_ANSWER = 1,
        MULTIPLE_ANSWER = 2,
        OPEN_ANSWER = 3
    }

    public class Question
    {
        [Key]
        public int Id { get; set; }
        public int Order { get; set; }

        [Column(TypeName = "NTEXT")]
        public string Content { get; set; }
        public int Score { get; set; }

        [ForeignKey("Test")]
        public int TestId { get; set; }
        public Test Test { get; set; }

        [Column(TypeName = "NVARCHAR(50)")]
        public TypeQuestion Type { get; set; }

        public ICollection<Answer> Answers { get; set; }
        public ICollection<Attachment> Attachments { get; set; }
        public ICollection<QuestionAttemt> Attempts { get; set; }
    }
}
