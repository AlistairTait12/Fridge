using FridgeConsole.Models;

namespace FridgeConsole;

public interface IFridgeMessageViewModelBuilder
{
    IEnumerable<CharacterModel> BuildModel(string messageCandidate, IEnumerable<CharacterInventoryModel> inventory);
}
