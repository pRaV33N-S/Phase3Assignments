using NUnit.Framework;

namespace UserAuthenticator.Tests
{
    [TestFixture]
    public class UserLoginTest
    {
        private UserLogin userLogin;

        [SetUp]
        public void Setup()
        {
            userLogin = new UserLogin();
        }

        [Test]
        public void TestUserRegistration_Success()
        {
            string email = "testuser@example.com";
            string password = "password123";

            bool registrationResult = userLogin.RegisterUser(email, password);

            Assert.IsTrue(registrationResult);
        }

        [Test]
        public void TestUserRegistration_DuplicateEmail()
        {
            string email = "testuser@example.com";
            string password = "password123";

            userLogin.RegisterUser(email, password);

            bool registrationResult = userLogin.RegisterUser(email, "anotherpassword");

            Assert.IsFalse(registrationResult);
        }

        [Test]
        public void TestUserLogin_Success()
        {
            string email = "testuser@example.com";
            string password = "password123";

            userLogin.RegisterUser(email, password);

            bool loginResult = userLogin.LoginUser(email, password);

            Assert.IsTrue(loginResult);
        }

        [Test]
        public void TestUserLogin_InvalidPassword()
        {
            string email = "testuser@example.com";
            string password = "password123";

            userLogin.RegisterUser(email, password);

            bool loginResult = userLogin.LoginUser(email, "incorrectpassword");

            Assert.IsFalse(loginResult);
        }

        [Test]
        public void TestPasswordReset_Success()
        {
            string email = "testuser@example.com";
            string oldPassword = "password123";
            string newPassword = "newpassword456";

            userLogin.RegisterUser(email, oldPassword);

            bool resetResult = userLogin.ResetPassword(email, newPassword);

            Assert.IsTrue(resetResult);
        }

        [Test]
        public void TestPasswordReset_UserNotFound()
        {
            string email = "nonexistentuser@example.com";
            string newPassword = "newpassword456";

            bool resetResult = userLogin.ResetPassword(email, newPassword);

            Assert.IsFalse(resetResult);
        }
    }
}
