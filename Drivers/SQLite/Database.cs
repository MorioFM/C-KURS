using Microsoft.Data.Sqlite;
using MyAPP.Common;
using MyAPP.Common.DB.IDBUnits;
using MyAPP.Drivers.SQLite.Initialization;

namespace MyAPP.Drivers.SQLite;

public class Database : IDatabase
{
    private readonly DbConnectionWrapper<SqliteConnection> _connectionWrapper;
    private bool _disposed;

    public Database(string connectionString = "Data Source=fitness.db")
    {
        var connection = new SqliteConnection(connectionString);
        _connectionWrapper = new DbConnectionWrapper<SqliteConnection>(connection);
    }

    public Database(SqliteConnection connection)
    {
        _connectionWrapper = new DbConnectionWrapper<SqliteConnection>(connection);
    }

    /// <summary>
    /// Предоставляет доступ к обёртке соединения для репозиториев
    /// </summary>
    public DbConnectionWrapper<SqliteConnection> Connection => _connectionWrapper;

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
