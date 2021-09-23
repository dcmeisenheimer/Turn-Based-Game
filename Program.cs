using System;
using System.Collections.Generic;

namespace mis321_pa2_dcmeisenheimer
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> firstPlayer = new List<string>();
            string playerOne = "";
            string playerTwo = "";
            int count = 1;
            GameRules();
            playerOne = PlayerName(ref count);
            playerTwo = PlayerName(ref count);
            firstPlayer = RandomTurn(ref playerOne, ref playerTwo);
            CharacterSelect(firstPlayer, ref playerOne, ref playerTwo);
            System.Console.WriteLine("Thanks for playing!");

        }
        public static void CharacterSelect(List<string> firstPlayer, ref string playerOne, ref string playerTwo)  //Allows character to pick fighter
        {
            if (firstPlayer.Contains(playerOne))
            {
                System.Console.WriteLine($"{playerOne} you have first pick at a figher"); //Fighter Selected
                PickChampion(ref playerOne, ref playerTwo);
            }
            else if(firstPlayer.Contains(playerTwo))
            {
                System.Console.WriteLine($"{playerTwo} you have first pick at a figher");
                PickChampion(ref playerTwo, ref playerTwo);
            }
        }
        public static void PickChampion(ref string first, ref string second) //Allows random user to choose first
        {
            System.Console.WriteLine($"{first} pick your fighter: ");
            DisplayFighters(ref first, ref second);
            
            
        }
        public static void DisplayFighters(ref string first, ref string second) //Only allows character to choose avaliable characters
        {
            List<string> firstCombine = new List<string>();
            firstCombine.Add(first);
            List <string> secondCombine = new List<string>();
            secondCombine.Add(second);
            System.Console.WriteLine($"Pick by number: \n1. The Fry Kids \n2. The Hamburgler \n3. Ronald McDonald");
            firstCombine.Add(Console.ReadLine());

            if (firstCombine.Contains("1"))
            {
                System.Console.WriteLine($"{second} Pick by number: \n2. The Hamburgler \n3. Ronald McDonald");
                secondCombine.Add(Console.ReadLine());
            }
            else if (firstCombine.Contains("2"))
            {
                System.Console.WriteLine($"{second} Pick by number: \n1. The Fry Kids \n3. Ronald McDonald");
                secondCombine.Add(Console.ReadLine());
            }
            else if (firstCombine.Contains("3"))
            {
                System.Console.WriteLine($"{second} Pick by number: \n1. The Fry Kids \n2. The Hamburgler");
                secondCombine.Add(Console.ReadLine());
            }
            CharacterSelected(firstCombine, secondCombine, ref first, ref second);

        }
        public static void CharacterSelected(List<string> firstCombine, List<string> secondCombine, ref string first, ref string second) //assigns character selection to a variable
        {
            string fighterOne = firstCombine[1];
            string fighterTwo = secondCombine[1];
            string firstTurn = firstCombine[0];
            string secondTurn = secondCombine[0];

            if (fighterOne.Contains("1")) //stores the selected character
            {
                fighterOne = "The Fry Kids";
            }
            else if(fighterOne.Contains("2"))
            {
                fighterOne = "The Hamburgler";
            }
            else if(fighterOne.Contains("3"))
            {
                fighterOne = "Ronald McDonald";
            }
            if (fighterTwo.Contains("1"))
            {
                fighterTwo = "The Fry Kids";
            }
            else if(fighterTwo.Contains("2"))
            {
                fighterTwo = "The Hamburgler";
            }
            else if(fighterTwo.Contains("3"))
            {
                fighterTwo = "Ronald McDonald";
            }

            CharacterDuel(ref fighterOne, ref firstTurn, ref fighterTwo, ref secondTurn);
        }
        public static void CharacterDuel(ref string fighterOne, ref string firstTurn, ref string fighterTwo, ref string secondTurn) //Begins fight
        {
            IThrowBehavior fryThrow = new ThrowFries();
            IThrowBehavior burgerThrow = new ThrowBurgers();
            IThrowBehavior nuggetThrow = new ThrowNuggets();

            Characters fry = new FryKids(){Name = "The Fry Kids", Health = 100, PlayerAction = fryThrow.ThrowType()};
            Characters burger = new Hamburgler(){Name = "The Hamburgler", Health = 100, PlayerAction = burgerThrow.ThrowType()};
            Characters ronald = new RonaldMcDonald(){Name = "Ronald McDonald", Health = 100, PlayerAction = nuggetThrow.ThrowType()};

            if (fighterOne.ToLower() == fry.Name.ToLower() && fighterTwo.ToLower() == burger.Name.ToLower()) //Checks who is fighting
            {
                System.Console.WriteLine($"{firstTurn} has selected {fry.Name}");
                System.Console.WriteLine($"{secondTurn} has selected {burger.Name}");
                while(fry.Health > 0 || burger.Health > 0) //Keeps loop going until someone dies
                {
                    fry.SetThrowPower(fryThrow.ThrowDamage()); //uses the interface to get a damage amount
                    burger.GetDefensePower(); //Gets a random defense
                    burger.BonusPower(fry); //Bonus multipler due to enemy type
                    PressAnyKey();

                    burger.SetThrowPower(burgerThrow.ThrowDamage());
                    fry.GetDefensePower();
                    fry.DamageDealt(burger); //regular multiplier due to enemy type
                    PressAnyKey();
                    if (fry.Health <= 0) //once someone dies it tells who wons and ends program
                    {
                        System.Console.WriteLine($"Congrats {secondTurn} you win!");
                        break;
                    }
                    if (burger.Health <= 0)
                    {
                        System.Console.WriteLine($"Congrats {firstTurn} you win!");
                        break;
                    }

                }
            }
            else if(fighterOne.ToLower() == burger.Name.ToLower() && fighterTwo.ToLower() == ronald.Name.ToLower())
            {
                System.Console.WriteLine($"{firstTurn} has selected {burger.Name}");
                System.Console.WriteLine($"{secondTurn} has selected {ronald.Name}");
                while(burger.Health > 0 || ronald.Health > 0)
                {
                    burger.SetThrowPower(burgerThrow.ThrowDamage());
                    ronald.GetDefensePower();
                    ronald.BonusPower(burger); //Bonus multipler due to enemy type
                    PressAnyKey();

                    ronald.SetThrowPower(nuggetThrow.ThrowDamage());
                    burger.GetDefensePower(); 
                    burger.DamageDealt(ronald); //regular multiplier due to enemy type
                    PressAnyKey();
                    if (burger.Health <= 0) //once someone dies it tells who wons and ends program
                    {
                        System.Console.WriteLine($"Congrats {secondTurn} you win!");
                        break;
                    }
                    if (ronald.Health <= 0)
                    {
                        System.Console.WriteLine($"Congrats {firstTurn} you win!");
                        break;
                    }
                }
            }
            else if (fighterOne.ToLower() == ronald.Name.ToLower() && fighterTwo.ToLower() == fry.Name.ToLower())
            {
                System.Console.WriteLine($"{firstTurn} has selected {ronald.Name}");
                System.Console.WriteLine($"{secondTurn} has selected {fry.Name}");
                while (ronald.Health > 0 || fry.Health > 0)
                {
                    ronald.SetThrowPower(nuggetThrow.ThrowDamage());
                    fry.GetDefensePower();
                    fry.BonusPower(ronald); //Bonus multipler due to enemy type
                    PressAnyKey();

                    fry.SetThrowPower(fryThrow.ThrowDamage());
                    ronald.GetDefensePower();
                    ronald.DamageDealt(fry); //regular multiplier due to enemy type
                    PressAnyKey();

                    if (ronald.Health <= 0) //once someone dies it tells who wons and ends program
                    {
                        System.Console.WriteLine($"Congrats {secondTurn} you win!");
                        break;
                    }
                    if (fry.Health <= 0)
                    {
                        System.Console.WriteLine($"Congrats {firstTurn} you win!");
                        break;
                    }
                }
            }

        }
        public static List <string> RandomTurn(ref string playerOne, ref string playerTwo) //Random Turn Generator
        {
            Random rnd = new Random();
            var names  = new List<string> {playerOne, playerTwo};
            int index = rnd.Next(names.Count);
            names.RemoveAt(index);
            return names;
        }
        
        public static string PlayerName(ref int count) //Error Handling and stores player names
        {
            try
            {
                string player = "";
                System.Console.WriteLine($"Player {count} please write your name");
                player = Console.ReadLine();
                count++;

                return player;
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            return "invalid choice exiting system...";
        }
        public static void GameRules() //Reads Game Rules for players
        {
            System.Console.WriteLine($"Welcome to food fight! \nThe Rules of the game: \n1. Both Players will select a character \n2. Players will attack and defend by turn \n3. Once a player's health drops to 0.... Game Over!");
            PressAnyKey();
        }
        public static void PressAnyKey() //Avoid retyping 
        {
            System.Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        

    }
}
