using Microsoft.Data.Sqlite;
using MyAPP.Common;

namespace MyAPP.Drivers.SQLite.Initialization;

/// <summary>
/// Инициализатор таблицы Rooms (Залы / спортивные помещения)
/// Базовая таблица без внешних ключей
/// </summary>
public class RoomsInitializer : ITableInitializer
{
    public TableId Id => TableId.Rooms;
    public string TableName => "Rooms";

    public void Initialize(SqliteConnection connection)
    {
        const string sql = """
            CREATE TABLE IF NOT EXISTS Rooms (
                RoomID INTEGER PRIMARY KEY AUTOINCREMENT,
                RoomName TEXT NOT NULL UNIQUE,
                RoomType TEXT NOT NULL
            );

            CREATE INDEX IF NOT EXISTS idx_rooms_type ON Rooms (RoomType);
            """;

        using var command = connection.CreateCommand();
        command.CommandText = sql;
        command.ExecuteNonQuery();
    }
}
