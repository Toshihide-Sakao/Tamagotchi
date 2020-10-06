using System;

namespace Tamagotchi
{
    class Program
    {
        static void Main(string[] args)
        {
            Tamagotchi myTama = new Tamagotchi();

            Console.WriteLine("Name your tamagotchi");
            myTama.name = Console.ReadLine();

            System.Console.WriteLine($"1. Teach {myTama.name} a new word");
            System.Console.WriteLine($"2. Say hi to {myTama.name}");
            System.Console.WriteLine($"3. Give {myTama.name} food");
            System.Console.WriteLine("4. Don't do anything");

            ConsoleKeyInfo uInput = Console.ReadKey();
            while (myTama.GetAlive())
            {
                switch (uInput.Key)
                {
                    case ConsoleKey.D1:
                        System.Console.WriteLine("The word you want to teach");
                        string newWord = Console.ReadLine();
                        myTama.Teach(newWord);

                        System.Console.WriteLine($"You teached her {newWord}");

                        ContinueButton();
                        myTama.Tick();
                        break;
                    case ConsoleKey.D2:
                        System.Console.WriteLine("Hi!");
                        myTama.Hi();

                        ContinueButton();
                        break;
                    case ConsoleKey.D3:
                        System.Console.WriteLine($"You fed {myTama.name}");
                        myTama.Feed();

                        ContinueButton();
                        myTama.Tick();
                        break;
                    case ConsoleKey.D4:
                        System.Console.WriteLine("You did nothing...");

                        ContinueButton();
                        myTama.Tick();
                        break;
                    default:
                        System.Console.WriteLine("bRuh");
                        ContinueButton();
                        break;
                }
            }

            System.Console.WriteLine($"{myTama.name} died...");
        }
        static void ContinueButton()
        {
            System.Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
        }
    }
}
