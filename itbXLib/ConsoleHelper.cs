namespace itbXLib;

public static class ConsoleHelper
{
    public static void ColorWrite(string msg, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write(msg);
        Console.ResetColor();
    }
    
    public static void ColorWriteLine(string msg, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(msg);
        Console.ResetColor();
    }

    public static void HeaderSeparator(string msg)
    {
        Console.WriteLine("====================");
        Console.WriteLine(msg);
        Console.WriteLine("====================");
    }
}