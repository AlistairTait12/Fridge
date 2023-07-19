using FridgeConsole.Models;

namespace FridgeConsole.Presentation
{
    public interface IFridgeMessageModelPrinter
    {
        void PrintMessage(List<CharacterModel> message);
    }
}
