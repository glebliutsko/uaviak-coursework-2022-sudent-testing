using Microsoft.EntityFrameworkCore;
using StudentTesting.Database.Models;
using System.Collections.Generic;

namespace StudentTesting.Database
{
    public class StudentDbContext : DbContext
    {
        private readonly string _ip;
        private readonly string _user;
        private readonly string _password;
        private readonly string _database;
        private readonly bool _integratedSecurity;

        public StudentDbContext(string ip, string user, string password, string database)
        {
            _ip = ip;
            _user = user;
            _password = password;
            _database = database;
            _integratedSecurity = false;
        }

        public StudentDbContext(string ip, string database)
        {
            _ip = ip;
            _database = database;
            _integratedSecurity = true;
        }

        #region Tables
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionAttemt> QuestionAttemts { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Attempt> Attempts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        #endregion

        #region Configuration
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // m2m Attachments and Questions = AttachmentsQuestion
            modelBuilder.Entity<Question>()
                .HasMany(x => x.Attachments)
                .WithMany(x => x.Questions)
                .UsingEntity<Dictionary<string, object>>(
                    "AttachmentsQuestion",
                    x => x.HasOne<Attachment>().WithMany().OnDelete(DeleteBehavior.NoAction),
                    x => x.HasOne<Question>().WithMany().OnDelete(DeleteBehavior.Cascade));

            // m2m Attachments and Tests = AttachmentsTest
            modelBuilder.Entity<Test>()
                .HasMany(x => x.Attachments)
                .WithMany(x => x.Tests)
                .UsingEntity<Dictionary<string, object>>(
                   "AttachmentsTest",
                   x => x.HasOne<Attachment>().WithMany().OnDelete(DeleteBehavior.NoAction),
                   x => x.HasOne<Test>().WithMany().OnDelete(DeleteBehavior.Cascade));

            // m2m Attachments and Answers = AttachmentsAnswer
            modelBuilder.Entity<Answer>()
                .HasMany(x => x.Attachments)
                .WithMany(x => x.Answers)
                .UsingEntity<Dictionary<string, object>>(
                    "AttachmentsAnswer",
                    x => x.HasOne<Attachment>().WithMany().OnDelete(DeleteBehavior.NoAction),
                    x => x.HasOne<Answer>().WithMany().OnDelete(DeleteBehavior.Cascade));

            // m2m Courses and Groups = GroupsEditorsCourse
            modelBuilder.Entity<Course>()
                .HasMany(x => x.AvaibleForPassing)
                .WithMany(x => x.AvaibleCourses)
                .UsingEntity(x => x.ToTable("GroupsEditorsCourse"));

            // N:1 User and TestTakingHistory
            modelBuilder.Entity<User>()
                .HasMany(x => x.Attempts)
                .WithOne(x => x.Student)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<QuestionAttemt>()
                .HasOne(x => x.ToQuestion)
                .WithMany(x => x.Attempts)
                .OnDelete(DeleteBehavior.NoAction);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_integratedSecurity)
                optionsBuilder.UseSqlServer(@$"Server={_ip};Database={_database};Integrated Security=True");
            else
                optionsBuilder.UseSqlServer(@$"Server={_ip};Database={_database};User Id={_user};Password={_password}");
        }
        #endregion
    }
}
