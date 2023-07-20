using FridgeConsole.DataAccess;
using FridgeConsole.Models;
using FridgeConsole.Presentation;
using Microsoft.Extensions.Hosting;

namespace FridgeConsole;

public class FridgeService : IHostedService
{
    private readonly IFridgeMessageViewModelBuilder _messageViewModelBuilder;
    private readonly IFridgeMessageModelPrinter _messageModelPrinter;
    private readonly IDataAccess<CharacterInventoryModel> _characterInventoryModel;
    private readonly IConsoleWrapper _consoleWrapper;

    public FridgeService(IFridgeMessageViewModelBuilder messageViewModelBuilder,
        IFridgeMessageModelPrinter messageModelPrinter,
        IDataAccess<CharacterInventoryModel> characterInventoryModel,
        IConsoleWrapper consoleWrapper)
    {
        _messageViewModelBuilder = messageViewModelBuilder;
        _messageModelPrinter = messageModelPrinter;
        _characterInventoryModel = characterInventoryModel;
        _consoleWrapper = consoleWrapper;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        var candidate = _consoleWrapper.ReadStringFromUser();
        var models = _characterInventoryModel.GetData();

        var viewModel = _messageViewModelBuilder.BuildModel(candidate, models);
        _messageModelPrinter.PrintMessage(viewModel);

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("application stopped");
        return Task.CompletedTask;
    }
}
