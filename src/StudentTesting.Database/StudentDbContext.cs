using Microsoft.EntityFrameworkCore;
using StudentTesting.Database.Models;

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
        public DbSet<QuestionAnswerHistory> QuestionAnswerHistory { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<TestTakingHistory> TestTakingHistory { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        #endregion

        #region Configuration
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // m2m Attachments and Questions = AttachmentsQuestion
            modelBuilder.Entity<Question>()
                .HasMany(x => x.Attachments)
                .WithMany(x => x.Questions)
                .UsingEntity(x => x.ToTable("AttachmentsQuestion"));

            // m2m Attachments and Tests = AttachmentsTest
            modelBuilder.Entity<Test>()
                .HasMany(x => x.Attachments)
                .WithMany(x => x.Tests)
                .UsingEntity(x => x.ToTable("AttachmentsTest"));

            // m2m Attachments and Answers = AttachmentsAnswer
            modelBuilder.Entity<Answer>()
                .HasMany(x => x.Attachments)
                .WithMany(x => x.Answers)
                .UsingEntity(x => x.ToTable("AttachmentsAnswer"));

            // N:1 User and TestTakingHistory
            modelBuilder.Entity<User>()
                .HasMany(x => x.TestTakingHistories)
                .WithOne(x => x.User)
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
