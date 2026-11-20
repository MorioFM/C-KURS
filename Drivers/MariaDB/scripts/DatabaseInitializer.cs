using MyAPP.Common;
using MySqlConnector;

namespace MyAPP.Drivers.MariaDB.Scripts;

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
        // 1. Базовые таблицы (без внешних ключей)
        new ClientsInitializer(),
        new StudyGroupsInitializer(),
        new TrainersInitializer(),
        new ClassTypesInitializer(),
        new RoomsInitializer(),

        // 2. Зависимые таблицы и связки M:N (с внешними ключами)
        new GroupMembersInitializer(),
        new TrainerSpecialitiesInitializer(),
        new RoomClassCompatibilityInitializer(),
        new ScheduleInitializer()
        
    }.ToDictionary(i => i.Id);

    /// Выполнить декомпозированную инициализацию всех таблиц в переданном подключении
    /// <param name="connection">Открытое подключение к базе данных MariaDB</param>
    public static void Initialize(MySqlConnection connection)
    {
        // Гарантируем проверку внешних ключей: базовые таблицы создаются строго до зависимых
        using (var fkOn = connection.CreateCommand())
        {
            fkOn.CommandText = "SET FOREIGN_KEY_CHECKS = 1;";
            fkOn.ExecuteNonQuery();
        }

        // Поочередная инициализация каждой таблицы строго друг за другом в заданном порядке
        foreach (var tableId in CreationOrder)
        {
            Initializers[tableId].Initialize(connection);
        }
    }

    /// Инициализировать базу данных по строке подключения
    /// <param name="connectionString">Строка подключения MariaDB (например, "Server=localhost;Database=fitness;User ID=root;Password=...")</param>
    public static void Initialize(string connectionString)
    {
        using var connection = new MySqlConnection(connectionString);
        connection.Open();
        Initialize(connection);
    }
}
