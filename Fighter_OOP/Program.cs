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
            Fighter[] fighterArr = new Fighter[0];
            //Kicker kicker1 = new Kicker(4.10, "Klaus der Kicker");
            //Puncher puncher1 = new Puncher(4.11, "Paul der Puncher");

            #region Startmenu
            // Create the Players and Characters
            int fighterCounter = 0;
            do
            {
                fighterArr = ExpandArray(fighterArr);
                Console.WriteLine("Type in your Playername: ");
                String name = Console.ReadLine();
                if (AnswerYN("Puncher (y) or Kicker (n) (press y/n)"))
                {
                    Console.WriteLine("Select the Fistsize");
                    double size = Convert.ToDouble(Console.ReadLine());
                    Puncher puncher = new Puncher(size, name, fighterCounter);
                    fighterArr = addItem(fighterArr, puncher);
                }
                else
                {
                    Console.WriteLine("Select the Footsize");
                    double size = Convert.ToDouble(Console.ReadLine());
                    Kicker kicker = new Kicker(size, name, fighterCounter);
                    fighterArr = addItem(fighterArr, kicker);
                }
                fighterCounter++;
            } while ((AnswerYN("Wanna add another Player ? (y/n)") || fighterCounter < 2) && fighterCounter < 100);


            #endregion
            Fighter[] allFightersArr = fighterArr;
            Console.WriteLine("Welcome to the Game! \n let's start!");
            Console.ReadKey();

            Boolean continueGame = true;
            do
            {
                foreach (var player in fighterArr)
                {
                    Console.Clear();
                    Console.WriteLine($"Hello {player.name} it is your turn!");
                    Console.ReadKey();
                    // Displays the Player Status
                    Console.WriteLine($"{player.getDescription()}  {player.getAttackDescription()} You have following enemies: ");
                    // Displays the enemies
                    foreach (var enemy in fighterArr)
                    {
                        if (enemy.index != player.index)
                        {
                            Console.WriteLine($"{enemy.getDescription()} (press {enemy.index} to attack him!) {Fighter.textBorder}");
                        }
                    }

                    // Check the Userinput
                    int targetEnemyIndex = 0;
                    bool isInValid = true;
                    Fighter targetEnemy;
                    Console.WriteLine("Please type which Player you wanna attack!");
                    do
                    {
                        try
                        {
                            targetEnemyIndex = Convert.ToInt32(Console.ReadLine());
                            if (targetEnemyIndex < 0 || targetEnemyIndex > fighterArr.Length - 1 || targetEnemyIndex == player.index)
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
                    Console.WriteLine(Fighter.textBorder);
                    if (AnswerYN($"{player.getAttackDescription()} type in which attack you wanna execute on {targetEnemy.name}."))
                    {
                        player.Attack(targetEnemy);
                    }
                    else
                    {
                        if (player is Kicker)
                        {
                            Kicker kicker = (Kicker)player;
                            kicker.Kick(targetEnemy);
                        }
                        else
                        {
                            Puncher puncher = (Puncher)player;
                            puncher.Punch(targetEnemy);
                        }
                    }
                    // If the Player wanna continue
                    if (AnswerYN("You wanna stop playing ?"))
                    {
                        fighterArr = removeFighter(fighterArr, player);
                    }
                    // Kicks out Death Players
                    if (someoneSurrendered(fighterArr))
                    {
                        whoSurrendered(fighterArr).rank = fighterArr.Length;
                        fighterArr = removeFighter(fighterArr, whoSurrendered(fighterArr));
                        // Update the Indexes
                        for (int i = 0; i < fighterArr.Length; i++)
                        {
                            fighterArr[i].index = i;
                        }
                    }
                }




            } while (fighterArr.Length > 1 && continueGame);
            Console.Clear();

            // Win Animation

            fighterArr[0].rank = 1;
            Console.WriteLine($"Congratulation {fighterArr[0].name} YOU DID IT YOU WON!!!! {Fighter.textBorder}");
            Console.WriteLine("The Ranklist: \n");
            foreach (var item in allFightersArr)
            {
                Console.WriteLine($"{item.name} with Rank {item.rank}");
            }
            Console.ReadKey();
        }


        #region Methods

        public static Fighter[] removeFighter(Fighter[] fighterArr, Fighter fighter)
        {
            List<Fighter> fighterList = fighterArr.ToList();
            fighterList.Remove(fighter);
            return fighterList.ToArray();
        }

        public static Boolean someoneSurrendered(Fighter[] fighterArr)
        {
            foreach (var item in fighterArr)
            {
                if (item.hitPoints <= 0)
                {
                    return true;
                }
            }
            return false;
        }

        public static Fighter whoSurrendered(Fighter[] fighterArr)
        {
            foreach (var item in fighterArr)
            {
                if (item.hitPoints <= 0)
                {
                    return item;
                }
            }
            return null;
        }

        /// <summary>
        /// Adds an item to the Array
        /// </summary>
        /// <param name="fighterArr">The Fighter array where the item should be added</param>
        /// <param name="item">The item which should be added. Should be a Fighter</param>
        /// <returns></returns>
        public static Fighter[] addItem(Fighter[] fighterArr, Fighter item)
        {
            List<Fighter> fighterList = fighterArr.ToList();
            fighterList.Add(item);
            return fighterList.ToArray();
        }



        // DELETE THIS
        public static Fighter[] ExpandArray(Fighter[] fighterArray)
        {
            Fighter[] endArray = new Fighter[fighterArray.Length + 1];
            endArray = fighterArray;
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
