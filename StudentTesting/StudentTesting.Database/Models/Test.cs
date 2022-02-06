using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentTesting.Database.Models
{
    public class Test
    {
        [Key]
        public int Id { get; set; }

        [Column]
        [StringLength(100)]
        [Required(AllowEmptyStrings = false)]
        public string Title { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(AllowEmptyStrings = true)]
        public string Description { get; set; }

        [ForeignKey("User")]
        public int IdCreator { get; set; }
        public User Creator { get; set; }

        public ICollection<Group> AllowGroups { get; set; }
        public ICollection<Attachment> Attachments { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}
