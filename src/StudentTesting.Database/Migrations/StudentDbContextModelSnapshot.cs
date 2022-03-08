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

            modelBuilder.Entity("AnswerAttachment", b =>
                {
                    b.Property<int>("AnswersId")
                        .HasColumnType("int");

                    b.Property<int>("AttachmentsId")
                        .HasColumnType("int");

                    b.HasKey("AnswersId", "AttachmentsId");

                    b.HasIndex("AttachmentsId");

                    b.ToTable("AttachmentsAnswer");
                });

            modelBuilder.Entity("AnswerQuestionAnswerHistory", b =>
                {
                    b.Property<int>("AnswersId")
                        .HasColumnType("int");

                    b.Property<int>("TestTakingHistoriesId")
                        .HasColumnType("int");

                    b.HasKey("AnswersId", "TestTakingHistoriesId");

                    b.HasIndex("TestTakingHistoriesId");

                    b.ToTable("AnswerQuestionAnswerHistory");
                });

            modelBuilder.Entity("AttachmentQuestion", b =>
                {
                    b.Property<int>("AttachmentsId")
                        .HasColumnType("int");

                    b.Property<int>("QuestionsId")
                        .HasColumnType("int");

                    b.HasKey("AttachmentsId", "QuestionsId");

                    b.HasIndex("QuestionsId");

                    b.ToTable("AttachmentsQuestion");
                });

            modelBuilder.Entity("AttachmentTest", b =>
                {
                    b.Property<int>("AttachmentsId")
                        .HasColumnType("int");

                    b.Property<int>("TestsId")
                        .HasColumnType("int");

                    b.HasKey("AttachmentsId", "TestsId");

                    b.HasIndex("TestsId");

                    b.ToTable("AttachmentsTest");
                });

            modelBuilder.Entity("GroupTest", b =>
                {
                    b.Property<int>("AllowGroupsId")
                        .HasColumnType("int");

                    b.Property<int>("AvailableTestsId")
                        .HasColumnType("int");

                    b.HasKey("AllowGroupsId", "AvailableTestsId");

                    b.HasIndex("AvailableTestsId");

                    b.ToTable("GroupTest");
                });

            modelBuilder.Entity("StudentTesting.Database.Models.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("IdQuestion")
                        .HasColumnType("int");

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("IdQuestion");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("StudentTesting.Database.Models.Attachment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("File")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Mime")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR(100)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR(100)");

                    b.HasKey("Id");

                    b.ToTable("Attachments");
                });

            modelBuilder.Entity("StudentTesting.Database.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(30)
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
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("IdTest")
                        .HasColumnType("int");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(50)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdTest");

                    b.HasIndex("UserId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("StudentTesting.Database.Models.QuestionAnswerHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdTestTakingHistory")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdTestTakingHistory");

                    b.ToTable("QuestionAnswerHistory");
                });

            modelBuilder.Entity("StudentTesting.Database.Models.Test", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CreatorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("IdCreator")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.ToTable("Tests");
                });

            modelBuilder.Entity("StudentTesting.Database.Models.TestTakingHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdTest")
                        .HasColumnType("int");

                    b.Property<int>("IsUser")
                        .HasColumnType("int");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdTest");

                    b.HasIndex("IsUser");

                    b.ToTable("TestTakingHistory");
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

                    b.Property<int?>("IdGroup")
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

                    b.HasIndex("IdGroup");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AnswerAttachment", b =>
                {
                    b.HasOne("StudentTesting.Database.Models.Answer", null)
                        .WithMany()
                        .HasForeignKey("AnswersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentTesting.Database.Models.Attachment", null)
                        .WithMany()
                        .HasForeignKey("AttachmentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AnswerQuestionAnswerHistory", b =>
                {
                    b.HasOne("StudentTesting.Database.Models.Answer", null)
                        .WithMany()
                        .HasForeignKey("AnswersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentTesting.Database.Models.QuestionAnswerHistory", null)
                        .WithMany()
                        .HasForeignKey("TestTakingHistoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AttachmentQuestion", b =>
                {
                    b.HasOne("StudentTesting.Database.Models.Attachment", null)
                        .WithMany()
                        .HasForeignKey("AttachmentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentTesting.Database.Models.Question", null)
                        .WithMany()
                        .HasForeignKey("QuestionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AttachmentTest", b =>
                {
                    b.HasOne("StudentTesting.Database.Models.Attachment", null)
                        .WithMany()
                        .HasForeignKey("AttachmentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentTesting.Database.Models.Test", null)
                        .WithMany()
                        .HasForeignKey("TestsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GroupTest", b =>
                {
                    b.HasOne("StudentTesting.Database.Models.Group", null)
                        .WithMany()
                        .HasForeignKey("AllowGroupsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentTesting.Database.Models.Test", null)
                        .WithMany()
                        .HasForeignKey("AvailableTestsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StudentTesting.Database.Models.Answer", b =>
                {
                    b.HasOne("StudentTesting.Database.Models.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("IdQuestion");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("StudentTesting.Database.Models.Question", b =>
                {
                    b.HasOne("StudentTesting.Database.Models.Test", "Test")
                        .WithMany("Questions")
                        .HasForeignKey("IdTest")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentTesting.Database.Models.User", null)
                        .WithMany("Questions")
                        .HasForeignKey("UserId");

                    b.Navigation("Test");
                });

            modelBuilder.Entity("StudentTesting.Database.Models.QuestionAnswerHistory", b =>
                {
                    b.HasOne("StudentTesting.Database.Models.TestTakingHistory", "TestTakingHistory")
                        .WithMany()
                        .HasForeignKey("IdTestTakingHistory")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TestTakingHistory");
                });

            modelBuilder.Entity("StudentTesting.Database.Models.Test", b =>
                {
                    b.HasOne("StudentTesting.Database.Models.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId");

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("StudentTesting.Database.Models.TestTakingHistory", b =>
                {
                    b.HasOne("StudentTesting.Database.Models.Test", "Test")
                        .WithMany()
                        .HasForeignKey("IdTest")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentTesting.Database.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("IsUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Test");

                    b.Navigation("User");
                });

            modelBuilder.Entity("StudentTesting.Database.Models.User", b =>
                {
                    b.HasOne("StudentTesting.Database.Models.Group", "Group")
                        .WithMany("Students")
                        .HasForeignKey("IdGroup");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("StudentTesting.Database.Models.Group", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("StudentTesting.Database.Models.Question", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("StudentTesting.Database.Models.Test", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("StudentTesting.Database.Models.User", b =>
                {
                    b.Navigation("Questions");
                });
#pragma warning restore 612, 618
        }
    }
}
