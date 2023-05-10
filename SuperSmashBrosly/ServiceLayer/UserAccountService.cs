using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using ServiceLayer.DAL;
using ServiceLayer.Models;
using System.ComponentModel.DataAnnotations;

namespace ServiceLayer
{
    public class UserAccountService
    {
        UserDAL _dateService = new UserDAL();
        UserModel currentUser = new UserModel();

        // Validates the inputs for the username and password using the decorator pattern to ensure
        // that they meet requirements, gives feedback based off of the errors
        public bool ValidateAccountInputs(string username, string password)
        {
            UserModel attemptedUser = new UserModel() { Username = username, Password = password };

            List<ValidationResult> validationErrors = new List<ValidationResult>();

            var userValidationContext = new ValidationContext(attemptedUser);

            var isUserValid = Validator.TryValidateObject(attemptedUser, userValidationContext, validationErrors, true);

            foreach (var error in validationErrors)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                foreach (var errorName in error.MemberNames)
                {
                    Console.WriteLine($"Error in creating character. Error type: {errorName}");
                }
            }

            Console.ResetColor();

            if (validationErrors.Count > 0)
            {
                return false;
            } else
            {
                return true;
            }
        }

        public string DescribeUser(UserModel currentUser)
        {
            int Attempts = currentUser.Attempts;

            if (Attempts == 0) Attempts = 1;

            return $"Player Name: {currentUser.Username}\nGuess Accuracy Rate: {(currentUser.CorrectGuesses / Attempts)*100}%\nLast Guessed Character: {currentUser.LastFighterGuessed}";
        }

        // Create an account with the inputted username and password
        // Returns "sucess" if the account could be created, returns "username already exists"
        // if there is already an account with that username
        public string CreateAccount(string username, string password)
        {
            UserModel newUser = new UserModel() { Username = username, Attempts = 0, CorrectGuesses = 0, Password = EncryptPassword(password), LastFighterGuessed = "" };

            if (!CheckForUsermame(username))
            {
                _dateService.APIInsertRecord(newUser);
            } else
            {
                return "Username already exists, please try again with another username";
            }

            currentUser = newUser;

            return "success";
        }

        // Encrypts the player's password for storage in the database
        string EncryptPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    stringBuilder.Append(bytes[i].ToString("x2"));
                }

                return stringBuilder.ToString();
            }
        }

        // Try to log into an account with the inputted username and password
        // Return "success" if successful, return "username does not exist" if there is no account
        // with that username, return "wrong password" if the password is incorrect
        public string AttemptLogin(string username, string password)
        {
            List<UserModel> users = _dateService.APIGetbyName(username);

            if (users.Count == 0)
            {
                return "Username does not exist, please try again";
            }

            UserModel attemptedUser = users[0];

            if (attemptedUser.Password != EncryptPassword(password))
            {
                return "Incorrect password, please try again";
            }

            currentUser = attemptedUser;

            return "Login success!";
        }

        // Check to see if there is an existing account with the username
        public bool CheckForUsermame(string username)
        {
            List<UserModel> users = _dateService.APIGetbyName(username);

            return users.Count == 1;
        }

        public void SaveProgress(UserModel currentUser)
        {
            _dateService.APIUpdateRecord(currentUser);
        }

        public UserModel GetCurrentUser()
        {
            return currentUser;
        }
    }
}
