using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentTesting.Database.Models
{
    public class Test
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "NVARCHAR(100)")]
        [Required(AllowEmptyStrings = false)]
        public string Title { get; set; }

        [Column(TypeName = "NTEXT")]
        public string Description { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Course Course { get; set; }

        public ICollection<Question> Questions { get; set; }
        public ICollection<Attempt> Attempts { get; set; }
    }
}
