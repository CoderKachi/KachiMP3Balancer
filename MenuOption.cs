using System;

public class MenuOption
{
    public string label { get; }
    public ConsoleColor color { get; }
    public Action action { get; }
    public Func<bool> isEnabled { get; }

    public MenuOption(string setLabel, ConsoleColor setColor, Action setAction, Func<bool>? setCondition = null)
    {
        label = setLabel;
        color = setColor;
        action = setAction;
        isEnabled = setCondition ?? (() => true);
    }
}
