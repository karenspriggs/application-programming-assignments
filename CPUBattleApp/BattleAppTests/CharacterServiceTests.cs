using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPUBattleApp.Characters;
using CPUBattleApp.Items;
using CPUBattleApp.Decorators;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace BattleAppTests
{
    public class CharacterServiceTests
    {
        CharacterService charService = new CharacterService();

        [Theory]
        [InlineData("purple", ConsoleColor.DarkMagenta)]
        [InlineData("green", ConsoleColor.Green)]
        [InlineData("blue", ConsoleColor.Blue)]
        [InlineData("yellow", ConsoleColor.Yellow)]
        public void SetConsoleColorTheory(string color, ConsoleColor expectedColor)
        {
            Character testCharacter = new Character();
            charService.SetUniformConsoleColor(testCharacter, color);

            Assert.Equal(expectedColor, testCharacter.UniformTextColor);
        }

        [Theory]
        [InlineData("diamond")]
        [InlineData("ruby")]
        [InlineData("sapphire")]
        public void SetGemTypeTheory(string gemType)
        {
            Character testCharacter = new Character();
            charService.SetGemType(testCharacter, gemType);

            Assert.Equal(gemType, testCharacter.PlayerGem.Name);
        }

        [Theory]
        [InlineData("Bill")]
        [InlineData("Patrick")]
        [InlineData("Katie")]
        public void SetNameTheory(string name)
        {
            Character testCharacter = new Character();
            charService.SetCharName(testCharacter, name);

            Assert.Equal(name, testCharacter.Name);
        }
    }
}
