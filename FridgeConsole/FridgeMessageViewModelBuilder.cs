using FridgeConsole.Models;

namespace FridgeConsole;

public class FridgeMessageViewModelBuilder : IFridgeMessageViewModelBuilder
{
    public IEnumerable<CharacterModel> BuildModel(string messageCandidate, IEnumerable<CharacterInventoryModel> inventory)
    {
        var characters = messageCandidate.ToCharArray().ToList();
        var characterModels = new List<CharacterModel>();

        foreach (var character in characters)
        {
            if (Equals(character, ' '))
            {
                characterModels.Add(new() { Character = ' ', IsAvailable = true });
                continue;
            }

            if (CharacterIsAvailable(character, inventory))
            {
                characterModels.Add(new() { Character = character, IsAvailable = true });
                inventory.FirstOrDefault(model => Equals(model.Character, character)).QuantityAvailable--;
                continue;
            }

            characterModels.Add(new() { Character = character, IsAvailable =  false });
        }

        return characterModels;
    }

    private bool CharacterIsAvailable(char character, IEnumerable<CharacterInventoryModel> inventory) =>
        inventory.Select(model => model.Character).Contains(character)
        && inventory.FirstOrDefault(model => Equals(model.Character, character)).QuantityAvailable > 0;
}
