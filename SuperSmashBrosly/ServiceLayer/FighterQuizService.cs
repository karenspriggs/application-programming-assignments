using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.Models;
using ServiceLayer.DAL;

namespace ServiceLayer
{
    public class FighterQuizService
    {
        FighterDAL fighterDAL = new FighterDAL();
        Random random = new Random();

        // Generates the message to print to the player to either tell them that they guessed correctly
        // or tell them which attributes their guess and the real answer have in common
        public string CompareFighterModels(FighterModel guess, FighterModel real)
        {
            if (guess.Name == real.Name)
            {
                return $"\nCongratulations, the answer was {guess.Name}";
            }

            string hint = "\nThe real answer and your guess have the following in common: \n";
            int commonCount = 0;

            if (guess.DebutGame == real.DebutGame)
            {
                hint += $"- Debut Game : {guess.DebutGame}\n";
                commonCount++;
            }

            if (guess.Origin == real.Origin)
            {
                hint += $"- Game Series of Origin : {guess.Origin}\n";
                commonCount++;
            }

            if (guess.Weight == real.Weight)
            {
                hint += $"- Weight Class : {guess.Weight}\n";
                commonCount++;
            }

            if (commonCount == 0)
            {
                hint = "\nYour guess and the real answer share no attributes in common!";
            }

            return hint;
        }

        // Check if a fighter exists, used to tell if the player has inputted a valid guess
        public bool CheckIfFighterExists(string name)
        {
            return fighterDAL.APIGetbyName(name).Count == 1;
        }

        // Get the fighter with this name to compare to the answer
        public FighterModel GetFighterWithName(string name)
        {
            return fighterDAL.APIGetbyName(name)[0];
        } 

        // Get a random fighter from the database to use as the answer
        public FighterModel GetRandomFighter()
        {
            List<FighterModel> allFighters = fighterDAL.APIGetAll();

            int index = random.Next(allFighters.Count);

            return allFighters[index];
        }

        //Gets the final smash name for the special hint
        public string GetFinalSmashName(string name)
        {
            return GetFighterWithName(name).FinalSmashName;
        }
    }
}
