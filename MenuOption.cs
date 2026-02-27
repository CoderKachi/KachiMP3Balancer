using System;

public class MenuOption
{
    public string key { get; }
    public string label { get; }
    public ConsoleColor color { get; }
    public Action action { get; }
    public Func<bool> isEnabled { get; }

    public MenuOption(string setKey, string setLabel, ConsoleColor setColor, Action setAction, Func<bool>? setCondition = null)
    {
        key = setKey;
        label = setLabel;
        color = setColor;
        action = setAction;
        isEnabled = setCondition ?? (() => true);
    }
}
