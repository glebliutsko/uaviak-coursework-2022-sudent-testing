using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentTesting.Database.Models
{
    public class Answer
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "NTEXT")]
        public string Content { get; set; }

        public bool IsCorrect { get; set; }

        [ForeignKey("Question")]
        public int? QuestionId { get; set; }
        public Question Question { get; set; }

        public ICollection<QuestionAttemt> QuestionAttemts { get; set; }
    }
}
