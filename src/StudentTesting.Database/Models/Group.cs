using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentTesting.Database.Models
{
    public class Group
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "NVARCHAR(30)")]
        [Required(AllowEmptyStrings = false)]
        public string Number { get; set; }

        public ICollection<Course> AvaibleCourses { get; set; }
        public ICollection<User> Students { get; set; }
    }
}
