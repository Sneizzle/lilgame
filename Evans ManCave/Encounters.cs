using System;
using System.Collections.Generic;
using System.Text;

namespace Evans_ManCave
{
    public class Encounters
    {
        public static Random rand = new Random();
        //Encounter Generic

        //Encounters
        public static void FirstEncounter()
        {
            Console.WriteLine("You throw open the door and grab a rusty metal sword, while charging toward your captor");
            Console.WriteLine("He turns...");
            Console.ReadKey();
            Combat(false, "Kidnapper", 1, 8);
        }
        public static void BasicFightEncounter()
        {
            Console.Clear();
            Console.WriteLine("You turn the corner and there you see a hulking beast...");
            Console.ReadKey();
            Combat(true, "", 1, 8);
        }
        public static void UpstairNeighbourEncounter()
        {
            Console.Clear();
            Console.WriteLine("The door slowly creaks open as you peer into the dark room. You see a tall man with a ");
            Console.WriteLine("Long beard looking at a large book.");
            Console.ReadKey();
            Combat(false, "The Wizard", 1, 4);
        }
        public static void RestosBasementEncounter()
        {
            Console.Clear();
            Console.WriteLine("Running down the hall and kicking in the next door you see, you are met by a ");
            Console.WriteLine("angry man with knees that look strong.. Too strong. Nitro knees.");
            Console.ReadKey();
            Combat(false, "Dr Hydro Nitro Knees", 1, 8);
        }
        public static void BritishNurseEncounter()
        {
            Console.Clear();
            Console.WriteLine("The sound of a woman walking down the hallway towards you ensues. She appears to be a nurse holding a pillow.");
            Console.WriteLine("She proclaims that shes gonna pillow you and drink tea from your corpse!");
            Console.ReadKey();
            Combat(false, "Nurse at work", 1, 7);
        }

            public static void StevensEncounter()
            {
            Console.Clear();
            Console.WriteLine("You approach a noise coming from a room that smells like bananas..");
            Console.WriteLine("As the door opens you hear horse noises and whip slashes...");
            Console.ReadKey();
            Combat(false, "A wild furry!", 1, 3);
            }


        public static void ZombieEncounter()
        {
            Console.Clear();
            Console.WriteLine("A zombie approaches, groaning about the lack of brains in its vegan diet. ");
            Console.WriteLine("It does NOT want to discuss plant-based alternatives with you.");
            Console.ReadKey();
            Combat(false, "Zombie!", 1, 1);
        }


        public static void MimeEncounter()
        {
            Console.Clear();
            Console.WriteLine("You enter a room where nothing seems to move..");
            Console.WriteLine("Then! A silent mime approaches, pretending to throw invisible knives. ");
            Console.WriteLine("Suddenly, the invisible knives become real!");
            Console.ReadKey();
            Combat(false, "Mime Ninja!", 2, 8);
        }


        public static void PenguinEncounter()
        {
            Console.Clear();
            Console.WriteLine("You approach a noise coming from a room that feels cold..");
            Console.WriteLine("It offers you a *cool* death you can't refuse...");
            Console.ReadKey();
            Combat(false, "PenguinBoss!", 4, 10);
        }





