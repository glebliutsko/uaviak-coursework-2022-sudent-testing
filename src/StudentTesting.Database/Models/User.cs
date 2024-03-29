﻿using System.Collections.Generic;
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
        public string PasswordHash { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(50)]
        public string Salt { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(100)]
        [Required(AllowEmptyStrings = false)]
        public string FullName { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(100)]
        [Required(AllowEmptyStrings = false)]
        public string DocumentNumber { get; set; }

        [Column(TypeName = "NVARCHAR(50)")]
        [Required]
        public UserRole? Role { get; set; }

        [ForeignKey("Group")]
        public int? GroupId { get; set; }
        public Group Group { get; set; }

        public byte[] UserPic { get; set; }

        public ICollection<Attempt> Attempts { get; set; }
        public ICollection<Course> AvaibleCourseForEdit { get; set; }
    }
}
