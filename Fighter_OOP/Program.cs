using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fighter_OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            Fighter[] fighterArr = new Fighter[0];
            //Kicker kicker1 = new Kicker(4.10, "Klaus der Kicker");
            //Puncher puncher1 = new Puncher(4.11, "Paul der Puncher");

            #region Startmenu
            // Create the Players and Characters
            int fighterCounter = 0;
            do
            {
                Console.WriteLine("Type in your Playername: ");
                String name = Console.ReadLine();
                double fighterType = RequestPositiveNumberFromUser("Puncher (1) or Kicker (2) (press 1/2)", 1, 2);
                if (fighterType == 1)
                {
                    double size = RequestPositiveNumberFromUser("Select the Fistsize max 10!", 0, 10);
                    Puncher puncher = new Puncher(size, name, fighterCounter);
                    fighterArr = AddFighter(fighterArr, puncher);
                }
                else
                {
                    double size = RequestPositiveNumberFromUser("Select the Footsize max 10!", 0, 10);
                    Kicker kicker = new Kicker(size, name, fighterCounter);
                    fighterArr = AddFighter(fighterArr, kicker);
                }
                fighterCounter++;
                //BotGame
                if (fighterCounter == 2)
                {
                    if (AnswerYN("Do you want to start a Botgame?"))
                    {
                        game.RandomGame(fighterArr[0], fighterArr[1]);
                        Console.WriteLine($"{Fighter.textBorder}The winner is: {game.Winner.Name} after {game.RoundCounter} Rounds. {Fighter.textBorder}");
                        Console.WriteLine(game.HistoryLog + Fighter.textBorder + "press any Key to continue and start a new Game");
                        Console.ReadKey();
                        fighterArr = new Fighter[0];
                        game = new Game();
                        fighterCounter = 0;
                        Console.Clear();

                    }
                }
                // Gives User direct Feedback what is wrong
                if (fighterCounter < 2)
                {
                    Console.WriteLine("Fighter Counter to low should be at least 2!");
                }
                if (fighterCounter == 99)
                {
                    Console.WriteLine("Please be aware that you maximaly can add 100 Players");
                }

            } while ((AnswerYN("Wanna add another Player ? (y/n)") || fighterCounter < 2) && fighterCounter < 100);


            #endregion

            #region manual Maingame
            Console.WriteLine("Welcome to the Game! \n let's start!");
            Console.ReadKey();

            Boolean continueGame = true;
            do
            {
                foreach (var player in fighterArr)
                {
                    Console.Clear();
                    Console.WriteLine($"Hello {player.Name} it is your turn!");
                    Console.ReadKey();
                    // Displays the Player Status
                    Console.WriteLine($"{player.GetDescription()}  {player.GetAttackDescription()} You have the following enemies: ");
                    // Displays the enemies
                    foreach (var enemy in fighterArr)
                    {
                        if (enemy.Index != player.Index)
                        {
                            Console.WriteLine($"{enemy.GetDescription()} (press {enemy.Index} to attack him!) {Fighter.textBorder}");
                        }
                    }

                    // User choose a Enemy to attack
                    int targetEnemyIndex = 0;
                    bool isInValid = true;
                    Fighter targetEnemy;
                    Console.WriteLine("Please type which Player you wanna attack!");
                    do
                    {
                        try
                        {
                            targetEnemyIndex = Convert.ToInt32(Console.ReadLine());
                            if (targetEnemyIndex < 0 || targetEnemyIndex > fighterArr.Length - 1 || targetEnemyIndex == player.Index)
                            {
                                Console.WriteLine("Please type in one of the numbers above!");
                                isInValid = true;
                            }
                            else
                            {
                                isInValid = false;
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Please type in a number;");
                            isInValid = true;
                        }
                    } while (isInValid);
                    targetEnemy = fighterArr[targetEnemyIndex];
                    // User choose an attack
                    Console.WriteLine(Fighter.textBorder);
                    if (AnswerYN($"{player.GetAttackDescription()} type in which attack you wanna execute on {targetEnemy.Name}."))
                    {
                        player.Attack(targetEnemy);
                    }
                    else
                    {
                        player.SpecialAttack(targetEnemy);
                        //if (player is Kicker)
                        //{
                        //    Kicker kicker = (Kicker)player;
                        //    kicker.Kick(targetEnemy);
                        //}
                        //else
                        //{
                        //    Puncher puncher = (Puncher)player;
                        //    puncher.Punch(targetEnemy);
                        //}
                    }
                    // If the Player wanna continue
                    //if (AnswerYN("You wanna stop playing ?"))
                    //{
                    //    fighterArr = RemoveFighter(fighterArr, player, game);
                    //}


                    // Kicks out Death Players
                    if (HasSomeoneSurrendered(fighterArr))
                    {
                        fighterArr = RemoveFighter(fighterArr, WhoSurrendered(fighterArr), game);
                        // Update the Indexes
                        for (int i = 0; i < fighterArr.Length; i++)
                        {
                            fighterArr[i].Index = i;
                        }
                    }
                }
            } while (fighterArr.Length > 1 && continueGame);
            Console.Clear();
            #endregion

            #region end win
            fighterArr[0].Rank = 1;
            game.DeadFighterList.Add(fighterArr[0]);
            Console.WriteLine($"Congratulation {fighterArr[0].Name} YOU DID IT YOU WON!!!! {Fighter.textBorder}");
            Console.WriteLine("The Ranklist: \n");
            foreach (var item in game.DeadFighterList)
            {
                Console.WriteLine($"{item.Name} with Rank {item.Rank}");
            }
            Console.ReadKey();
            #endregion

        }

        #region Methods

        public static Fighter[] RemoveFighter(Fighter[] fighterArr, Fighter fighter, Game currentGame)
        {
            fighter.Rank = fighterArr.Length;
            List<Fighter> fighterList = fighterArr.ToList();
            fighterList.Remove(fighter);
            currentGame.DeadFighterList.Add(fighter);
            return fighterList.ToArray();
        }

        /// <summary>
        /// Adds an item to the Array
        /// </summary>
        /// <param name="fighterArr">The Fighter array where the item should be added</param>
        /// <param name="fighter">The item which should be added. Should be a Fighter</param>
        /// <returns></returns>
        public static Fighter[] AddFighter(Fighter[] fighterArr, Fighter fighter)
        {
            List<Fighter> fighterList = fighterArr.ToList();
            fighterList.Add(fighter);
            return fighterList.ToArray();
        }
        public static double RequestPositiveNumberFromUser(String displayText, double minRange = 0, double maxRange = int.MaxValue)
        {
            Console.WriteLine(displayText);
            double number = 0;
            Boolean isInvalid;
            do
            {
                try
                {
                    number = Convert.ToDouble(Console.ReadLine().Trim(' '));
                    if (number < minRange || number > maxRange)
                    {
                        Console.WriteLine("Please type in a number from the given Range!");
                        isInvalid = true;
                    }
                    else
                    {
                        isInvalid = false;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please type in a Number!");
                    isInvalid = true;
                }
            } while (isInvalid);
            return number;
        }

        public static Boolean HasSomeoneSurrendered(Fighter[] fighterArr)
        {
            foreach (var item in fighterArr)
            {
                if (item.HitPoints <= 0)
                {
                    return true;
                }
            }
            return false;
        }

        public static Fighter WhoSurrendered(Fighter[] fighterArr)
        {
            foreach (var item in fighterArr)
            {
                if (item.HitPoints <= 0)
                {
                    return item;
                }
            }
            return null;
        }





        // DELETE THIS
        public static Fighter[] ExpandArray(Fighter[] fighterArray)
        {
            Fighter[] endArray = new Fighter[fighterArray.Length + 1];
            for (int i = 0; i < fighterArray.Length; i++)
            {
                endArray[i] = fighterArray[i];
            }
            return endArray;
        }

        /// <summary>
        /// Simple Yes no Question
        /// </summary>
        /// <param name="displayText">The text which should be displayed with the question</param>
        /// <returns>Boolean wheter it is yes or no</returns>
        public static Boolean AnswerYN(string displayText)
        {
            Console.WriteLine(displayText);
            while (true)
            {
                String answer = Console.ReadLine().ToLower().Trim(' ');
                if (answer == "y")
                {
                    return true;
                }
                if (answer == "n")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Sorry didn't understand that");
                }
            }
        }
        #endregion

    }
}
