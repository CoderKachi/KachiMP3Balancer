using System;
using System.Collections.Generic;

public class Menu
{
    // Variables
    private readonly List<MenuOption> _options = new List<MenuOption>();
    private string _name = "Menu";
    private string _statusMessage = "";
    private bool _runAgain = true;

    // Contrsuctors
    public Menu(string setName)
    {
        _name = setName;
    }

    // Methods
    public void AddOption(string setKey, string setLabel, Action setAction, Func<bool>? setCondition = null)
    {
        _options.Add(new MenuOption(setKey, setLabel, ConsoleColor.White, setAction, setCondition));
    }

    public void AddOption(string setKey, string setLabel, ConsoleColor setColor, Action setAction, Func<bool>? setCondition = null)
    {
        _options.Add(new MenuOption(setKey, setLabel, setColor, setAction, setCondition));
    }

    public void SetStatus(string setStatusMessage)
    {
        _statusMessage = setStatusMessage;
    }

    public bool RunOnce()
    {
        Display();

        Console.Write("   Select an option: ");
        string? input = Console.ReadLine();

        if (input == null) return false;

        MenuOption? option = _options.Find(o => o.key == input);

        if (option == null)
        {
            // Notify User
        }
        else if(!option.isEnabled())
        {
            // Notify User
        }
        else
        {
            option.action.Invoke();
        }

        return _runAgain;
    }

    public void Exit()
    {
        _runAgain = false;
    }

    public void Reset()
    {
        _runAgain = true;
    }

    private void Display()
    {
        Console.Clear();

        if (!string.IsNullOrEmpty(_statusMessage))
        {
            Console.WriteLine("\n--- Status ---");
            Console.WriteLine(_statusMessage);
        }

        Console.WriteLine($"[ {_name} ]");
        Console.WriteLine("");
        foreach (MenuOption option in _options)
        {
            if (option.isEnabled())
            {
                ConsoleVibrant.WriteLine(option.color, $"{option.key}. {option.label}");
            }
            else
            {
                ConsoleVibrant.WriteLine(ConsoleColor.DarkGray, $"{option.key}. {option.label} (unavailable)");
            }
        }
    }
}