        //Encounter Tools
        public static void RandomEncounter()
        {
            List<int> usedEncounters = new List<int>();

            int encounterIndex;

            do
            {
                encounterIndex = rand.Next(0, 9);

                if (!usedEncounters.Contains(encounterIndex) || encounterIndex == 0)
                {
                    usedEncounters.Add(encounterIndex);

                    switch (encounterIndex)
                    {
                        case 0:
                            BasicFightEncounter();
                            break;
                        case 1:
                            BasicFightEncounter();
                            break;
                        case 2:
                            BasicFightEncounter();
                            break;
                        case 3:
                            UpstairNeighbourEncounter();
                            break;
                        case 4:
                            RestosBasementEncounter();
                            break;
                        case 5:
                            BritishNurseEncounter();
                            break;
                        case 6:
                            StevensEncounter();
                            break;
                        case 7:
                            ZombieEncounter();
                            break;
                        case 8:
                            PenguinEncounter();
                            break;
                        case 9: 
                            MimeEncounter();
                            break;

                    }
                }
            } while (usedEncounters.Count < 10);
        }
        public static void Combat(bool random, string name, int power, int health)
        {
            string n = "";
            int p = 0;
            int h = 0;
            if (random)
            {
                n = Getname();
                p = Program.currentPlayer.GetPower();
                h = Program.currentPlayer.GetHealth();

            }
            else
            {
                n = name;
                p = power;
                h = health;
            }
            while (h > 0)
            {
                Console.Clear();
                Console.WriteLine(n);
                Console.WriteLine(p + "/" + h);
                Console.WriteLine("=====================");
                Console.WriteLine("| (A)ttack (D)efend |");
                Console.WriteLine("|  (R)un    (H)eal  |");
                Console.WriteLine("|   (C)rit!         |");
                Console.WriteLine("=====================");
                Console.WriteLine("Potions: " + Program.currentPlayer.potion + "  Health: " + Program.currentPlayer.health);
                Console.WriteLine(" Cooldown to Crit = " + Program.currentPlayer.HeavyCD);
                string input = Console.ReadLine();
                if (input.ToLower() == "a" || input.ToLower() == "attack")
                {
                    //Attack
                    if (Program.currentPlayer.counterAttack ==0)
                    {
                        Console.WriteLine("We warned you this would happen!");
                        Console.WriteLine("the " + n + " slaps your dumb undefended ass so hard,");
                        Console.WriteLine("you loose " + Program.currentPlayer.health / 2 + " health!");
                        Program.currentPlayer.health = Program.currentPlayer.health / 2;
                    }
                    else if (Program.currentPlayer.counterAttack ==20)
                    {
                        Console.WriteLine("With haste you surge forth, wacking and hoping you hit something. As you pass, the " + n + " strikes you.");
                        int damage = p - Program.currentPlayer.armorValue;
                        if (damage < 0)
                            damage = 0;
                        int attack = rand.Next(0,
                            Program.currentPlayer.weaponValue) + rand.Next(1, 4);
                        Console.WriteLine("You Lose " + damage + " health and deal " + attack + " damage");
                        Program.currentPlayer.health -= damage;
                        h -= attack;
                        Program.currentPlayer.HeavyCD = Program.currentPlayer.HeavyCD - 1;
                        if (Program.currentPlayer.HeavyCD <0) 
                        {
                            Program.currentPlayer.HeavyCD = 0;
                        }
                    }
                    
                }
                else if (input.ToLower() == "d" || input.ToLower() == "defend")
                {
                    //Defend
                    if (Program.currentPlayer.counterAttack==0)
                    {
                        Console.WriteLine("You came prepared!");
                        Console.WriteLine( n + " tries to hit you as hards as they can, but you blocked perfectly!");
                        Console.WriteLine("You might win this after all!");
                        Program.currentPlayer.counterAttack =20;
                    }
                    else if (Program.currentPlayer.counterAttack ==20)
                    {
                        Console.WriteLine("As the " + n + " prepares to strike, you ready your sword in a defensive stance");
                        int damage = (p / 4) - Program.currentPlayer.armorValue;
                        if (damage < 0)
                            damage = 0;
                        int attack = rand.Next(0, Program.currentPlayer.weaponValue) / 2;
                        Console.WriteLine("You Lose " + damage + " health and deal " + attack + " damage");
                        Program.currentPlayer.health -= damage;
                        h -= attack;
                    }
                    
                }
                // HeavyAttack
                else if (input.ToLower() == "c" || input.ToLower() == "crit")
                {
                    if (Program.currentPlayer.HeavyCD == 0)
                    {
                        Console.WriteLine("You lift your mighty rusty sword as high as you can and swing with full force while yelling BAZINGA");
                        int damage = p - Program.currentPlayer.armorValue;
                        if (damage < 0)
                            damage = 0;
                        int attack = rand.Next(0, Program.currentPlayer.weaponValue) + rand.Next(4, 10);

                        // Apply enemy's attack
                        int enemyAttack = rand.Next(1, 3); 
                        Console.WriteLine($"The {n} strikes you with a counter-blow and you lose {enemyAttack} health!");

                        // Apply player's damage
                        Console.WriteLine($"You Lose {damage} health and deal a MASSIVE ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"{attack} DAMAGE!!");
                        Console.WriteLine(); 
                        Console.ResetColor();
                        Program.currentPlayer.health -= enemyAttack; 
                        Program.currentPlayer.health -= damage;
                        h -= attack;
                        Program.currentPlayer.HeavyCD = Program.currentPlayer.HeavyCD + 3;

                        if (h > 0)
                        {
                            Program.currentPlayer.counterAttack = Program.currentPlayer.counterAttack - 20;
                            Console.WriteLine("Your massive slam to their face has enraged the enemy!");
                            Console.WriteLine("DEFEND or face the consequences!");
                        }
                    }
                    else if (Program.currentPlayer.HeavyCD != 0)
                    {
                        Console.WriteLine("You whisper to yourself: I'm too tired to fight in a fancy way and try new tricks..");
                    }
                }
                else if (input.ToLower() == "r" || input.ToLower() == "run")
                {
                    //Run
                    if (rand.Next(0, 2) == 0)
                    {
                        Console.WriteLine("As you sprint away from the " + n + ", its strike catches you in in the back, sending you sprawling onto the ground");
                        int damage = p - Program.currentPlayer.armorValue;
                        if (damage < 0)
                            damage = 0;
                        Console.WriteLine("You lose " + damage + " health and are unable to escape.");
                        Program.currentPlayer.health -= damage;
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("You use your crazy ninja moves to evade the " + n + " and you successfully escape!");
                        Console.ReadKey();
                        Shop.Loadshop(Program.currentPlayer);
                        //go to store
                    }
                }
                else if (input.ToLower() == "h" || input.ToLower() == "heal")
                {
                    //Heal
                    if (Program.currentPlayer.potion == 0)
                    {
                        Console.WriteLine("As you desperately grasp for a potion in your bag, all that you feel are empty glass flasks.");
                        int damage = p - Program.currentPlayer.armorValue;
                        if (damage < 0)
                            damage = 0;
                        Console.WriteLine("The " + n + "strikes you with a mighty blow and you lose " + damage + " health!");
                    }
                    else
                    {
                        Console.WriteLine("You reach into your bag and pull out a glowing, purple flask. You take a long drink.");
                        int potionV = 5;
                        Console.WriteLine("You gain " + potionV + " health");
                        Program.currentPlayer.health += potionV;
                        if(Program.currentPlayer.health > Program.currentPlayer.PlayerMaxHP)
                        {
                            Program.currentPlayer.health = Program.currentPlayer.PlayerMaxHP;
                            Console.WriteLine("You have reached Full Hp!");
                        }
                        Program.currentPlayer.potion--;
                        Console.WriteLine("As you were occupied, the " + n + " advanced and struck.");
                        int damage = (p / 3) - Program.currentPlayer.armorValue;
                        if (damage < 0)
                            damage = 0;
                        Console.WriteLine("You lose " + damage + " health.");

                    }
                    Console.ReadKey();
                }
                if (Program.currentPlayer.health <= 0)
                {
                    //death code
                    Console.WriteLine("As the " + n + " stands tall and comes down to strike. You have been slain by the mighty " + n);
                    Console.ReadKey();
                    System.Environment.Exit(0);
                }
                Console.ReadKey();
            }

            //loot and colored money
            int c = Program.currentPlayer.GetCoins();
            int x = Program.currentPlayer.GetXP();
            Console.WriteLine("As you stand victorious over the " + n + ", its body dissolves into ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(+c + " gold coins!");
            Console.WriteLine(); //linebreak
            Console.ResetColor(); //reset to default values
            Console.WriteLine("You have gained " + x + "XP!");
            Program.currentPlayer.coins += c;
            Program.currentPlayer.xp += x;

            if(Program.currentPlayer.CanLevelup())
            Program.currentPlayer.LevelUp();
            Console.ReadKey();
        }

        public static string Getname()
        {
            switch (rand.Next(0, 10))
            {
                case 0:
                    return "Time-Traveling Salesman";
                case 1:
                    return "Ghost";
                case 2:
                    return "Poltergeist";
                case 3:
                    return "Demon";
                case 4:
                    return "the manEater!";
                case 5:
                    return "a super big cat";
                case 6:
                    return "creepy big guy with a knife";
                case 7:
                    return "addict with glowing eyes";
                case 8:
                    return "crazed lunatic";
                case 9:
                    return "A big dwarf";
                case 10:
                    return "a crazy man";
                   
            }
            return "Human Bandit";
        }
    }
}

