using NUnit.Framework;
using StudentTesting.Application.Database;
using StudentTesting.Application.UnitTest;
using StudentTesting.Database.Models;

namespace StudentTesting.Application.Tests
{
    [TestFixture]
    public class UserUnitTestingTest
    {
        [SetUp]
        public void SetUp()
        {
            DbContextKeeper.ConnectionOpen("10.0.0.2", "sa", "R1409p1209", "StudentTesting");
        }

        [Test]
        public void AddUser_NoLogin_Fail()
        {
            string login = null;
            string fullname = "fullname";
            string password = "123";
            string doc = "123";
            UserRole role = UserRole.STUDENT;

            var result = UserUnitTesting.AddUser(login, fullname, password, doc, role);

            Assert.IsFalse(result);
        }

        [Test]
        public void AddUser_NoPassword_Fail()
        {
            string login = "login";
            string fullname = "fullname";
            string password = null;
            string doc = "123";
            UserRole role = UserRole.STUDENT;

            var result = UserUnitTesting.AddUser(login, fullname, password, doc, role);

            Assert.IsFalse(result);
        }

        [Test]
        public void AddUser_NoFullname_Fail()
        {
            string login = "login";
            string fullname = null;
            string password = "123";
            string doc = "123";
            UserRole role = UserRole.STUDENT;

            var result = UserUnitTesting.AddUser(login, fullname, password, doc, role);

            Assert.IsFalse(result);
        }

        [Test]
        public void AddUser_NoDoc_Fail()
        {
            string login = "login";
            string fullname = "fullname";
            string password = "123";
            string doc = null;
            UserRole role = UserRole.STUDENT;

            var result = UserUnitTesting.AddUser(login, fullname, password, doc, role);

            Assert.IsFalse(result);
        }

        [Test]
        public void AddUser_NoRole_Fail()
        {
            string login = "login";
            string fullname = "fullname";
            string password = "123";
            string doc = "123";
            UserRole? role = null;

            var result = UserUnitTesting.AddUser(login, fullname, password, doc, role);

            Assert.IsFalse(result);
        }

        [Test]
        public void AddUser_Currect_Ok()
        {
            string login = "login";
            string fullname = "fullname";
            string password = "123";
            string doc = "123";
            UserRole? role = UserRole.STUDENT;

            var result = UserUnitTesting.AddUser(login, fullname, password, doc, role);

            Assert.IsTrue(result);
        }
    }
}
