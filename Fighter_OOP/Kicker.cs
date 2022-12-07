using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fighter_OOP
{
    internal class Kicker : Fighter
    {

        private double _footSize;

        public double footSize
        {
            get { return _footSize; }
            set { _footSize = value; }
        }

        public Kicker(double footSize, String name, int index) : base(name, index)
        {
            this.footSize = footSize;
        }
        /// <summary>
        /// SpecialAttack of the Kicker
        /// </summary>
        /// <param name="enemy">The enemy which should be Attacked</param>
        public void Kick(Fighter enemy)
        {
            enemy.hitPoints -= baseDamage * footSize;
        }

        public override String getDescription()
        {
            return $"{name} Status: \n {hitPoints} hp left \n {name} BaseDamage is: {baseDamage} {textBorder}";
        }

        public override String getAttackDescription()
        {
            return $"your current Attacks are \n Baseattack (press y) \n Kick (press n) {textBorder}";
        }
    }
}
