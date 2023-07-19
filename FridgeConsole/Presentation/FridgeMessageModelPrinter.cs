using FridgeConsole.Models;

namespace FridgeConsole.Presentation;

public class FridgeMessageModelPrinter : IFridgeMessageModelPrinter
{
    private IConsoleWrapper _consoleWrapper;

    public FridgeMessageModelPrinter(IConsoleWrapper consoleWrapper)
    {
        _consoleWrapper = consoleWrapper;
    }

    public void PrintMessage(List<CharacterModel> message)
    {
        message.ForEach(model =>
        {
            if (model.IsAvailable)
            {
                _consoleWrapper.PrintCharacter(model.Character, ConsoleColor.Green);
            };

            if (!model.IsAvailable)
            {
                _consoleWrapper.PrintCharacter(model.Character, ConsoleColor.Red);
            };
        });
    }
}
