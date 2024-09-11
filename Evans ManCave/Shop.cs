using System;
using System.Collections.Generic;
using System.Text;

namespace Evans_ManCave
{
    public class Shop
    {
        public static void Loadshop(Player p)
        {

            RunShop(p);
        }

        public static void RunShop(Player p)
        {
            int potionP;
            int armorP;
            int WeaponP;
            int difP;
            while (true)
            {
                potionP = 20 + 10 * p.mods;
                armorP = 100 * (p.armorValue + 1);
                WeaponP = 100 * p.weaponValue;
                difP = 300 + 100 * p.mods;
                Console.Clear();
                Console.WriteLine("         Shop         ");
                Console.WriteLine("======================");
                Console.WriteLine("|  (W)eapon:         $" + WeaponP);
                Console.WriteLine("|  (A)rmor:          $" + armorP);
                Console.WriteLine("|  (P)otions:        $" + potionP);
                Console.WriteLine("|  (D)ifficulty Mod: $" + difP);
                Console.WriteLine("======================");
                Console.WriteLine("(E)xit");
                Console.WriteLine("(Q)uit");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine(p.name + "'s Stats");
                Console.WriteLine("======================");
                Console.WriteLine("Current Health: " + p.health);
                Console.WriteLine("Coins:     " + p.coins);
                Console.WriteLine("Weapons Strength: " + p.weaponValue);
                Console.WriteLine("Armor Toughness: " + p.armorValue);
                Console.WriteLine("Potions: " + p.potion);
                Console.WriteLine("Difficulty Mods: " + p.mods);
                Console.WriteLine("Xp:");
                Console.Write("[");
                Program.ProgressBar("+", " ", ((decimal)p.xp / (decimal)p.GetLevelUpValue()),25);
                Console.WriteLine("]");
                Console.WriteLine("Level: " + p.level);
                
                Console.WriteLine("======================");

                //wait for input
                string input = Console.ReadLine().ToLower();
                if (input == "p" || input == "potion")
                {
                    TryBuy("potion", potionP, p);
                }
                else if (input == "w" || input == "weapon")
                {
                    TryBuy("weapon", WeaponP, p);
                }
                else if (input == "a" || input == "armor")
                {
                    TryBuy("armor", armorP, p);
                }
                else if (input == "d" || input == "difficulty Mod")
                {
                    TryBuy("dif", difP, p);
                }
                else if (input == "q" || input == "quit")
                {
                    Program.Quit();
                }
                else if (input == "e" || input == "exit")
                    break;
            }
        }
        static void TryBuy(string item, int cost, Player p)
        {
            if (p.coins >= cost)
            {
                if (item == "potion")
                    p.potion++;
                else if (item == "weapon")
                    p.weaponValue++;
                else if (item == "armor")
                    p.armorValue++;
                else if (item == "dif")
                    p.mods++;

                p.coins -= cost;
            }
            else
            {
                Console.WriteLine("Ya don't have enough gold!");
                Console.ReadKey();
            }
        }
    }
}
