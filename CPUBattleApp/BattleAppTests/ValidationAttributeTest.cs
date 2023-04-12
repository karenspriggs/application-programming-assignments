using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using CPUBattleApp.Characters;
using CPUBattleApp.Decorators;
using System.ComponentModel.DataAnnotations;

namespace BattleAppTests
{
    public class ValidationAttributeTest
    {
        CharacterService charService = new CharacterService();

        [Fact]
        public void NameAttributeTest()
        {
            Character testCharacter1 = new Character();
            Character testCharacter2 = new Character();
            Character testCharacter3 = new Character();

            // Should get an error (name too long)
            charService.SetCharName(testCharacter1, "12345678910");
            // Should get an error (name blank)
            charService.SetCharName(testCharacter2, "");
            // Should pass
            charService.SetCharName(testCharacter3, "110");

            List<ValidationResult> validationErrors1 = charService.ValidateCharacterEntry(testCharacter1);
            List<ValidationResult> validationErrors2 = charService.ValidateCharacterEntry(testCharacter2);
            List<ValidationResult> validationErrors3 = charService.ValidateCharacterEntry(testCharacter3);

            Assert.True(validationErrors1.Where(x => x.MemberNames.Contains("Name")).Count() == 1);
            Assert.True(validationErrors2.Where(x => x.MemberNames.Contains("Name")).Count() == 1);
            Assert.True(validationErrors3.Where(x => x.MemberNames.Contains("Name")).Count() == 0);
        }

        [Fact]
        public void UniformAttributeTest()
        {
            Character testCharacter1 = new Character();
            Character testCharacter2 = new Character();

            // Should get an error
            charService.SetUniformColor(testCharacter1, "red");
            // Should pass
            charService.SetUniformColor(testCharacter2, "purple");

            List<ValidationResult> validationErrors1 = charService.ValidateCharacterEntry(testCharacter1);
            List<ValidationResult> validationErrors2 = charService.ValidateCharacterEntry(testCharacter2);

            Assert.True(validationErrors1.Where(x => x.MemberNames.Contains("UniformColor")).Count() == 1);
            Assert.True(validationErrors2.Where(x => x.MemberNames.Contains("UniformColor")).Count() == 0);
        }
        
        [Fact]
        public void GemAttributeTest()
        {
            Character testCharacter1 = new Character();
            Character testCharacter2 = new Character();

            // Should get an error
            charService.SetGemName(testCharacter1, "pearl");
            // Should pass
            charService.SetGemName(testCharacter2, "diamond");

            List<ValidationResult> validationErrors1 = charService.ValidateCharacterEntry(testCharacter1);
            List<ValidationResult> validationErrors2 = charService.ValidateCharacterEntry(testCharacter2);

            Assert.True(validationErrors1.Where(x => x.MemberNames.Contains("GemName")).Count() == 1);
            Assert.True(validationErrors2.Where(x => x.MemberNames.Contains("GemName")).Count() == 0);
        }

        [Fact]
        public void InventoryAttributeTest()
        {
            Character testCharacter1 = new Character();
            Character testCharacter2 = new Character();
            Character testCharacter3 = new Character();

            // No items added to character 1

            // Adding more than 2 items to character 2
            charService.SetInventoryItem(testCharacter2, "1");
            charService.SetInventoryItem(testCharacter2, "2");
            charService.SetInventoryItem(testCharacter2, "3");

            // Adding exactly 2 items to character 3
            charService.SetInventoryItem(testCharacter3, "1");
            charService.SetInventoryItem(testCharacter3, "2");

            List<ValidationResult> validationErrors1 = charService.ValidateCharacterEntry(testCharacter1);
            List<ValidationResult> validationErrors2 = charService.ValidateCharacterEntry(testCharacter2);
            List<ValidationResult> validationErrors3 = charService.ValidateCharacterEntry(testCharacter3);

            Assert.True(validationErrors1.Where(x => x.MemberNames.Contains("Inventory")).Count() == 1);
            Assert.True(validationErrors2.Where(x => x.MemberNames.Contains("Inventory")).Count() == 1);
            Assert.True(validationErrors3.Where(x => x.MemberNames.Contains("Inventory")).Count() == 0);
        }
    }
}
