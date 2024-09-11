using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Media;
using System.Net.NetworkInformation;

namespace Evans_ManCave
{
    public class Program
    {
        public static Player currentPlayer = new Player();
        public static bool MainLoop = true;
        public static SoundPlayer soundPlayer = new SoundPlayer("music/sound.wav");
        static void Main(string[] args)
        {
            if (!Directory.Exists("saves"))
            {
                Directory.CreateDirectory("saves");
            }
            currentPlayer = Load(out bool newP);
            if (newP)
                Encounters.FirstEncounter();
            while (MainLoop)
            {
                Encounters.RandomEncounter();
            }

        }



        static Player NewStart(int i)
        {
            Console.Clear();
            Player p = new Player();
            Console.WriteLine("Endless Escape");
            Console.WriteLine("Name:");
            p.name = Console.ReadLine();
            p.id = i;
            Console.Clear();
            Print("You awake in a cold, stone, dark room. You feel dazed and are having trouble remembering");
            Print("anything about your past.");
            if (currentPlayer.name == "")
                Print("You can't even remember your own name...");

            else
                Console.WriteLine("You know your name is " + p.name);
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("You feel around in the darkness until you find a door handle. You feel some resistance as");
            Console.WriteLine("you turn the handle, but the rusty lock breaks with little effort. You see your captor");
            Console.WriteLine("standing with his back to you outside the door.");
            return p;
        }


        public static void Quit()
        {
            Save();
            Environment.Exit(0);
        }
        public static void Save()
        {
            BinaryFormatter binForm = new BinaryFormatter();
            string path = "saves/" + currentPlayer.id.ToString() + ".level";
            FileStream file = File.Open(path, FileMode.OpenOrCreate);
            binForm.Serialize(file, currentPlayer);
            file.Close();
        }

        public static Player Load(out bool newP)
        {
            newP = false;
            Console.Clear();
            string[] paths = Directory.GetFiles("saves");
            List<Player> players = new List<Player>();
            int idCount = 0;

            BinaryFormatter binForm = new BinaryFormatter();
            foreach (string p in paths)
            {
                FileStream file = File.Open(p, FileMode.Open);
                Player player = (Player)binForm.Deserialize(file);
                file.Close();
                players.Add(player);

            }
            idCount = players.Count;

            while (true)
            {
                Console.Clear();
                Print("Choose your player", 60);

                foreach (Player p in players)
                {
                    Console.WriteLine(p.id + ": " + p.name);
                }

                Print("Please input player name or id     (id:# or playername). Additionally, 'create' will start a new save. ");
                string[] data = Console.ReadLine().Split(':');

                try
                {
                    if (data[0] == "id")
                    {
                        if (int.TryParse(data[1], out int id))
                        {
                            foreach (Player player in players)
                            {
                                if (player.id == id)
                                {
                                    return player;
                                }
                            }
                            Console.WriteLine("There is no player with that id!");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Your id needs to be a number! Press any key to continue!");
                            Console.ReadKey();
                        }
                    }
                    else if (data[0] == "create")
                    {
                        Player newPlayer = NewStart(idCount);
                        newP = true;
                        return newPlayer;


                    }
                    else
                    {
                        foreach (Player player in players)
                        {
                            if (player.name == data[0])
                            {
                                return player;
                            }
                        }
                        Console.WriteLine("There is no player with that name;");
                        Console.ReadKey();
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Your id needs to be a number! Press any key to continue!");
                    Console.ReadKey();
                }
            }
        }
        // music 
        public static void Print(string text, int speed = 40)
        {
            soundPlayer.PlayLooping();
            
            
            foreach (char c in text)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(speed);
            }
            Console.WriteLine();
        }

        //experience bar 
        public static void ProgressBar(string fillerChar, string backgroundChar, decimal value, int size)
	    {
            int dif = (int)(value * size);
            for(int i = 0; i < size; i++)
                {
                 if (i < dif)
                     Console.Write(fillerChar);
                else 
                     Console.Write(" ");
                }
	    }

    }
}

