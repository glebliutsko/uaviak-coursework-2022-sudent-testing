﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentTesting.Database.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Column(TypeName = "NVARCHAR(50)")]
        public string Title { get; set; }

        [Column(TypeName = "NTEXT")]
        public string Description { get; set; }

        public byte[] Picture { get; set; }

        [ForeignKey("OwnerCource")]
        public int OwnerCourceId { get; set; }
        public User OwnerCource { get; set; }

        public ICollection<Group> AvaibleForPassing { get; set; }
        public ICollection<Test> Tests { get; set; }
    }
}
