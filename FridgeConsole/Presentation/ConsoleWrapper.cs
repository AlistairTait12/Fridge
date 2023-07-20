using System.Diagnostics.CodeAnalysis;

namespace FridgeConsole.Presentation;

[ExcludeFromCodeCoverage]
public class ConsoleWrapper : IConsoleWrapper
{
    public void PrintCharacter(char character, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write(character);
        Console.ForegroundColor = ConsoleColor.White;
    }

    public string ReadStringFromUser()
    {
        return Console.ReadLine();
    }
}
