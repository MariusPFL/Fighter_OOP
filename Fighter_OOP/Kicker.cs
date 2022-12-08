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

        public double FootSize
        {
            get { return _footSize; }
            set { _footSize = value; }
        }

        public Kicker(double footSize, String name, int index) : base(name, index)
        {
            this.FootSize = footSize;
        }

        /// <summary>
        /// Specialattack attacks the enemies
        /// </summary>
        /// <param name="enemy">The enemy which should be attacked</param>
        public override void SpecialAttack(Fighter enemy)
        {
            enemy.HitPoints -= BaseDamage * FootSize;
        }

        /// <summary>
        /// SpecialAttack of the Kicker OBSOLETE
        /// </summary>
        /// <param name="enemy">The enemy which should be attacked</param>
        public void Kick(Fighter enemy)
        {
            enemy.HitPoints -= BaseDamage * FootSize;
        }

        public override String GetDescription()
        {
            return $"{Name} Status: \n {HitPoints} hp left \n {Name} BaseDamage is: {BaseDamage} {textBorder}";
        }

        public override String GetAttackDescription()
        {
            return $"your current Attacks are \n Baseattack (press y) \n Kick (press n) {textBorder}";
        }
    }
}
