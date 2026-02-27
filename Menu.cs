using System;
using System.Collections.Generic;

class Menu
{
    // Variables
    private readonly List<MenuOption> _options = new List<MenuOption>();
    private string _name = "Menu";
    private ConsoleColor _nameColor = ConsoleColor.White;
    private int _selectedIndex;

    private bool _requestExit;
    public bool RequestedExit => _requestExit;

    // Constructors
    public Menu(string setName)
    {
        _name = setName;
    }

    public Menu(string setName, ConsoleColor setNameColor)
    {
        _name = setName;
        _nameColor = setNameColor;
    }

    // Methods
    public void AddOption(string label, ConsoleColor color, Action action, Func<bool>? setCondition = null)
    {
        _options.Add(new MenuOption(label, color, action, setCondition));
    }

    public void AddOption(string setLabel, Action setAction, Func<bool>? setCondition = null)
    {
        _options.Add(new MenuOption(setLabel, ConsoleColor.White, setAction, setCondition));
    }

    public void RequestExit()
    {
        _requestExit = true;
    }

    public void Reset()
    {
        _requestExit = false;
        MoveToNextEnabled(0);
    }

    public void Run()
    {
        MoveToNextEnabled(0);

        while (!_requestExit)
        {
            Display();

            ConsoleKey consoleKey = Console.ReadKey(true).Key;

            switch (consoleKey)
            {
                case ConsoleKey.UpArrow:
                    MoveSelection(-1);
                    break;

                case ConsoleKey.DownArrow:
                    MoveSelection(1);
                    break;

                case ConsoleKey.Enter:
                    InvokeSelected();
                    break;

                case ConsoleKey.Escape:
                    RequestExit();
                    break;
            }
        }
    }

    private void MoveSelection(int direction)
    {
        int count = _options.Count;
        int next = _selectedIndex;

        do
        {
            next = (next + direction + count) % count;
        }
        while (!_options[next].isEnabled());

        _selectedIndex = next;
    }

    private void MoveToNextEnabled(int start)
    {
        for (int i = 0; i < _options.Count; i++)
        {
            int index = (start + i) % _options.Count;
            if (_options[index].isEnabled())
            {
                _selectedIndex = index;
                return;
            }
        }
    }

    private void InvokeSelected()
    {
        MenuOption option = _options[_selectedIndex];

        if (option.isEnabled())
        {
            option.action.Invoke();
        }
    }

    private void Display()
    {
        Console.Clear();
        ConsoleVibrant.WriteLine(_nameColor ,$"{_name}");

        for (int i = 0; i < _options.Count; i++)
        {
            MenuOption option = _options[i];

            if (!option.isEnabled())
            {
                ConsoleVibrant.WriteLine(ConsoleColor.DarkGray, $"  {option.label} (unavailable)");
            }
            else if (i == _selectedIndex)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                ConsoleVibrant.WriteLine(option.color, $"  {option.label} ");
                Console.ResetColor();
            }
            else
            {
                ConsoleVibrant.WriteLine(option.color, $"  {option.label}");
            }
        }

        Console.WriteLine();
        ConsoleVibrant.WriteLine(ConsoleColor.Blue, "NAVIGATION [UP/DOWN] | SELECT [ENTER] | BACK [ESC]");
    }
}