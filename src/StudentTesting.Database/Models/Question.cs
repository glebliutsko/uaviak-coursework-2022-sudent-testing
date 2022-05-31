using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentTesting.Database.Models
{
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

        public ICollection<Answer> Answers { get; set; }
    }
}
