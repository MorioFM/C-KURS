using MyAPP.Common;
using MyAPP.Common.DB.IDBUnits;
using MyAPP.Drivers.MariaDB.Scripts;
using MySqlConnector;

namespace MyAPP.Drivers.MariaDB;

public class Database : IDatabase
{
    private readonly DbConnectionWrapper<MySqlConnection> _connectionWrapper;
    private bool _disposed;

    public Database(string connectionString = "Server=localhost;Database=fitness;User ID=root;Password=;")
    {
        var connection = new MySqlConnection(connectionString);
        _connectionWrapper = new DbConnectionWrapper<MySqlConnection>(connection);
    }

    public Database(MySqlConnection connection)
    {
        _connectionWrapper = new DbConnectionWrapper<MySqlConnection>(connection);
    }

    /// <summary>
    /// Предоставляет доступ к обёртке соединения для репозиториев
    /// </summary>
    public DbConnectionWrapper<MySqlConnection> Connection => _connectionWrapper;

    /// <summary>
    /// Инициализация всех таблиц базы данных в порядке декомпозиции через постоянное соединение
    /// </summary>
    public void Initialize()
    {
        _connectionWrapper.Execute(conn => DatabaseInitializer.Initialize(conn));
    }

    public IClassType ClassTypes => throw new NotImplementedException();
    public IClient Clients => throw new NotImplementedException();
    public IGroupMembers GroupMembers => throw new NotImplementedException();
    public IRoom Rooms => throw new NotImplementedException();
    public IRoomClassCompatibility RoomClassCompatibilities => throw new NotImplementedException();
    public IStudyGroup StudyGroups => throw new NotImplementedException();
    public ISсhedule Schedules => throw new NotImplementedException();
    public ITrainer Trainers => throw new NotImplementedException();
    public ITrainerSpeciality TrainerSpecialities => throw new NotImplementedException();

    public void Dispose()
    {
        if (_disposed) return;
        _disposed = true;
        _connectionWrapper.Dispose();
        GC.SuppressFinalize(this);
    }
}
