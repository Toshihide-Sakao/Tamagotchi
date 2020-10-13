using System;
using System.Threading;

namespace Tamagotchi
{
    class Program
    {
        static void Main(string[] args)
        {
            Tamagotchi myTama = new Tamagotchi();

            Thread ticker = new Thread(()=> CheckTicks(myTama));
            ticker.Start();

            Console.WriteLine("Name your tamagotchi");
            myTama.name = Console.ReadLine();

            

            
        }

        void ChooseTamagotchi()
        {
            
            Console.WriteLine("Which tamagotchi do you want to play with?");
            Tamagotchi.ViewList();
            ConsoleKeyInfo uInput = Console.ReadKey();
            
            int uInputInt; 
            bool parse = int.TryParse(uInput.ToString(), out uInputInt);

            if (parse == true && uInputInt - 1 <= Tamagotchi.list.Count)
            {
                Console.WriteLine($"You chose {uInputInt - 1}: {Tamagotchi.list[uInputInt - 1].name}");
                ContinueButton();

                PlayingWithTamaGotchi(Tamagotchi.list[uInputInt - 1]);
            }
            else 
            {
                Console.WriteLine("No tamagotchi found");
                ContinueButton();
            }
        }

        void PlayingWithTamaGotchi(Tamagotchi myTama)
        {
            while (myTama.GetAlive())
            {
                Console.Clear();
                System.Console.WriteLine($"1. Teach {myTama.name} a new word");
                System.Console.WriteLine($"2. Say hi to {myTama.name}");
                System.Console.WriteLine($"3. Give {myTama.name} food");
                Console.WriteLine("4. Make a new Tamagotchi.");
                Console.WriteLine("5. View list of Tamagotchis");
                System.Console.WriteLine("6. Don't do anything");

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
                        break;
                    case ConsoleKey.D4:
                        Console.Clear();
                        Console.WriteLine("What do you want to name your new Tamagotchi?");
                        Tamagotchi tama2 = new Tamagotchi();

                        tama2.name = Console.ReadLine();
                        Console.WriteLine($"added {tama2.name} to your Tamagotchi list.");
                        
                        ContinueButton();
                        break;
                    case ConsoleKey.D5:
                        Console.Clear();
                        Console.WriteLine("List of your tamagotchis");
                        Tamagotchi.ViewList();

                        ContinueButton();
                        break;
                    case ConsoleKey.D6:
                        Console.Clear();
                        System.Console.WriteLine("You did nothing...");

                        ContinueButton();
                        break;
                    default:
                        Console.Clear();
                        System.Console.WriteLine("bRuh");
                        ContinueButton();
                        break;
                }
            }
            WhenDead(myTama);
        }

        void WhenDead(Tamagotchi myTama)
        {
            Console.Clear();
            System.Console.WriteLine($"{myTama.name} died...");
            Console.ReadLine();
        }

        static void ContinueButton()
        {
            System.Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
        }

        // Threading
        public static void CheckTicks(Tamagotchi tama)
        {
            while (tama.GetAlive())
            {
                tama.Tick();
                Thread.Sleep(1000);
            }
        }
    }
}
