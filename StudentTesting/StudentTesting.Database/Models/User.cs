using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentTesting.Database.Models
{
    public enum UserRole
    {
        STUDENT = 1,
        TEACHER = 2
    }

    public class User
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(100)]
        [Required(AllowEmptyStrings = false)]
        public string Login { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(64)]
        [Required(AllowEmptyStrings = false)]
        public string PasswordHash { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(100)]
        [Required(AllowEmptyStrings = false)]
        public string FullName { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(100)]
        [Required(AllowEmptyStrings = false)]
        public string DocumentNumber { get; set; }

        [Column(TypeName = "NVARCHAR(50)")]
        public UserRole Role { get; set; }

        [ForeignKey("Group")]
        public int? IdGroup { get; set; }
        public Group Group { get; set; }

        public ICollection<Question> Questions { get; set; }
    }
}
