using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentTesting.Database.Models
{
    public class Attachment
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "NVARCHAR(100)")]
        [Required(AllowEmptyStrings = false)]
        public string Title { get; set; }

        [Column(TypeName = "NVARCHAR(100)")]
        [Required(AllowEmptyStrings = false)]
        public string Mime { get; set; }
        public byte[] File { get; set; }

        public ICollection<Test> Tests { get; set; }
        public ICollection<Answer> Answers { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}
