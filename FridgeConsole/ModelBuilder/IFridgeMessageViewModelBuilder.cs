using FridgeConsole.Models;

namespace FridgeConsole.ModelBuilder;

public interface IFridgeMessageViewModelBuilder
{
    IEnumerable<CharacterModel> BuildModel(string messageCandidate, IEnumerable<CharacterInventoryModel> inventory);
}
