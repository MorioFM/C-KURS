using MyAPP.Common;
using MySqlConnector;

namespace MyAPP.Drivers.MariaDB.Scripts;

/// <summary>
/// Инициализатор таблицы Rooms (Залы / спортивные помещения)
/// Базовая таблица без внешних ключей
/// </summary>
public class RoomsInitializer : ITableInitializer
{
    public TableId Id => TableId.Rooms;
    public string TableName => "Rooms";

    public void Initialize(MySqlConnection connection)
    {
        const string sql = """
            CREATE TABLE IF NOT EXISTS `Rooms` (
                `RoomID` INT NOT NULL AUTO_INCREMENT,
                `RoomName` VARCHAR(50) NOT NULL COMMENT 'Название зала: от 2 до 50 символов',
                `RoomType` VARCHAR(50) NOT NULL COMMENT 'Тип зала: от 2 до 50 символов',
                PRIMARY KEY (`RoomID`),
                UNIQUE KEY `uq_rooms_name` (`RoomName`),
                INDEX `idx_rooms_type` (`RoomType`)
            ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='Залы / спортивные помещения';
            """;

        using var command = connection.CreateCommand();
        command.CommandText = sql;
        command.ExecuteNonQuery();
    }
}
