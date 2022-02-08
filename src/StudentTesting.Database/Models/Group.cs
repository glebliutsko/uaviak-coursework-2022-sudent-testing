using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentTesting.Database.Models
{
    public class Group
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(30)]
        [Required(AllowEmptyStrings = false)]
        public string Number { get; set; }

        public ICollection<User> Students { get; set; }
        public ICollection<Test> AvailableTests { get; set; }
    }
}
