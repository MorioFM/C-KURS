using MyAPP.Common;
using MyAPP.Common.DB.IDBUnits;
using MyAPP.Drivers.SQLite.Initialization;

namespace MyAPP.Drivers.SQLite;

public class Database : IDatabase
{
    private readonly string _connectionString;

    public Database(string connectionString = "Data Source=fitness.db")
    {
        _connectionString = connectionString;
    }

    /// <summary>
    /// Инициализация всех таблиц базы данных в порядке декомпозиции
    /// </summary>
    public void Initialize()
    {
        DatabaseInitializer.Initialize(_connectionString);
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
}
