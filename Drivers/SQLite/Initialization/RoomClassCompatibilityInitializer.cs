using Microsoft.Data.Sqlite;
using MyAPP.Common;

namespace MyAPP.Drivers.SQLite.Initialization;

/// <summary>
/// Инициализатор таблицы RoomClassCompatibility (Совместимость залов и занятий / связка M:N)
/// Таблица содержит внешние ключи на: Rooms, ClassTypes
/// </summary>
public class RoomClassCompatibilityInitializer : ITableInitializer
{
    public TableId Id => TableId.RoomClassCompatibility;
    public string TableName => "RoomClassCompatibility";

    public void Initialize(SqliteConnection connection)
    {
        const string sql = """
            CREATE TABLE IF NOT EXISTS RoomClassCompatibility (
                RoomClassCompatibilityID INTEGER PRIMARY KEY AUTOINCREMENT,
                RoomID INTEGER NOT NULL,
                ClassTypesID INTEGER NOT NULL,
                UNIQUE (RoomID, ClassTypesID),
                FOREIGN KEY (RoomID) REFERENCES Rooms (RoomID) ON DELETE CASCADE ON UPDATE CASCADE,
                FOREIGN KEY (ClassTypesID) REFERENCES ClassTypes (ClassTypesID) ON DELETE CASCADE ON UPDATE CASCADE
            );

            CREATE INDEX IF NOT EXISTS idx_roomclass_class ON RoomClassCompatibility (ClassTypesID);
            CREATE INDEX IF NOT EXISTS idx_roomclass_room ON RoomClassCompatibility (RoomID);
            """;

        using var command = connection.CreateCommand();
        command.CommandText = sql;
        command.ExecuteNonQuery();
    }
}
