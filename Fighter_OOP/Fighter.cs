using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fighter_OOP
{
    internal class Fighter
    {

		/// <summary>
		/// A generalized Textborder for all the Texts
		/// </summary>
        public static String textBorder = "\n \n ------------------- \n \n";

		/// <summary>
		/// Index of a Fighter
		/// </summary>
        private int _index;

		public int index
		{
			get { return _index; }
			set { _index = value; }
		}

		private int _rank;

		public int rank
		{
			get { return _rank; }
			set { _rank = value; }
		}


		/// <summary>
		/// Name of the Fighter which will be displayed
		/// </summary>
		private String _name;

		public String name
		{
			get { return _name; }
			set { _name = value; }
		}

		/// <summary>
		/// HitPoints of a Fighter
		/// </summary>
		private double _hitPoints;

		public double hitPoints
		{
			get { return _hitPoints; }
			set { _hitPoints = value; }
		}


		/// <summary>
		/// How much baseDamage a Fighter does
		/// </summary>
		private double _baseDamage;

		public double baseDamage
		{
			get { return _baseDamage; }
			set { _baseDamage = value; }
		}
		public Fighter(String name, int index)
		{
			hitPoints = 100;
			baseDamage = 10;
			this.name = name;
			this.index = index;
		}

		/// <summary>
		/// Simple BaseAttack
		/// </summary>
		/// <param name="enemy">Tehe enemy Fighter</param>
		public void Attack (Fighter enemy)
		{
			enemy.hitPoints -= baseDamage;
		}

		public virtual String getDescription()
		{
			return "";
		}

        public virtual String getAttackDescription()
        {
            return "";
        }

        public Boolean surrenders()
		{
			return hitPoints <= 0;
		}
	}
}