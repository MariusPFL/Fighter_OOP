using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fighter_OOP
{
    internal class Puncher : Fighter
    {
		private double _fistSize;

		public double fistSize
		{
			get { return _fistSize; }
			set { _fistSize = value; }
		}

		public Puncher(double fistSize, String name, int index) : base(name, index)
        {
            this.fistSize = fistSize;
        }

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
