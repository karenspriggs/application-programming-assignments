using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPUBattleApp.Items;
using System.ComponentModel.DataAnnotations;

namespace CPUBattleApp.Characters
{
    public class CharacterService
    {
        // Validate the character and create a list of any errors encountered during validation
        public List<ValidationResult> ValidateCharacterEntry(ICharacter character)
        {
            List<ValidationResult> validationErrors = new List<ValidationResult>();
            var charValidationContext = new ValidationContext(character);

            var isCharValid = Validator.TryValidateObject(character, charValidationContext, validationErrors, true);

            foreach(var error in validationErrors)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                foreach(var errorName in error.MemberNames)
                {
                    Console.WriteLine($"Error in creating character. Error type: {errorName}");
                }
            }

            Console.ResetColor();

            return validationErrors;
        }

        // Set the console color for the uniform color based off of the validated string for the uniform color
        public void SetUniformColor(ICharacter character, string color)
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
                    SetUniformColor(cpuChar, "purple");
                    break;
                case ("blue"):
                    SetUniformColor(cpuChar, "green");
                    break;
                case ("green"):
                    SetUniformColor(cpuChar, "blue");
                    break;
                case ("purple"):
                    SetUniformColor(cpuChar, "yellow");
                    break;
            }
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
