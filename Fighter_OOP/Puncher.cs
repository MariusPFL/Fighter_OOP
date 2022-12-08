using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fighter_OOP
{
    internal class Puncher : Fighter
    {
        /// <summary>
        /// Size of the fist with which he is Punching the enemies
        /// </summary>
		private double _fistSize;

		public double FistSize
		{
			get { return _fistSize; }
			set { _fistSize = value; }
		}

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="fistSize">Size of the fist</param>
        /// <param name="name">Name of the Puncher</param>
        /// <param name="index">Index of the Puncher</param>

		public Puncher(double fistSize, String name, int index) : base(name, index)
        {
            this.FistSize = fistSize;
        }

        /// <summary>
        /// Special Attack attacks the enemies
        /// </summary>
        /// <param name="enemy">The enemy which should be attacked</param>
        public override void SpecialAttack(Fighter enemy)
        {
            enemy.HitPoints -= BaseDamage * FistSize;
        }


        public override String GetDescription()
        {
            return $"{Name} Status: \n {HitPoints} hp left \n BaseDamage is: {BaseDamage} {textBorder}";
        }

        public override String GetAttackDescription()
        {
            return $"your current Attacks are \n Baseattack (press y) \n Punch (press n) {textBorder}";
        }
    }
}
