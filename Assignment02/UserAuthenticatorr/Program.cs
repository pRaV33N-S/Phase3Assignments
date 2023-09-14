using System;

namespace UserAuthenticatorr
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserLogin userLogin = new UserLogin();

            string newUsername = "newUser";
            string newPassword = "newPassword";

            if (userLogin.RegisterUser(newUsername, newPassword))
            {
                Console.WriteLine($"User {newUsername} registered successfully.");
            }
            else
            {
                Console.WriteLine($"User registration for {newUsername} failed.");
            }

            string existingUsername = "existingUser";
            string correctPassword = "correctPassword";
            string incorrectPassword = "incorrectPassword";

            if (userLogin.Login(existingUsername, correctPassword))
            {
                Console.WriteLine($"User {existingUsername} logged in successfully.");
            }
            else
            {
                Console.WriteLine($"User login for {existingUsername} failed.");
            }

            if (userLogin.Login(existingUsername, incorrectPassword))
            {
                Console.WriteLine($"User {existingUsername} logged in successfully.");
            }
            else
            {
                Console.WriteLine($"User login for {existingUsername} failed.");
            }

            string newPasswordForReset = "newPasswordForReset";

            if (userLogin.ResetPassword(existingUsername, newPasswordForReset))
            {
                Console.WriteLine($"Password reset for {existingUsername} succeeded.");
            }
            else
            {
                Console.WriteLine($"Password reset for {existingUsername} failed.");
            }
        }
    }
}
