using System;
using System.Collections.Generic;
using System.Text;

namespace Uppgift5;

public class ConsoleUI : IUI
{
    public void Clear()
    {
        Console.Clear();
    }
    public void Write(string text)
    {
        Console.Write(text);
    }
    public void WriteLine(string text = "")
    {
        Console.WriteLine(text);
    }
    public string ReadLine()
    {
        return Console.ReadLine() ?? "";
    }
    public string AskForString(string type)
    {
        Console.Write(type + ": ");
        return Console.ReadLine() ?? "";
    }
    public int AskForInt(string type, int defaultValue)
    {
        Console.Write(type + ": ");
        string s = Console.ReadLine() ?? "";
        if (s.IsWhiteSpace())
            return defaultValue;
        return int.Parse(s);
    }
    /// <summary>
    /// Writes the error message to the ui.
    /// </summary>
    /// <param name="message">The error message to be displayed.</param>
    public void Error(string message)
    {
        Console.WriteLine(message + "\n");
    }
    /// <summary>
    /// Writes a prompt to the ui and waits for the user to press any key.
    /// </summary>
    public void WaitForUser()
    {
        Console.WriteLine();
        Console.WriteLine("Tryck på valfri tangent för att fortsätta...");
        Console.ReadKey();
    }
}
