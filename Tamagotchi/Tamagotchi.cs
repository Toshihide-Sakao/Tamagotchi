using System;
using System.Threading;
using System.Collections.Generic;

namespace Tamagotchi
{
    public class Tamagotchi
    {
        public static List<Tamagotchi> list = new List<Tamagotchi>();
        public static List<Thread> threads = new List<Thread>();
        static TimeSpan tickTime = new TimeSpan(0, 5, 0);
        DateTime start = DateTime.Now;
        public string name;
        int hunger;
        int boredom;
        List<string> words = new List<string>();
        bool isAlive = true;
        static Random generator = new Random();
        

        public Tamagotchi(Thread thread)
        {
            list.Add(this);
            threads.Add(thread);
        }

        public void Feed()
        {
            hunger -= generator.Next(1, 3);
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
            DateTime time = DateTime.Now;
            DateTime restartTime = start + tickTime;

            if (time > restartTime)
            {
                hunger++;
                boredom++;
                start = DateTime.Now;
            }

            if (hunger == 10 || boredom == 10)
            {
                isAlive = false;
                list.Remove(this);
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
            boredom -= generator.Next(1, 3);
        }


        //My own Methods
        public static void ViewList()
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{i - 1}: {list[i].name}");
            }
        }
    }
}
