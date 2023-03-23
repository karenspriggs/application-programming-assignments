using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MansionExplorationGame.Level;
using MansionExplorationGame.Receivers;

namespace MansionExplorationGame
{
    public class Mansion
    {
        List<ILevel> mansionStories = new List<ILevel>();
        int floorIndex = 0;
        IReceiver foodReceiver = new FoodReceiver();
        IReceiver potionReceiver = new PotionReceiver();
        IReceiver coinReceiver = new CoinReceiver();

        public Mansion()
        {
            SetReceivers();
            Start();
        }

        void SetReceivers()
        {
            foodReceiver.SetNextReceiver(potionReceiver);
            potionReceiver.SetNextReceiver(coinReceiver);
        }

        void Start()
        {
            AddLevels();
            Timer.Instance.SetStartTime();
            Timer.Instance.ResetTime();
            EnterNextFloor();
        }

        void AddLevels()
        {
            mansionStories.Add(LevelFactory.CreateLevel(LevelType.MultipleChoice, ItemType.Coin, "Admission", "circle", 1, "The Foyer", "The Butler"));
            mansionStories.Add(LevelFactory.CreateLevel(LevelType.TrueFalse, ItemType.Food, "The Everlasting Pizza", "house", 2, "The Great Kitchen", "The Chef"));
            mansionStories.Add(LevelFactory.CreateLevel(LevelType.MultipleChoice, ItemType.Potion, "Hyacinth", "steps", 3, "The Foyer", "The Housemaid"));
            mansionStories.Add(LevelFactory.CreateLevel(LevelType.TrueFalse, ItemType.Coin, "Something", "family", 4, "The Library", "The Baron"));
            mansionStories.Add(LevelFactory.CreateLevel(LevelType.MultipleChoice, ItemType.Food, "Warmest Soup", "broken", 5, "The Barracks", "The Bodyguard"));
            mansionStories.Add(LevelFactory.CreateLevel(LevelType.MultipleChoice, ItemType.Potion, "Future Sight", "catch", 6, "The Penthouse", "The Madame"));
        }

        void EnterNextFloor()
        {
            if (floorIndex == 6)
            {
                Finish();
            } else
            {
                if (Timer.Instance.IsTimeRemaining())
                {
                    mansionStories[floorIndex].PrintLevelContent();
                    Console.WriteLine("");
                    Console.WriteLine("What is your answer?");
                    AnswerQuestion();
                }
                else
                {
                    GameOver();
                }
            }
        }

        string GetInput()
        {
            Console.WriteLine($"You have {Timer.Instance.PrintTimer()} remaining");
            string message = Console.ReadLine();

            if (mansionStories[floorIndex].GetType() == typeof(MultiChoiceLevel))
            {
                if (message.ToLower() != "1" && message.ToLower() != "2" && message.ToLower() != "3")
                {
                    Console.WriteLine("That is not a valid input, try again");
                    GetInput();
                }
            } else
            {
                if (message.ToLower() != "true" && message.ToLower() != "false")
                {
                    Console.WriteLine("That is not a valid input, try again");
                    GetInput();
                }
            }

            return message;
        }

        void AnswerQuestion()
        {
            Console.WriteLine("");
            if (Timer.Instance.IsTimeRemaining())
            {
                string answer = GetInput();
                if (mansionStories[floorIndex].CompareAnswer(answer))
                {
                    Console.WriteLine("That is the right answer, you can now move onto the next floor by pressing enter");
                    foodReceiver.ProcessRequest(mansionStories[floorIndex].FloorItem);
                    Console.ReadKey();
                    Console.Clear();
                    floorIndex++;
                    EnterNextFloor();
                }
                else
                {
                    PlayerLives.Instance.DepleteLife();
                    Console.WriteLine($"That is not the right answer. {PlayerLives.Instance.PrintLives()}.");
                    if (!PlayerLives.Instance.IsDead())
                    {
                        AnswerQuestion();
                    } else
                    {
                        GameOver();
                    }
                    
                }
            }
            else
            {
                GameOver();
            }
        }

        void Finish()
        {
            Console.Clear();
            Console.WriteLine("Congratulations, you have gone through the mansion and completed all of the riddles");
            Console.ReadKey();
        }

        void GameOver()
        {
            Console.Clear();
            Console.WriteLine("You were overcome by exhaustion and passed out. When you came to, you were back at the front door of the mansion. Press enter to try entering again.");
            Console.ReadKey();
            floorIndex = 0;
            PlayerLives.Instance.ResetLives();
            Timer.Instance.SetStartTime();
            Timer.Instance.ResetTime();
            EnterNextFloor();
        }
    }
}
