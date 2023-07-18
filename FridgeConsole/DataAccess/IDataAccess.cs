namespace FridgeConsole.DataAccess;

public interface IDataAccess<T>
{
    IEnumerable<T> GetData();
}
