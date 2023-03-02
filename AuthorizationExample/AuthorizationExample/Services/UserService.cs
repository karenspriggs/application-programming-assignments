using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

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

        public List<User> ReturnUserList()
        {
            return db.Users.ToList();
        }

        public User GetUser(string _username)
        {
            return db.Users.Where(user => user.Username == _username).FirstOrDefault();
        }

        public User FindUserWithID(int? ID)
        {
            User user = db.Users.Find(ID);
            return user;
        }

        public void EditUser(User user)
        {
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteUser(int ID)
        {
            User user = FindUserWithID(ID);
            db.Users.Remove(user);
            db.SaveChanges();
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
        }
    }
}