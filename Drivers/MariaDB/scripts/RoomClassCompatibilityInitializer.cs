using MyAPP.Common;
using MySqlConnector;

namespace MyAPP.Drivers.MariaDB.Scripts;

/// <summary>
/// Инициализатор таблицы RoomClassCompatibility (Совместимость залов и занятий / связка M:N)
/// Таблица содержит внешние ключи на: Rooms, ClassTypes
/// </summary>
public class RoomClassCompatibilityInitializer : ITableInitializer
{
    public TableId Id => TableId.RoomClassCompatibility;
    public string TableName => "RoomClassCompatibility";

    public void Initialize(MySqlConnection connection)
    {
        const string sql = """
            CREATE TABLE IF NOT EXISTS `RoomClassCompatibility` (
                `RoomClassCompatibilityID` INT NOT NULL AUTO_INCREMENT,
                `RoomID` INT NOT NULL COMMENT 'Идентификатор зала (FK)',
                `ClassTypesID` INT NOT NULL COMMENT 'Идентификатор типа занятия (FK)',
                PRIMARY KEY (`RoomClassCompatibilityID`),
                UNIQUE KEY `uq_roomclass_room_class` (`RoomID`, `ClassTypesID`),
                INDEX `idx_roomclass_room` (`RoomID`),
                INDEX `idx_roomclass_class` (`ClassTypesID`),
                CONSTRAINT `fk_roomclass_room` FOREIGN KEY (`RoomID`) REFERENCES `Rooms` (`RoomID`) ON DELETE CASCADE ON UPDATE CASCADE,
                CONSTRAINT `fk_roomclass_class` FOREIGN KEY (`ClassTypesID`) REFERENCES `ClassTypes` (`ClassTypesID`) ON DELETE CASCADE ON UPDATE CASCADE
            ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='Совместимость залов и занятий (M:N)';
            """;

        using var command = connection.CreateCommand();
        command.CommandText = sql;
        command.ExecuteNonQuery();
    }
}
