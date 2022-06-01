using NUnit.Framework;
using StudentTesting.Application.Database;
using StudentTesting.Application.UnitTest;
using System;

namespace StudentTesting.Application.Tests
{
    [TestFixture]
    public class CourseUnitTestingTest
    {
        public static byte[] UserPic = Convert.FromBase64String(@"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");

        [SetUp]
        public void SetUp()
        {
            DbContextKeeper.ConnectionOpen("10.0.0.2", "sa", "R1409p1209", "StudentTesting");
        }

        [Test]
        public void InsertAndValidation_NoTitle_Fail()
        {
            string title = null;
            string description = "desc";
            byte[] pic = UserPic;
            int userId = 1;

            bool result = CourseUnitTesting.InsertAndValidation(title, description, pic, userId);

            Assert.IsFalse(result);
        }

        [Test]
        public void InsertAndValidation_NoUserId_Fail()
        {
            string title = null;
            string description = "desc";
            byte[] pic = UserPic;
            int userId = -1;

            bool result = CourseUnitTesting.InsertAndValidation(title, description, pic, userId);

            Assert.IsFalse(result);
        }

        [Test]
        public void InsertAndValidation_NoDescription_Ok()
        {
            string title = "Title";
            string description = null;
            byte[] pic = UserPic;
            int userId = 1;

            bool result = CourseUnitTesting.InsertAndValidation(title, description, pic, userId);

            Assert.IsTrue(result);
        }


        [Test]
        public void InsertAndValidation_NoPic_Ok()
        {
            string title = "Title";
            string description = "desc";
            byte[] pic = null;
            int userId = 1;

            bool result = CourseUnitTesting.InsertAndValidation(title, description, pic, userId);

            Assert.IsTrue(result);
        }


        [Test]
        public void InsertAndValidation_AllInput_Ok()
        {
            string title = "Title";
            string description = "desc";
            byte[] pic = UserPic;
            int userId = 1;

            bool result = CourseUnitTesting.InsertAndValidation(title, description, pic, userId);

            Assert.IsTrue(result);
        }
    }
}
