using System;
using System.Collections.Generic;
using System.Text;

namespace Evans_ManCave
{

    [Serializable]
    public class Player
    {

        public static Random rand = new Random();

        public string name;
        public int id;
        public int coins = 25;
        public int level = 1;
        public int xp = 0;
        public int health = 10;
        public int damage = 1;
        public int armorValue = 0;
        public int potion = 5;
        public int weaponValue = 1;
        public int mods = 0;
        public int PlayerMaxHP = 10;
        public int HeavyCD =3;
        public int counterAttack =20;
        public int tempHP;

        public int GetHealth()
        {
            int upper = (2 * mods + 7);
            int lower = (mods + 2);
            return rand.Next(lower, upper);
        }
        public int GetPower()
        {
            int upper = (2 * mods + 2);
            int lower = (mods + 1);
            return rand.Next(lower, upper);
        }
        public int GetCoins()
        {
            int upper = (15 * mods + 100);
            int lower = (13 * mods + 22);
            return rand.Next(lower, upper);

        }

        public int GetXP()
	{
            int upper = (20 * mods + 125);
            int lower = (15 * mods + 45);
            return rand.Next(lower, upper);
            	}
        public int GetLevelUpValue()
	{
            return 100 * level + 400;
	}

        public bool CanLevelup()
	    {
            if (xp >= GetLevelUpValue())
                return true;
            else
                return false;

        }

        //Level up


        public void LevelUp()
        {
            while (CanLevelup())
            {
                xp -= GetLevelUpValue();
                level++;
                PlayerMaxHP = PlayerMaxHP + 5;
            }
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Program.Print("Congrats! You are now level " + level + "!!!");
            Console.ResetColor();
	}

    }
}
