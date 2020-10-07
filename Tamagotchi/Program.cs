using System;
using System.Threading;

namespace Tamagotchi
{
    class Program
    {
        static void Main(string[] args)
        {
            Tamagotchi myTama = new Tamagotchi();
            Thread t = new Thread(new ThreadStart());
            t.Start();

            Console.WriteLine("Name your tamagotchi");
            myTama.name = Console.ReadLine();

            while (myTama.GetAlive())
            {
                Console.Clear();
                System.Console.WriteLine($"1. Teach {myTama.name} a new word");
                System.Console.WriteLine($"2. Say hi to {myTama.name}");
                System.Console.WriteLine($"3. Give {myTama.name} food");
                System.Console.WriteLine("4. Don't do anything");

                ConsoleKeyInfo uInput = Console.ReadKey();

                switch (uInput.Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        System.Console.WriteLine("The word you want to teach");
                        string newWord = Console.ReadLine();
                        myTama.Teach(newWord);

                        System.Console.WriteLine($"You teached her {newWord}");
                        ContinueButton();
                        myTama.Tick();
                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        System.Console.WriteLine("Hi!");
                        myTama.Hi();

                        ContinueButton();
                        break;
                    case ConsoleKey.D3:
                        Console.Clear();
                        System.Console.WriteLine($"You fed {myTama.name}");
                        myTama.Feed();

                        ContinueButton();
                        myTama.Tick();
                        break;
                    case ConsoleKey.D4:
                        Console.Clear();
                        System.Console.WriteLine("You did nothing...");

                        ContinueButton();
                        myTama.Tick();
                        break;
                    default:
                        Console.Clear();
                        System.Console.WriteLine("bRuh");
                        ContinueButton();
                        break;
                }
            }

            Console.Clear();
            System.Console.WriteLine($"{myTama.name} died...");
            Console.ReadLine();
        }

        public static void ThreadProc()
        {
            for (int i = 0; i < 10; i++)
            {
                System.Console.WriteLine("ticked ok right");
                Thread.Sleep(5000);
            }
        }

        static void ContinueButton()
        {
            System.Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
        }
    }
}
