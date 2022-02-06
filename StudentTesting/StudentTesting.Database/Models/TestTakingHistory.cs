using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentTesting.Database.Models
{
    public class TestTakingHistory
    {
        [Key]
        public int Id { get; set; }
        public int Score { get; set; }

        [ForeignKey("Test")]
        public int IdTest { get; set; }
        public Test Test { get; set; }

        [ForeignKey("User")]
        public int IsUser { get; set; }
        public User User { get; set; }
    }
}
