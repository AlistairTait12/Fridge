using FridgeConsole.Models;

namespace FridgeConsole.Presentation;

public class FridgeMessageModelPrinter : IFridgeMessageModelPrinter
{
    private IConsoleWrapper _consoleWrapper;

    public FridgeMessageModelPrinter(IConsoleWrapper consoleWrapper)
    {
        _consoleWrapper = consoleWrapper;
    }

    public void PrintMessage(IEnumerable<CharacterModel> message)
    {
        message.ToList().ForEach(model =>
        {
            var color = model.IsAvailable ? ConsoleColor.Green : ConsoleColor.Red;
            _consoleWrapper.PrintCharacter(model.Character, color);
        });
        Console.Write("\r\n\r\n");
    }
}
