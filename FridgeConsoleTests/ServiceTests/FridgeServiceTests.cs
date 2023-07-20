using FakeItEasy;
using FridgeConsole;
using FridgeConsole.DataAccess;
using FridgeConsole.Models;
using FridgeConsole.Presentation;
using System.Diagnostics.CodeAnalysis;

namespace FridgeConsoleTests.ServiceTests;

[ExcludeFromCodeCoverage]
[TestFixture]
public class FridgeServiceTests
{
    private IFridgeMessageViewModelBuilder _messageViewModelBuilder;
    private IFridgeMessageModelPrinter _messageModelPrinter;
    private IDataAccess<CharacterInventoryModel> _dataAccess;
    private IConsoleWrapper _consoleWrapper;
    private FridgeService _service;

    [SetUp]
    public void SetUp()
    {
        _messageViewModelBuilder = A.Fake<IFridgeMessageViewModelBuilder>();
        _messageModelPrinter = A.Fake<IFridgeMessageModelPrinter>();
        _dataAccess = A.Fake<IDataAccess<CharacterInventoryModel>>();
        _consoleWrapper = A.Fake<IConsoleWrapper>();

        _service = new(_messageViewModelBuilder, _messageModelPrinter, _dataAccess, _consoleWrapper);
    }

    [Test]
    public void StartAsync_Makes_The_Right_Method_Calls()
    {
        // Arrange
        var data = new List<CharacterInventoryModel>();
        var model = new List<CharacterModel>();

        A.CallTo(() => _consoleWrapper.ReadStringFromUser()).Returns("Jeff");
        A.CallTo(() => _dataAccess.GetData()).Returns(data);
        A.CallTo(() => _messageViewModelBuilder.BuildModel("Jeff", data)).Returns(model);

        // Act
        _service.StartAsync(new());

        // Assert
        A.CallTo(() => _dataAccess.GetData()).MustHaveHappenedOnceExactly();
        A.CallTo(() => _messageViewModelBuilder.BuildModel("Jeff", A<List<CharacterInventoryModel>>.Ignored))
            .MustHaveHappenedOnceExactly();
        A.CallTo(() => _messageModelPrinter.PrintMessage(A<List<CharacterModel>>.Ignored)).MustHaveHappenedOnceExactly();
    }
}
