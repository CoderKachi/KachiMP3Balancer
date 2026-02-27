using System;
using System.Threading;
using System.Collections.Generic;

class Program
{
    private static Stack<Menu> menuStack = new Stack<Menu>();

    // Fake Variables
    static int trackCount = 0;
    static int tracksAnalyised = 0;

    static void Main(string[] args)
    {
        // Menus
        Menu mainMenu = new Menu("Main Menu");
        Menu settingsMenu = new Menu("Settings");

        // Setup [mainMenu]
        mainMenu.AddOption("1", "Add Tracks", () =>
        {
            ClearDisplay();
            trackCount += 1;
            Console.WriteLine("Tracks Added.");
            ConfirmPermission();
        });

        mainMenu.AddOption("2", "Analyse Tracks", () =>
        {
            ClearDisplay();
            tracksAnalyised = trackCount;
            Console.WriteLine("Complete.");
            ConfirmPermission();
        });

        mainMenu.AddOption("3", "Set Target dB", () =>
        {
            ClearDisplay();
            Console.WriteLine("89.0 dB");
            ConfirmPermission();
        });

        mainMenu.AddOption("4", "Balance Tracks", () =>
        {
            ClearDisplay();
            Console.WriteLine($"{tracksAnalyised} tracks balanced.");
            ConfirmPermission();
        }, () => trackCount > 0 && tracksAnalyised > 0);

        mainMenu.AddOption("5", "Exit", ConsoleColor.DarkRed, () =>
        {
            mainMenu.Exit();
        });

        // Main Loop
        DisplayMenu(mainMenu);
        while (menuStack.Count > 0)
        {
            Menu currentMenu = menuStack.Peek();
            bool runAgain = currentMenu.RunOnce();

            if (!runAgain)
            {
                menuStack.Pop();
            }
        }
    }

    static void DisplayMenu(Menu menu)
    {
        menu.Reset();
        menuStack.Push(menu);
    }

    static void ConfirmPermission()
    {
        Console.WriteLine();
        ConsoleVibrant.WriteLine(ConsoleColor.DarkYellow, "[ PRESS ANY KEY TO CONTINUE ]");
        Console.ReadKey(true);
    }

    static void ClearDisplay()
    {
        Console.Clear();
    }
}
