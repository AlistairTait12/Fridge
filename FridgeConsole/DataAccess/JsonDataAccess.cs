using Microsoft.Extensions.Options;

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
        throw new NotImplementedException();
    }
}
