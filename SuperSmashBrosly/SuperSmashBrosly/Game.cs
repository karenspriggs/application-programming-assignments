using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.Models;
using ServiceLayer;
using ServiceLayer.DAL;
using DatabaseLogger;

namespace SuperSmashBrosly
{
    public class Game
    {
        // Either log in or make an account
        // Smash bros character is randomly picked
        // Keep guessing until you get it
        // Option to try again

        bool guestMode = false;
        bool hasWon = false;
        bool isLoggedIn = false;

        int MaxGuesses = 8;
        int currentGuess = 0;

        FighterQuizService fighterService = new FighterQuizService();
        UserAccountService userService = new UserAccountService();

        UserModel currentUser;
        DatabaseLogger.DatabaseLogger dbLogger;

        public Game()
        {
            dbLogger = new DatabaseLogger.DatabaseLogger();
            Start();
        }

        void Start()
        {
            Console.WriteLine("Hello and welcome to Super Smash Bros-ly, the Smash Bros fighter guessing game");
            SelectStartOption();
        }

        void SelectStartOption()
        {
            Console.WriteLine("Would you like to: \n1) create an account \n2) log in to an existing account\n3) play as a guest?");
            string input = Console.ReadLine();

            if (input != "1" && input != "2" && input != "3")
            {
                Console.WriteLine("That is not an option, please try again after hitting enter");
                Console.ReadKey();
                Console.Clear();
                SelectStartOption();
            }

            switch (input)
            {
                case ("1"):
                    StartCreateAccount();
                    break;
                case ("2"):
                    StartLogin();
                    break;
                case ("3"):
                    guestMode = true;
                    InitializeGuestAccount();
                    break;
            }

            StartGame();
        }

        // Create information for a guest account so guests can keep track of their stats for the session
        void InitializeGuestAccount()
        {
            currentUser = new UserModel() { Username = "Guest", CorrectGuesses = 0, Attempts = 0, LastFighterGuessed = "No fighter guessed yet" };
        }

        // Display the account information for the current user
        void AccountPage()
        {
            Console.Clear();
            Console.WriteLine("Active user information\n-------------------------------------------------------\n");
            Console.WriteLine(userService.DescribeUser(currentUser));
            Console.WriteLine("\n-------------------------------------------------------");
        }

        // Create an account, keep repeating the process until the player has inputted valid credentials
        void StartCreateAccount()
        {
            while (!isLoggedIn)
            {
                AttemptCreateAccount();
            }
        }

        // Attempt to create an account, the only reasons this would fail is if there is already an account with the provided
        // username or if the inputs are not valid
        void AttemptCreateAccount()
        {
            Console.Clear();

            Console.WriteLine("Input your username:");
            string username = Console.ReadLine();

            Console.WriteLine("Input your password (must be over 6 characters and contain a symbol and capital letter):");
            string password = Console.ReadLine();

            // Also make sure to validate with decorators
            bool isValidated = userService.ValidateAccountInputs(username, password);

            if (!isValidated)
            {
                Console.WriteLine("The values that you entered are not valid, please hit enter and then try again");
                Console.ReadKey();
                AttemptCreateAccount();
            }

            string createAccountResult = userService.CreateAccount(username, password);

            if (createAccountResult == "success")
            {
                dbLogger.LogMessage(new LogMessage() { LogType="Info", Message=$"New account created with username {username}"});

                isLoggedIn = true;
                currentUser = userService.GetCurrentUser();
            } else
            {
                dbLogger.LogMessage(new LogMessage() { LogType = "Error", Message = $"Error creating new account: {createAccountResult}" });
            }
        }

        // Starting the login processing, attempting the logins over and over until successfu; 
        void StartLogin()
        {
            while (!isLoggedIn)
            {
                AttemptLogin();
            }
        }

        // Do a login attempt
        void AttemptLogin()
        {
            Console.Clear();

            Console.WriteLine("Input your username:");
            string username = Console.ReadLine();

            Console.WriteLine("Input your password:");
            string password = Console.ReadLine();

            string loginResult = userService.AttemptLogin(username, password);

            Console.WriteLine(loginResult);

            if (loginResult == "Login success!")
            {
                isLoggedIn = true;
                dbLogger.LogMessage(new LogMessage() { LogType = "Info", Message = $"Logged into account with the username {username}" });
                currentUser = userService.GetCurrentUser();
            }
            else
            {
                Console.WriteLine("Login not successful, hit enter to try again");
                dbLogger.LogMessage(new LogMessage() { LogType = "Error", Message = $"Error logging in: {loginResult}" });
                Console.ReadKey();
            }
        }

        // Start a round of the game, this contains the main game loop
        void StartGame()
        {
            AccountPage();
            FighterModel answer = fighterService.GetRandomFighter();

            currentGuess = 0;
            hasWon = false;

            while (!hasWon && currentGuess < MaxGuesses)
            {
                MakeGuess(answer);
                currentGuess++;
            }

            if (!hasWon)
            {
                Console.WriteLine($"Unfortunately you did not guess correctly in time. The answer was {answer.Name}");
            }

            currentUser.Attempts++;

            if (!guestMode)
            {
                dbLogger.LogMessage(new LogMessage() { LogType = "Info", Message = $"Updated info for user {currentUser.Username}" });
                userService.SaveProgress(currentUser);
            }

            PlayAgain();
        }

        // Lets users guess a character
        void MakeGuess(FighterModel answer)
        {
            if (currentGuess == MaxGuesses - 1)
            {
                Console.WriteLine($"Here is a special hint: {fighterService.GetFinalSmashName(answer.Name)}");
            }

            Console.WriteLine($"\nAttempts remaining: {MaxGuesses - currentGuess}");
            Console.WriteLine("Please input your answer on the following line:");

            string guess = Console.ReadLine().ToLower();
            FighterModel guessedFighter = new FighterModel();

            if (fighterService.CheckIfFighterExists(guess))
            {
                guessedFighter = fighterService.GetFighterWithName(guess);
            } else
            {
                Console.WriteLine("That is not a valid guess, hit enter to try again");
                Console.ReadKey();
                Console.Clear();
                MakeGuess(answer);
            }

            string result = fighterService.CompareFighterModels(guessedFighter, answer);

            if (result == $"\nCongratulations, the answer was {guessedFighter.Name}")
            {
                Console.WriteLine($"\nCongratulations, you have guessed correctly! The answer was {guessedFighter.Name}");
                hasWon = true;
                currentUser.CorrectGuesses++;
                currentUser.LastFighterGuessed = guessedFighter.Name;
            }
            else
            {
                Console.WriteLine(result);
            }
        }

        // Gives players the option to play again
        void PlayAgain()
        {
            Console.WriteLine("\nWould you like to play again?\n1) Yes\n2) No");
            string input = Console.ReadLine();

            if (input != "1" && input != "2")
            {
                Console.WriteLine("That is not an option, please try again after hitting enter");
                Console.ReadKey();
                Console.Clear();
                PlayAgain();
            }

            switch (input)
            {
                case ("1"):
                    StartGame();
                    break;
                case ("2"):
                    Console.WriteLine("Thank you for playing! Press enter to quit");
                    Console.ReadKey();
                    break;
            }
        }
    }
}
