using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentTesting.Database.Models
{
    public class QuestionAnswerHistory
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("TestTakingHistory")]
        public int IdTestTakingHistory { get; set; }
        public TestTakingHistory TestTakingHistory { get; set; }

        public ICollection<Answer> Answers { get; set; }
    }
}
