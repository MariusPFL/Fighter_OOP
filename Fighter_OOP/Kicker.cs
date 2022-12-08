using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fighter_OOP
{
    internal class Kicker : Fighter
    {
        /// <summary>
        /// Size of the feets
        /// </summary>
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
        /// Specialattack attacks the enemies
        /// </summary>
        /// <param name="enemy">The enemy which should be attacked</param>
        public override void specialAttack(Fighter enemy)
        {
            enemy.hitPoints -= baseDamage * footSize;
        }

        /// <summary>
        /// SpecialAttack of the Kicker OBSOLETE
        /// </summary>
        /// <param name="enemy">The enemy which should be attacked</param>
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
