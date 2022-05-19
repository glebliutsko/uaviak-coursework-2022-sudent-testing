﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentTesting.Database;

namespace StudentTesting.Database.Migrations
{
    [DbContext(typeof(StudentDbContext))]
    partial class StudentDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AnswerQuestionAttemt", b =>
                {
                    b.Property<int>("AnswersId")
                        .HasColumnType("int");

                    b.Property<int>("QuestionAttemtsId")
                        .HasColumnType("int");

                    b.HasKey("AnswersId", "QuestionAttemtsId");

                    b.HasIndex("QuestionAttemtsId");

                    b.ToTable("AnswerQuestionAttemt");
                });

            modelBuilder.Entity("CourseGroup", b =>
                {
                    b.Property<int>("AvaibleCoursesId")
                        .HasColumnType("int");

                    b.Property<int>("AvaibleForPassingId")
                        .HasColumnType("int");

                    b.HasKey("AvaibleCoursesId", "AvaibleForPassingId");

                    b.HasIndex("AvaibleForPassingId");

                    b.ToTable("GroupsEditorsCourse");
                });

            modelBuilder.Entity("StudentTesting.Database.Models.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasColumnType("NTEXT");

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("bit");

                    b.Property<int?>("QuestionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("StudentTesting.Database.Models.Attempt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("TestId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("TestId");

                    b.ToTable("Attempts");
                });

            modelBuilder.Entity("StudentTesting.Database.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("NTEXT");

                    b.Property<int>("OwnerCourceId")
                        .HasColumnType("int");

                    b.Property<byte[]>("Picture")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(50)");

                    b.HasKey("Id");

                    b.HasIndex("OwnerCourceId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("StudentTesting.Database.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(30)");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("StudentTesting.Database.Models.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasColumnType("NTEXT");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<int>("TestId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(50)");

                    b.HasKey("Id");

                    b.HasIndex("TestId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("StudentTesting.Database.Models.QuestionAttemt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AttemptId")
                        .HasColumnType("int");

                    b.Property<int>("ToQuestionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AttemptId");

                    b.HasIndex("ToQuestionId");

                    b.ToTable("QuestionAttemts");
                });

            modelBuilder.Entity("StudentTesting.Database.Models.Test", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("NTEXT");

                    b.Property<byte[]>("Picture")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(100)");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Tests");
                });

            modelBuilder.Entity("StudentTesting.Database.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DocumentNumber")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR(100)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR(100)");

                    b.Property<int?>("GroupId")
                        .HasColumnType("int");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR(100)");

                    b.Property<string>("PasswordHash")
                        .HasMaxLength(64)
                        .HasColumnType("NVARCHAR(64)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(50)");

                    b.Property<string>("Salt")
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR(50)");

                    b.Property<byte[]>("UserPic")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AnswerQuestionAttemt", b =>
                {
                    b.HasOne("StudentTesting.Database.Models.Answer", null)
                        .WithMany()
                        .HasForeignKey("AnswersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentTesting.Database.Models.QuestionAttemt", null)
                        .WithMany()
                        .HasForeignKey("QuestionAttemtsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CourseGroup", b =>
                {
                    b.HasOne("StudentTesting.Database.Models.Course", null)
                        .WithMany()
                        .HasForeignKey("AvaibleCoursesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentTesting.Database.Models.Group", null)
                        .WithMany()
                        .HasForeignKey("AvaibleForPassingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StudentTesting.Database.Models.Answer", b =>
                {
                    b.HasOne("StudentTesting.Database.Models.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("StudentTesting.Database.Models.Attempt", b =>
                {
                    b.HasOne("StudentTesting.Database.Models.User", "Student")
                        .WithMany("Attempts")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("StudentTesting.Database.Models.Test", "Test")
                        .WithMany()
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Test");
                });

            modelBuilder.Entity("StudentTesting.Database.Models.Course", b =>
                {
                    b.HasOne("StudentTesting.Database.Models.User", "OwnerCource")
                        .WithMany("AvaibleCourseForEdit")
                        .HasForeignKey("OwnerCourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OwnerCource");
                });

            modelBuilder.Entity("StudentTesting.Database.Models.Question", b =>
                {
                    b.HasOne("StudentTesting.Database.Models.Test", "Test")
                        .WithMany("Questions")
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Test");
                });

            modelBuilder.Entity("StudentTesting.Database.Models.QuestionAttemt", b =>
                {
                    b.HasOne("StudentTesting.Database.Models.Attempt", "Attempt")
                        .WithMany("StudentAnswers")
                        .HasForeignKey("AttemptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentTesting.Database.Models.Question", "ToQuestion")
                        .WithMany("Attempts")
                        .HasForeignKey("ToQuestionId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Attempt");

                    b.Navigation("ToQuestion");
                });

            modelBuilder.Entity("StudentTesting.Database.Models.Test", b =>
                {
                    b.HasOne("StudentTesting.Database.Models.Course", "Course")
                        .WithMany("Tests")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("StudentTesting.Database.Models.User", b =>
                {
                    b.HasOne("StudentTesting.Database.Models.Group", "Group")
                        .WithMany("Students")
                        .HasForeignKey("GroupId");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("StudentTesting.Database.Models.Attempt", b =>
                {
                    b.Navigation("StudentAnswers");
                });

            modelBuilder.Entity("StudentTesting.Database.Models.Course", b =>
                {
                    b.Navigation("Tests");
                });

            modelBuilder.Entity("StudentTesting.Database.Models.Group", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("StudentTesting.Database.Models.Question", b =>
                {
                    b.Navigation("Answers");

                    b.Navigation("Attempts");
                });

            modelBuilder.Entity("StudentTesting.Database.Models.Test", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("StudentTesting.Database.Models.User", b =>
                {
                    b.Navigation("Attempts");

                    b.Navigation("AvaibleCourseForEdit");
                });
#pragma warning restore 612, 618
        }
    }
}
