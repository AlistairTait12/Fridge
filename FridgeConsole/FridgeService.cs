using FridgeConsole.DataAccess;
using FridgeConsole.Models;
using FridgeConsole.Presentation;
using Microsoft.Extensions.Hosting;

namespace FridgeConsole;

public class FridgeService : IHostedService
{
    private readonly IFridgeMessageViewModelBuilder _messageViewModelBuilder;
    private readonly IFridgeMessageModelPrinter _messageModelPrinter;
    private IDataAccess<CharacterInventoryModel> _characterInventoryModel;

    public FridgeService(IFridgeMessageViewModelBuilder messageViewModelBuilder,
        IFridgeMessageModelPrinter messageModelPrinter,
        IDataAccess<CharacterInventoryModel> characterInventoryModel)
    {
        _messageViewModelBuilder = messageViewModelBuilder;
        _messageModelPrinter = messageModelPrinter;
        _characterInventoryModel = characterInventoryModel;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        var candidate = Console.ReadLine();
        var models = _characterInventoryModel.GetData();

        var viewModel = _messageViewModelBuilder.BuildModel(candidate, models.ToList());
        _messageModelPrinter.PrintMessage(viewModel.ToList());

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("application stopped");
        return Task.CompletedTask;
    }
}
