using FridgeConsole.Models;

namespace FridgeConsole.Presentation
{
    public interface IFridgeMessageModelPrinter
    {
        void PrintMessage(IEnumerable<CharacterModel> message);
    }
}
