using FluentAssertions;
using FridgeConsole.ModelBuilder;
using FridgeConsole.Models;

namespace FridgeConsoleTests.ModelBuilderTests;

[TestFixture]
public class FridgeMessageViewModelBuilderTests
{
    private FridgeMessageViewModelBuilder _modelBuilder;

    [SetUp]
    public void SetUp()
    {
        _modelBuilder = new();
    }

    [Test]
    public void BuildModel_With_Each_Char_Available_Returns_List_Of_CharacterModels_Which_Are_Available()
    {
        // Arrange
        var expected = new List<CharacterModel>
        {
            new() { Character = 'a', IsAvailable = true },
            new() { Character = 'b', IsAvailable = true },
            new() { Character = 'c', IsAvailable = true }
        };

        // Act
        var actual = _modelBuilder.BuildModel("abc", GetCharacterInventoryModels());

        // Assert
        actual.Should().BeEquivalentTo(expected, options => options.WithStrictOrdering());
    }

    [Test]
    public void BuildModel_With_Unavailable_Char_Returns_List_With_Mixed_Availability()
    {
        // Arrange
        var expected = new List<CharacterModel>
        {
            new() { Character = 'a', IsAvailable = true },
            new() { Character = 'b', IsAvailable = true },
            new() { Character = 'c', IsAvailable = true },
            new() { Character = 'd', IsAvailable = false },
        };

        // Act
        var actual = _modelBuilder.BuildModel("abcd", GetCharacterInventoryModels());

        // Assert
        actual.Should().BeEquivalentTo(expected, options => options.WithStrictOrdering());
    }

    [Test]
    public void BuildModel_With_Depleted_Char_Returns_List_With_Mixed_Availability()
    {
        // Arrange
        var expected = new List<CharacterModel>
        {
            new() { Character = 'a', IsAvailable = true },
            new() { Character = 'b', IsAvailable = true },
            new() { Character = 'c', IsAvailable = true },
            new() { Character = 'a', IsAvailable = false },
        };

        // Act
        var actual = _modelBuilder.BuildModel("abca", GetCharacterInventoryModels());

        // Assert
        actual.Should().BeEquivalentTo(expected, options => options.WithStrictOrdering());
    }

    [Test]
    public void BuildModel_With_Spaces_In_String_Returns_List_With_Space_CharacterModels_That_Are_Available()
    {
        // Arrange
        var expected = new List<CharacterModel>
        {
            new() { Character = 'a', IsAvailable = true },
            new() { Character = 'b', IsAvailable = true },
            new() { Character = ' ', IsAvailable = true },
            new() { Character = 'c', IsAvailable = true }
        };

        // Act
        var actual = _modelBuilder.BuildModel("ab c", GetCharacterInventoryModels());

        // Assert
        actual.Should().BeEquivalentTo(expected, options => options.WithStrictOrdering());
    }

    [Test]
    public void BuildModel_With_Spaces_In_And_Unavailable_Characters_Returns_List_With_Mixed_Availability()
    {
        // Arrange
        var expected = new List<CharacterModel>
        {
            new() { Character = 'c', IsAvailable = true },
            new() { Character = 'b', IsAvailable = true },
            new() { Character = 'b', IsAvailable = false },
            new() { Character = ' ', IsAvailable = true },
            new() { Character = 'd', IsAvailable = false },
            new() { Character = ' ', IsAvailable = true },
            new() { Character = 'a', IsAvailable = true }
        };

        // Act
        var actual = _modelBuilder.BuildModel("cbb d a", GetCharacterInventoryModels());

        // Assert
        actual.Should().BeEquivalentTo(expected, options => options.WithStrictOrdering());
    }

    private List<CharacterInventoryModel> GetCharacterInventoryModels() =>
        new()
        {
            new() { Character = 'a', QuantityAvailable = 1 },
            new() { Character = 'b', QuantityAvailable = 1 },
            new() { Character = 'c', QuantityAvailable = 1 }
        };
}
