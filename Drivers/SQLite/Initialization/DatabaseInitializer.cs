using Microsoft.Data.Sqlite;
using MyAPP.Common;

namespace MyAPP.Drivers.SQLite.Initialization;

public static class DatabaseInitializer
{
    // Строгий порядок создания таблиц: сначала базовые, затем зависимые с FK
    private static readonly TableId[] CreationOrder =
    {
        TableId.Clients,
        TableId.StudyGroups,
        TableId.Trainers,
        TableId.ClassTypes,
        TableId.Rooms,
        TableId.GroupMembers,
        TableId.TrainerSpecialities,
        TableId.RoomClassCompatibility,
        TableId.Schedule
    };

    // Идентифицированная коллекция инициализаторов по TableId
    private static readonly Dictionary<TableId, ITableInitializer> Initializers = new ITableInitializer[]
    {
        // 1. Базовые таблицы (справочники)
        new ClientsInitializer(),
        new StudyGroupsInitializer(),
        new TrainersInitializer(),
        new ClassTypesInitializer(),
        new RoomsInitializer(),

        // 2. Таблицы связей (M:N) и зависимые сущности
        new GroupMembersInitializer(),
        new TrainerSpecialitiesInitializer(),
        new RoomClassCompatibilityInitializer(),
        new ScheduleInitializer()
    }.ToDictionary(i => i.Id);

    public static void Initialize(SqliteConnection connection)
    {
        // Включаем контроль FK до начала транзакции: базовые таблицы создаются строго до зависимых
        using (var pragmaOn = connection.CreateCommand())
        {
            pragmaOn.CommandText = "PRAGMA foreign_keys = ON;";
            pragmaOn.ExecuteNonQuery();
        }

        using var transaction = connection.BeginTransaction();

        // Поочередная инициализация каждой таблицы строго друг за другом в заданном порядке
        foreach (var tableId in CreationOrder)
        {
            Initializers[tableId].Initialize(connection);
        }

        transaction.Commit();
    }

    public static void Initialize(string connectionString)
    {
        using var connection = new SqliteConnection(connectionString);
        connection.Open();
        Initialize(connection);
    }
}
