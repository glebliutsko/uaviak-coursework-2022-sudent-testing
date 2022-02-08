using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentTesting.Database.Models
{
    public class Answer
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(AllowEmptyStrings = true)]
        public string Content { get; set; }

        public bool IsCorrect { get; set; }

        [ForeignKey("Question")]
        public int? IdQuestion { get; set; }
        public Question Question { get; set; }

        public ICollection<Attachment> Attachments { get; set; }

        public ICollection<QuestionAnswerHistory> TestTakingHistories { get; set; }
    }
}
