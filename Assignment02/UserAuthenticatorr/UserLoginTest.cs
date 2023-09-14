using NUnit.Framework;
using System;

namespace UserAuthenticatorr
{
    [TestFixture]
    public class UserLoginTest
    {
        private UserLogin UserLogin;

        [SetUp]
        public void Setup()
        {
            UserLogin = new UserLogin();
        }

        [Test]
        public void TestUserRegistration()
        {
            string username = "testUser";
            string password = "testPassword";

            try
            {
                bool registrationResult = UserLogin.RegisterUser(username, password);
                Assert.IsTrue(registrationResult, "User registration should succeed.");
            }
            catch (Exception ex)
            {
                Assert.Fail($"An unexpected exception occurred: {ex.Message}");
            }
        }

        [Test]
        public void TestUserLogin_Success()
        {
            string username = "Praveen";
            string password = "NotJustARandomPassword";

            try
            {
                bool loginResult = UserLogin.Login(username, password);
                Assert.IsTrue(loginResult, "User login should succeed with correct credentials.");
            }
            catch (Exception ex)
            {
                Assert.Fail($"An unexpected exception occurred: {ex.Message}");
            }
        }

        [Test]
        public void TestUserLogin_Failure()
        {
            string username = "nonExistentUser";
            string password = "invalidPassword";

            try
            {
                bool loginResult = UserLogin.Login(username, password);
                Assert.IsFalse(loginResult, "User login should fail with incorrect credentials.");
            }
            catch (Exception ex)
            {
                Assert.Fail($"An unexpected exception occurred: {ex.Message}");
            }
        }

        [Test]
        public void TestPasswordReset_Success()
        {
            string username = "Praveen";
            string newPassword = "ItsARandomPassword";

            try
            {
                bool resetResult = UserLogin.ResetPassword(username, newPassword);
                Assert.IsTrue(resetResult, "Password reset should succeed with valid username.");
            }
            catch (Exception ex)
            {
                Assert.Fail($"An unexpected exception occurred: {ex.Message}");
            }
        }

        [Test]
        public void TestPasswordReset_Failure()
        {
            string username = "nonExistentUser";
            string newPassword = "newPassword123";

            try
            {
                bool resetResult = UserLogin.ResetPassword(username, newPassword);
                Assert.IsFalse(resetResult, "Password reset should fail with invalid username.");
            }
            catch (Exception ex)
            {
                Assert.Fail($"An unexpected exception occurred: {ex.Message}");
            }
        }
    }
}
