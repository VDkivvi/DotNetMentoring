using System;

namespace Task1;

internal class Program
{
    public static void Main(string[] args)
    {
        var jobIsDone = false;
        while (!jobIsDone)
            jobIsDone = ConsoleInteraction();
    }

    private static char ReturnFirstChar(string str)
    {
        ArgumentException.ThrowIfNullOrEmpty(str);
        return str[0];
    }

    private static bool ConsoleInteraction()
    {
        try
        {
            Console.WriteLine("Write something");
            var text = Console.ReadLine();
            Console.WriteLine($"The first line of the text is {ReturnFirstChar(text)}");
            return true;
        }
        catch (ArgumentException e)
        {
            Console.WriteLine($"The string is empty, try again. Exception: {e.Message}");
            return false;
        }
    }
}