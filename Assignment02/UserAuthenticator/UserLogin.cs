using System;
using System.Collections.Generic;
using System.Linq;

namespace UserAuthenticator
{
    public class UserLogin
    {
        private List<User> users = new List<User>();

        public bool RegisterUser(string email, string password)
        {
            if (IsEmailRegistered(email))
            {
                return false;
            }

            string hashedPassword = HashPassword(password);

            var newUser = new User(email, hashedPassword);
            users.Add(newUser);

            return true;
        }

        public bool LoginUser(string email, string password)
        {
            var user = users.FirstOrDefault(u => u.Email == email);

            if (user == null)
            {
                return false;
            }

            string storedHashedPassword = user.HashedPassword;
            if (VerifyPassword(password, storedHashedPassword))
            {
                return true;
            }

            return false;
        }

        public bool ResetPassword(string email, string newPassword)
        {
            var user = users.FirstOrDefault(u => u.Email == email);

            if (user == null)
            {
                return false;
            }

            string hashedPassword = HashPassword(newPassword);

            user.HashedPassword = hashedPassword;

            return true;
        }

        private string HashPassword(string password)
        {
            return password;
        }

        private bool VerifyPassword(string inputPassword, string storedHashedPassword)
        {
            return inputPassword == storedHashedPassword;
        }

        private bool IsEmailRegistered(string email)
        {
            return users.Any(u => u.Email == email);
        }

        private class User
        {
            public string Email { get; }
            public string HashedPassword { get; set; }

            public User(string email, string hashedPassword)
            {
                Email = email;
                HashedPassword = hashedPassword;
            }
        }
    }
}
