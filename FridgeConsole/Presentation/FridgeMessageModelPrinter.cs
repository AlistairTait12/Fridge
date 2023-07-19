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
        throw new NotImplementedException();
    }
}
