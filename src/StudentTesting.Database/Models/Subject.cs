using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentTesting.Database.Models
{
    public class Subject
    {
        [Key]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Column(TypeName = "NVARCHAR(50)")]
        public string Title { get; set; }

        public byte[] Picture { get; set; }

        public ICollection<Test> Tests { get; set; }
    }
}
