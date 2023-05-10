using System;
using Xunit;
using ServiceLayer.Models;
using ServiceLayer;

namespace UnitTests
{
    public class FighterTests
    {
        [Fact]
        public void FighterCompareTest()
        {
            FighterQuizService fighterService = new FighterQuizService();

            FighterModel fighter1 = new FighterModel() { Name = "testname", Origin = "testorigin", DebutGame = "testdebut", Weight = "testweight" };
            FighterModel fighter2 = new FighterModel() { Name = "testname", Origin = "testorigin", DebutGame = "testdebut", Weight = "testweight" };

            string compareResult1 = fighterService.CompareFighterModels(fighter1, fighter2);

            FighterModel fighter3 = new FighterModel() { Name = "testname1", Origin = "testorigin", DebutGame = "testdebut2", Weight = "testweight2" };
            FighterModel fighter4 = new FighterModel() { Name = "testname1", Origin = "testorigin", DebutGame = "testdebut", Weight = "testweight2" };
            FighterModel fighter5 = new FighterModel() { Name = "testname1", Origin = "testorigi4n", DebutGame = "testdebut2", Weight = "testweight2" };

            string compareResult2 = fighterService.CompareFighterModels(fighter1, fighter3);
            string compareResult3 = fighterService.CompareFighterModels(fighter1, fighter4);
            string compareResult4 = fighterService.CompareFighterModels(fighter1, fighter5);

            Assert.Equal("\nCongratulations, the answer was testname", compareResult1);
            Assert.Equal("\nThe real answer and your guess have the following in common: \n- Game Series of Origin : testorigin\n", compareResult2);
            Assert.Equal("\nThe real answer and your guess have the following in common: \n- Debut Game : testdebut\n- Game Series of Origin : testorigin\n", compareResult3);
            Assert.Equal("\nYour guess and the real answer share no attributes in common!", compareResult4);
        }

        [Theory]
        [InlineData("samus", true)]
        [InlineData("daisuke", false)]
        [InlineData("mario", true)]
        public void CheckFighterExists(string name, bool exists)
        {
            FighterQuizService fighterService = new FighterQuizService();

            Assert.Equal(exists, fighterService.CheckIfFighterExists(name));
        }

        [Theory]
        [InlineData("villager", "Dream Home")]
        [InlineData("toon link", "Triforce Slash")]
        [InlineData("mario", "Mario Finale")]
        public void CheckFinalSmash(string name, string finalSmashName)
        {
            FighterQuizService fighterService = new FighterQuizService();

            Assert.Equal(finalSmashName, fighterService.GetFinalSmashName(name));
        }

        [Fact]
        public void GetRandomFighterTest()
        {
            FighterQuizService fighterService = new FighterQuizService();

            var randomFighter = fighterService.GetRandomFighter();

            Assert.Equal(typeof(FighterModel), randomFighter.GetType());
            Assert.True(fighterService.CheckIfFighterExists(randomFighter.Name));
        }
    }
}