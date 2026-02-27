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
        Menu mainMenu = new Menu("KACHI MP3 BALANCER", ConsoleColor.Blue);
        Menu settingsMenu = new Menu("Settings");

        // Setup [mainMenu]
        mainMenu.AddOption("Add Track(s)", () =>
        {
            ClearDisplay();
            trackCount += 1;
            Console.WriteLine("Tracks Added.");
            ConfirmPermission();
        });

        mainMenu.AddOption("Add Folder", () =>
        {
            ClearDisplay();
            trackCount += 1;
            Console.WriteLine("Tracks Added.");
            ConfirmPermission();
        });


        mainMenu.AddOption("Analyse Tracks", () =>
        {
            ClearDisplay();
            tracksAnalyised = trackCount;
            Console.WriteLine("Complete.");
            ConfirmPermission();
        });

        mainMenu.AddOption("Balance Tracks", () =>
        {
            ClearDisplay();
            Console.WriteLine($"{tracksAnalyised} tracks balanced.");
            ConfirmPermission();
        }, () => trackCount > 0 && tracksAnalyised > 0);

        mainMenu.AddOption("Exit", () =>
        {
            mainMenu.RequestExit();
        });

        // Main Loop
        DisplayMenu(mainMenu);
        while (menuStack.Count > 0)
        {
            Menu currentMenu = menuStack.Peek();
            currentMenu.Run();

            if (currentMenu.RequestedExit)
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
        ConsoleVibrant.WriteLine(ConsoleColor.DarkYellow, "PRESS [ANY KEY] TO CONTINUE");
        Console.ReadKey(true);
    }

    static void ClearDisplay()
    {
        Console.Clear();
    }
}
