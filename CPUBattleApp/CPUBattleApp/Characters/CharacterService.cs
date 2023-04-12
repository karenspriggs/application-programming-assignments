using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPUBattleApp.Items;
using System.ComponentModel.DataAnnotations;

namespace CPUBattleApp.Characters
{
    // Class for handling logic for setting values for properties of characters
    public class CharacterService
    {
        // Validate the character and create a list of any errors encountered during validation
        public List<ValidationResult> ValidateCharacterEntry(ICharacter character)
        {
            List<ValidationResult> validationErrors = new List<ValidationResult>();
            var charValidationContext = new ValidationContext(character);

            var isCharValid = Validator.TryValidateObject(character, charValidationContext, validationErrors, true);

            foreach (var error in validationErrors)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                foreach (var errorName in error.MemberNames)
                {
                    Console.WriteLine($"Error in creating character. Error type: {errorName}");
                }
            }

            Console.ResetColor();

            return validationErrors;
        }

        // Save the string for the name, will be validated later
        public void SetCharName(ICharacter character, string name)
        {
            character.Name = name;
        }

        // Adds items to the player's inventory based off of their input
        public void SetInventoryItem(ICharacter character, string num)
        {
            switch (num)
            {
                case ("1"):
                    character.Inventory.Add(new Item("Block-laying glue", 2));
                    break;
                case ("2"):
                    character.Inventory.Add(new Item("Block crane", 3));
                    break;
                case ("3"):
                    character.Inventory.Add(new Item("Block generator", 4));
                    break;
                case ("4"):
                    character.Inventory.Add(new Item("Block", 1));
                    break;
                case ("5"):
                    character.Inventory.Add(new Item("Block-fetching dog", 3));
                    break;
                case ("6"):
                    character.Inventory.Add(new Item("Block^2", 2));
                    break;
            }
        }

        public void ClearInventoryItems(ICharacter character)
        {
            character.Inventory.Clear();
        }

        // Save the string for the uniform color, will be validated later
        public void SetUniformColor(ICharacter character, string color)
        {
            character.UniformColor = color;
        }

        // Set the console color for the uniform color based off of the validated string for the uniform color
        public void SetUniformConsoleColor(ICharacter character, string color)
        {
            switch (color)
            {
                case ("yellow"):
                    character.UniformTextColor = ConsoleColor.Yellow;
                    break;
                case ("blue"):
                    character.UniformTextColor = ConsoleColor.Blue;
                    break;
                case ("green"):
                    character.UniformTextColor = ConsoleColor.Green;
                    break;
                case ("purple"):
                    character.UniformTextColor = ConsoleColor.DarkMagenta;
                    break;
            }
        }

        // Set the cpu's uniform color based off of whatever the player's uniform color is
        public void GetCPUUniformColor(ICharacter cpuChar, string color)
        {
            switch (color)
            {
                case ("yellow"):
                    SetUniformConsoleColor(cpuChar, "purple");
                    break;
                case ("blue"):
                    SetUniformConsoleColor(cpuChar, "green");
                    break;
                case ("green"):
                    SetUniformConsoleColor(cpuChar, "blue");
                    break;
                case ("purple"):
                    SetUniformConsoleColor(cpuChar, "yellow");
                    break;
            }
        }

        // Save the string for the gem type, will be validated later
        public void SetGemName(ICharacter character, string gemName)
        {
            character.GemName = gemName;
        }

        // Set the console color for the gem based off of the validated string for the gem type
        public void SetGemType(ICharacter character, string gemName)
        {
            switch (gemName)
            {
                case ("sapphire"):
                    character.PlayerGem = new Gem("Sapphire");
                    break;
                case ("diamond"):
                    character.PlayerGem = new Gem("Diamond");
                    break;
                case ("ruby"):
                    character.PlayerGem = new Gem("Ruby");
                    break;
            }
        }
    }
}
