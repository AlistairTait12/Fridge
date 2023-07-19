using FakeItEasy;
using FridgeConsole.Models;
using FridgeConsole.Presentation;
using System.Diagnostics.CodeAnalysis;

namespace FridgeConsoleTests.PresentationTests;

[ExcludeFromCodeCoverage]
[TestFixture]
public class FridgeMessageModelPrinterTests
{
    private FridgeMessageModelPrinter _printer;
    private IConsoleWrapper _consoleWrapper;

    [SetUp]
    public void SetUp()
    {
        _consoleWrapper = A.Fake<IConsoleWrapper>();
        _printer = new(_consoleWrapper);
    }

    [Test]
    public void PrintMessage_With_All_Unavailable_Chars_Prints_All_In_Red()
    {
        // Arrange
        var viewModel = new List<CharacterModel>
        {
            new() { Character = 'a', IsAvailable = false },
            new() { Character = 'b', IsAvailable = false },
            new() { Character = 'c', IsAvailable = false }
        };

        // Act
        _printer.PrintMessage(viewModel);

        // Assert
        A.CallTo(() => _consoleWrapper.PrintCharacter('a', ConsoleColor.Red)).MustHaveHappenedOnceExactly();
        A.CallTo(() => _consoleWrapper.PrintCharacter('b', ConsoleColor.Red)).MustHaveHappenedOnceExactly();
        A.CallTo(() => _consoleWrapper.PrintCharacter('c', ConsoleColor.Red)).MustHaveHappenedOnceExactly();
    }

    [Test]
    public void PrintMessage_With_All_Available_Chars_Prints_All_In_Green()
    {
        // Arrange
        var viewModel = new List<CharacterModel>
        {
            new() { Character = 'a', IsAvailable = true },
            new() { Character = 'b', IsAvailable = true },
            new() { Character = 'c', IsAvailable = true }
        };

        // Act
        _printer.PrintMessage(viewModel);

        // Assert
        A.CallTo(() => _consoleWrapper.PrintCharacter('a', ConsoleColor.Green)).MustHaveHappenedOnceExactly();
        A.CallTo(() => _consoleWrapper.PrintCharacter('b', ConsoleColor.Green)).MustHaveHappenedOnceExactly();
        A.CallTo(() => _consoleWrapper.PrintCharacter('c', ConsoleColor.Green)).MustHaveHappenedOnceExactly();
    }

    [Test]
    public void PrintMessage_With_Chars_Of_Varying_Availability_Prints_Message_In_Green_And_Red()
    {
        // Arrange
        var viewModel = new List<CharacterModel>
        {
            new() { Character = 'd', IsAvailable = true },
            new() { Character = 'e', IsAvailable = false },
            new() { Character = 'f', IsAvailable = true }
        };

        // Act
        _printer.PrintMessage(viewModel);

        // Assert
        A.CallTo(() => _consoleWrapper.PrintCharacter('d', ConsoleColor.Green)).MustHaveHappenedOnceExactly();
        A.CallTo(() => _consoleWrapper.PrintCharacter('e', ConsoleColor.Red)).MustHaveHappenedOnceExactly();
        A.CallTo(() => _consoleWrapper.PrintCharacter('f', ConsoleColor.Green)).MustHaveHappenedOnceExactly();
    }
}
