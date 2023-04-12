using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPUBattleApp.Characters;
using System.ComponentModel.DataAnnotations;

namespace CPUBattleApp
{
    internal class Game<T, U> where T : ICharacter
                                  where U : ICharacter
    {
        int TurnNumber = 1;
        public void BeginGame(T char1, U char2)
        {
            PlayerSetup(char1);
            ApplyCharacterChoices(char1, char2);
            Play(char1, char2);
        }

        public void PlayerSetup(ICharacter playerCharacter)
        { 
            Console.WriteLine("Welcome to the block tower building competition.\nYou and a computer player will be racing to build a tower with 100 blocks");

            CharacterService charService = new CharacterService();

            // Set properties with all player inputs to be validated
            PlayerNameInput(playerCharacter, charService);
            PlayerColorInput(playerCharacter, charService);
            PlayerGemInput(playerCharacter, charService);
            PlayerItemInput(playerCharacter, charService);

            // Validate all the inputs we just got
            List<ValidationResult> validationErrors = charService.ValidateCharacterEntry(playerCharacter);

            // If there are any errors in the list, restart the process
            if (validationErrors.Count > 0)
            {
                FixPlayerSetupErrors(playerCharacter, validationErrors);
            }
        }

        public void FixPlayerSetupErrors(ICharacter playerCharacter, List<ValidationResult> validationErrors)
        {
            Console.WriteLine("Hit enter to fix errors");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("There were some errors with the inputs you provided.\nPlease enter new answers to the following questions");

            CharacterService charService = new CharacterService();

            // If the count for this is greater than 1, that means that there was an error involving the player's name
            if (validationErrors.Where(x => x.MemberNames.Contains("Name")).Count() > 0)
            {
                Console.WriteLine("Your character's name was longer than 10 characters");
                PlayerNameInput(playerCharacter, charService);
            }

            // If the count for this is greater than 1, that means that there was an error involving the player's uniform color
            if (validationErrors.Where(x => x.MemberNames.Contains("UniformColor")).Count() > 0)
            {
                Console.WriteLine("You did not select a valid uniform color");
                PlayerColorInput(playerCharacter, charService);
            }

            // If the count for this is greater than 1, that means that there was an error involving the player's gem name
            if (validationErrors.Where(x => x.MemberNames.Contains("GemName")).Count() > 0)
            {
                Console.WriteLine("You did not select a valid gem type");
                PlayerGemInput(playerCharacter, charService);
            }

            // If the count for this is greater than 1, that means that there was an error involving the player's gem name
            if (validationErrors.Where(x => x.MemberNames.Contains("Inventory")).Count() > 0)
            {
                Console.WriteLine("You did not select two items");
                charService.ClearInventoryItems(playerCharacter);
                PlayerItemInput(playerCharacter, charService);
            }

            // If there are any errors in the list, restart the process
            if (validationErrors.Count > 0)
            {
                FixPlayerSetupErrors(playerCharacter, validationErrors);
            }
        }

        // Get input for the player's name
        public void PlayerNameInput(ICharacter playerCharacter, CharacterService charService)
        {
            Console.WriteLine("What is your name?");
            string charName = Console.ReadLine();
            charService.SetCharName(playerCharacter, charName);
        }

        // Get input for the player's jersey color
        public void PlayerColorInput(ICharacter playerCharacter, CharacterService charService)
        {
            Console.WriteLine("What uniform color would you like?\nPlease enter one of the following: purple, green, yellow, or blue");
            string colorName = Console.ReadLine();
            charService.SetUniformColor(playerCharacter, colorName);
        }

        // Get input for the player's gem type
        public void PlayerGemInput(ICharacter playerCharacter, CharacterService charService)
        {
            Console.WriteLine("What kind of gem would you like?\nPlease enter one of the following: sapphire, diamond, ruby");
            string gemName = Console.ReadLine();
            charService.SetGemName(playerCharacter, gemName);
        }

        // Get input for the player's inventory
        public void PlayerItemInput(ICharacter playerCharacter, CharacterService charService)
        {
            Console.WriteLine("\nWhich items do you want to add to your inventory? Please enter the number corresponding to the item you want, with 2 items total.\n");
            Console.WriteLine("1)Block-laying glue\n2)Block crane\n3)Block generator\n4)Block\n5)Block-fetching dog\n6)Block^2\n7)Finish adding items");
            string itemNum = Console.ReadLine();

            // Finish entering items into inventory
            if (itemNum == "7")
            {
                return;
            }

            if (itemNum == "1" || itemNum == "2" || itemNum == "3" || itemNum == "4" || itemNum == "5" || itemNum == "6")
            {
                charService.SetInventoryItem(playerCharacter, itemNum);
            }

            PlayerItemInput(playerCharacter, charService);
        }

        // Applies the text inputs to fill the player character's properties with the right values
        // once the inputs are validated
        // Also select the cpu's uniform color based off of the player's
        public void ApplyCharacterChoices(ICharacter playerCharacter, ICharacter computer)
        {
            CharacterService charService = new CharacterService();

            // Player character properties
            charService.SetUniformConsoleColor(playerCharacter, playerCharacter.UniformColor);
            charService.SetGemType(playerCharacter, playerCharacter.GemName);

            // Computer character property
            charService.GetCPUUniformColor(computer, playerCharacter.UniformColor);
        }

        public void Play(ICharacter playerCharacter, ICharacter computer)
        { 
            // Initialize the wind and attach both characters
            Wind wind = new Wind();
            wind.StartWind(1, 3);
            wind.Attach(playerCharacter);
            wind.Attach(computer);

            Console.WriteLine("The game starts now!");

            // Max tower height is 100, if a character hits this height then they win
            while (playerCharacter.TowerHeight < 100 && computer.TowerHeight < 100)
            {
                DoRound(playerCharacter, computer);
                // Do wind damage
                wind.Notify();
            }

            // Player won
            if (playerCharacter.TowerHeight >= 100)
            {
                Console.WriteLine("\nYou won!");
            }

            // Computer won
            if (computer.TowerHeight >= 100)
            {
                Console.WriteLine("\nThe computer won!");
            }

            Console.ReadKey();
        }

        public void DoRound(ICharacter playerCharacter, ICharacter computer)
        {
            Console.WriteLine($"Turn {TurnNumber}");
            TakeTurn(playerCharacter);
            TakeTurn(computer);
            TurnNumber++;
        }

        public void TakeTurn(ICharacter turnCharacter)
        {
            turnCharacter.DescribeTurn();
        }
    }
}
