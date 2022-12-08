using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fighter_OOP
{
    internal class Game
    {
        private Random Random { get; set; }
        public int RoundCounter { get; set; }

        public List<Fighter> DeadFighterList { get; set; }

        public Fighter Winner { get; set; }

        public String HistoryLog { get; set; }

        public Game()
        {
            DeadFighterList = new List<Fighter>();
            Random= new Random();
        }

        //Obsolete
        public Game(Fighter fighter1, Fighter fighter2)
        {
            RandomGame(fighter1, fighter2);
        }
        public void RandomGame(Fighter fighter1, Fighter fighter2)
        {
            Boolean gameIsRunning = true;
            do
            {
                switch (Random.Next(1, 5))
                {
                    case 1:
                        fighter1.Attack(fighter2);
                        HistoryLog += $"{fighter1.Name} attacked {fighter2.Name} with the Normalattack \n hp left \n {fighter1.Name}: {fighter1.HitPoints} \n {fighter2.Name}: {fighter2.HitPoints}  hp \n";
                        break;
                    case 2:
                        fighter1.SpecialAttack(fighter2);
                        HistoryLog += $"{fighter1.Name} attacked {fighter2.Name} with his Specialattack as \n hp left \n {fighter1.Name}: {fighter1.HitPoints} \n {fighter2.Name}: {fighter2.HitPoints} hp \n";
                        break;
                    case 3:
                        fighter2.Attack(fighter1);
                        HistoryLog += $"{fighter2.Name} attacked {fighter1.Name} with the Normalattack \n hp left \n {fighter1.Name}: {fighter1.HitPoints} \n {fighter2.Name}: {fighter2.HitPoints} hp \n";
                        break;
                    case 4:
                        fighter2.SpecialAttack(fighter1);
                        HistoryLog += $"{fighter2.Name} attacked {fighter1.Name} with the Specialattack \n hp left \n {fighter1.Name}: {fighter1.HitPoints} hp \n {fighter2.Name}: {fighter2.HitPoints} hp \n";
                        break;
                }
                if (fighter1.Surrenders() || fighter2.Surrenders())
                {
                    gameIsRunning= false;
                }
                RoundCounter++;
            } while (gameIsRunning);
            if (fighter1.Surrenders())
            {
                Winner = fighter2;
            }
            else
            {
                Winner = fighter1;
            }
        }

    }
}
