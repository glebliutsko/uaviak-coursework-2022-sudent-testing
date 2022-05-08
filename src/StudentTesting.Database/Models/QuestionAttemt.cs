using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentTesting.Database.Models
{
    public class QuestionAttemt
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Attempt")]
        public int AttemptId { get; set; }
        public Attempt Attempt { get; set; }

        [ForeignKey("ToQuestion")]
        public int ToQuestionId { get; set; }
        public Question ToQuestion { get; set; }

        public ICollection<Answer> Answers { get; set; }
    }
}
