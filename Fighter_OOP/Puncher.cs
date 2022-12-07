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

		public double fistSize
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
            this.fistSize = fistSize;
        }
        /// <summary>
        /// Special Attack attacks the enemies
        /// </summary>
        /// <param name="enemy">The enemy which should be attacked</param>
		public void Punch(Fighter enemy)
		{
			enemy.hitPoints -= baseDamage * fistSize;
		}


        public override String getDescription()
        {
            return $"{name} Status: \n {hitPoints} hp left \n BaseDamage is: {baseDamage} {textBorder}";
        }

        public override String getAttackDescription()
        {
            return $"your current Attacks are \n Baseattack (press y) \n Punch (press n) {textBorder}";
        }
    }
}
