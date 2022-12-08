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

		/// <summary>
		/// When the Player Dies how good he was in the game
		/// If he dies early he has an higher Rank if he is the winner his rank will be one
		/// </summary>
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


		/// <summary>
		/// Ctor
		/// </summary>
		/// <param name="name">Name of the Player</param>
		/// <param name="index">Index of the Player</param>
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

		/// <summary>
		/// Method shows the status of the player
		/// </summary>
		/// <returns></returns>
		public virtual String getDescription()
		{
			return "";
		}

		/// <summary>
		/// Method describe the Attacks of the Players
		/// </summary>
		/// <returns></returns>

        public virtual String getAttackDescription()
        {
            return "";
        }

		public virtual void specialAttack(Fighter enemy)
		{

		}
		
		/// <summary>
		/// Currently Obsolete
		/// </summary>
		/// <returns></returns>
        public Boolean surrenders()
		{
			return hitPoints <= 0;
		}
	}
}