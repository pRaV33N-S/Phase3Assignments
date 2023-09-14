using System;
using System.Collections.Generic;

namespace UserAuthenticatorr
{
    public class UserLogin
    {
        private readonly List<User> userDatabase;

        public UserLogin()
        {
            userDatabase = new List<User>
            {
                new User("Praveen", "NotJustARandomPassword")
            };
        }

        public bool RegisterUser(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return false;
            }
            if (userDatabase.Exists(user => user.Username == username))
            {
                return false;
            }

            userDatabase.Add(new User(username, password));
            return true;
        }

        public bool Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return false;
            }

            var user = userDatabase.Find(users => users.Username == username);

            if (user != null)
            {
                return user.Password == password;
            }

            return false;
        }

        public bool ResetPassword(string username, string newPassword)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(newPassword))
            {
                return false;
            }

            var user = userDatabase.Find(users => users.Username == username);

            if (user != null)
            {
                user.Password = newPassword;
                return true;
            }

            return false;
        }
    }

    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
