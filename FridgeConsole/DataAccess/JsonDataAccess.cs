using Microsoft.Extensions.Options;
using System.Text.Json;

namespace FridgeConsole.DataAccess;

public class JsonDataAccess<T> : IDataAccess<T>
{
    private readonly IOptions<DataAccessOptions> _options;

    public JsonDataAccess(IOptions<DataAccessOptions> options)
    {
        _options = options;
    }

    public IEnumerable<T> GetData()
    {
        var json = File.ReadAllText(_options.Value.FilePath);
        var models = JsonSerializer.Deserialize<IEnumerable<T>>(json);
        return models;
    }
}
