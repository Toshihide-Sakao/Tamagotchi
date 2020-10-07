using System;
using System.Collections.Generic;

namespace Tamagotchi
{
    public class Tamagotchi
    {
        public static List<Tamagotchi> list = new List<Tamagotchi>();
        static TimeSpan tickTime = new TimeSpan(0, 1, 0);
        public string name;
        int hunger;
        int boredom;
        List<string> words = new List<string>();
        bool isAlive = true;
        static Random generator = new Random();
        

        public Tamagotchi()
        {
            list.Add(this);
        }

        public void Feed()
        {
            hunger--;
        }
        public void Hi()
        {
            if (words.Count == 0)
            {
                System.Console.WriteLine("Bruh");
            }
            else
            {
                int rnd = generator.Next(0, words.Count);
                System.Console.WriteLine($"{name} said {words[rnd]}");

                ReduceBoredom();
            }

        }
        public void Teach(string word)
        {
            words.Add(word);
        }
        public void Tick()
        {
            DateTime startTime;
            DateTime end = tickTime;

            if (startTime > )
            {
                
            }

            hunger++;
            boredom++;

            if (hunger == 10 || boredom == 10)
            {
                isAlive = false;
            }
        }
        public void PrintStats()
        {
            if (isAlive == true)
                System.Console.WriteLine("Tamagotchi is Alive");
            else
                System.Console.WriteLine("Tamagotchi is Dead");
            System.Console.WriteLine($"\nHunger: {hunger} \nBoredom: {boredom}");
        }
        public bool GetAlive()
        {
            return isAlive;
        }
        void ReduceBoredom()
        {
            boredom--;
        }
    }
}
