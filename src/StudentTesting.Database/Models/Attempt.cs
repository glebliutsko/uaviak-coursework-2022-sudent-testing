using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentTesting.Database.Models
{
    public class Attempt
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Test")]
        public int TestId { get; set; }
        public Test Test { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public User Student { get; set; }

        public int Score { get; set; }
    }
}
