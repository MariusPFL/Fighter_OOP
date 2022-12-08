using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fighter_OOP
{
    internal class Game
    {
        private Random random = new Random();
        public int roundCounter { get; set; }

        public List<Fighter> deadFighterList { get; set; }

        public Fighter winner { get; set; }

        public String historyLog { get; set; }
        public Game()
        {
            deadFighterList = new List<Fighter>();
        }

        //For Random games
        public Game(Fighter fighter1, Fighter fighter2)
        {
            RandomGame(fighter1, fighter2);
        }
        public void RandomGame(Fighter fighter1, Fighter fighter2)
        {
            Boolean gameIsRunning = true;
            do
            {
                switch (random.Next(1, 4))
                {
                    case 1:
                        fighter1.Attack(fighter2);
                        historyLog += $"{fighter1.name} attacked {fighter2.name} with the Normalattack \n hp left \n {fighter1.name}: {fighter1.hitPoints} \n {fighter2.name}: {fighter2.hitPoints}  hp \n";
                        break;
                    case 2:
                        fighter1.specialAttack(fighter2);
                        historyLog += $"{fighter1.name} attacked {fighter2.name} with his Specialattack as \n hp left \n {fighter1.name}: {fighter1.hitPoints} \n {fighter2.name}: {fighter2.hitPoints} hp \n";
                        break;
                    case 3:
                        fighter2.Attack(fighter1);
                        historyLog += $"{fighter2.name} attacked {fighter1.name} with the Normalattack \n hp left \n {fighter1.name}: {fighter1.hitPoints} \n {fighter2.name}: {fighter2.hitPoints} hp \n";
                        break;
                    case 4:
                        fighter2.specialAttack(fighter1);
                        historyLog += $"{fighter2.name} attacked {fighter1.name} with the Specialattack \n hp left \n {fighter1.name}: {fighter1.hitPoints} hp \n {fighter2.name}: {fighter2.hitPoints} hp \n";
                        break;
                }
                if (fighter1.surrenders() || fighter2.surrenders())
                {
                    gameIsRunning= false;
                }
                roundCounter++;
            } while (gameIsRunning);
            if (fighter1.surrenders())
            {
                winner = fighter2;
            }
            else
            {
                winner = fighter1;
            }
        }

    }
}
