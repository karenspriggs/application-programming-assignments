using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace AuthorizationExample.Services
{
    public class UserService
    {
        private PROG455FA23Entities db = new PROG455FA23Entities();

        public bool IsValidPassword(string _username, string _passwordinput)
        {
            User currentUser = GetUser(_username);

            if (currentUser == null)
            {
                return false;
            }

            int passlength = currentUser.Password.Length;

            return currentUser.Password == Encrypt(_passwordinput);
        }

        public string Encrypt(string _passwordinput)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(_passwordinput));

                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    stringBuilder.Append(bytes[i].ToString("x2"));
                }

                return stringBuilder.ToString();
            }
        }

        public void AddUser(User user)
        {
            User userToAdd = user;
            userToAdd.Password = Encrypt(user.Password);

            try
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                // 
            }
        }

        public User GetUser(string _username)
        {
            return db.Users.Where(user => user.Username == _username).FirstOrDefault();
        }
    }
}