using System;
using Xunit;
using ServiceLayer.Models;
using ServiceLayer;
using ServiceLayer.Decorators;

namespace UnitTests
{
    public class UserTests
    {
        [Fact]
        public void DescribeUserTest()
        {
            UserAccountService userService = new UserAccountService();

            UserModel user1 = new UserModel() { Username="test" , Attempts = 1, CorrectGuesses = 0, LastFighterGuessed = "testfighter"};
            UserModel user2 = new UserModel() { Username = "test", Attempts = 0, CorrectGuesses = 0, LastFighterGuessed = "testfighter" };

            string userDescription1 = userService.DescribeUser(user1);
            string userDescription2 = userService.DescribeUser(user2);

            Assert.Equal($"Player Name: test\nGuess Accuracy Rate: 0%\nLast Guessed Character: testfighter", userDescription1);
            Assert.Equal($"Player Name: test\nGuess Accuracy Rate: 0%\nLast Guessed Character: testfighter", userDescription2);
        }

        [Theory]
        [InlineData("wawa", "tespass", false)]
        [InlineData("wawawa", "Testpass", false)]
        [InlineData("wawawa", "Testpass!123", true)]
        public void ValidateUserTest(string username, string password, bool expected)
        {
            UserAccountService userService = new UserAccountService();

            bool canMakeUser = userService.ValidateAccountInputs(username, password);

            Assert.Equal(expected, canMakeUser);
        }

        [Fact]
        public void UserLoginTest()
        {
            UserAccountService userService = new UserAccountService();

            if (!userService.CheckForUsermame("testtt"))
                userService.CreateAccount("testtt", "Test!123");

            string result = userService.AttemptLogin("testtt", "Test!123");

            Assert.Equal("Login success!", result);
        }
    }
}
