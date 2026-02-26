using System;

class Program
{
    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            DisplayMenu();
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.WriteLine("Hello World!");
                    break;

                case "2":
                    Console.Write("Enter a number: ");
                    if (int.TryParse(Console.ReadLine(), out int number))
                    {
                        Console.WriteLine($"Result: {number * 2}");
                    }
                    else
                    {
                        Console.WriteLine("Invalid number.");
                    }
                    break;

                case "3":
                    running = false;
                    Console.WriteLine("Goodbye World!");
                    break;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    static void DisplayMenu()
    {
        Console.WriteLine("\n--- Main Menu ---");
        Console.WriteLine("1. Say Hello World!");
        Console.WriteLine("2. Multiply a number by 2");
        Console.WriteLine("3. Exit");
        Console.Write("Choose an option: ");
    }
}