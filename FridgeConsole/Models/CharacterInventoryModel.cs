namespace FridgeConsole.Models;

public record CharacterInventoryModel
{
    public char Character { get; set; }
    public int QuantityAvailable { get; set; }
}
