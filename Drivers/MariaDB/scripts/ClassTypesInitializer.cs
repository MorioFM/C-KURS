using MyAPP.Common;
using MySqlConnector;

namespace MyAPP.Drivers.MariaDB.Scripts;

/// <summary>
/// Инициализатор таблицы ClassTypes (Типы занятий / программы фитнес-центра)
/// Базовая таблица без внешних ключей
/// </summary>
public class ClassTypesInitializer : ITableInitializer
{
    public TableId Id => TableId.ClassTypes;
    public string TableName => "ClassTypes";

    public void Initialize(MySqlConnection connection)
    {
        const string sql = """
            CREATE TABLE IF NOT EXISTS `ClassTypes` (
                `ClassTypesID` INT NOT NULL AUTO_INCREMENT,
                `ClassName` VARCHAR(50) NOT NULL COMMENT 'Название типа занятия: от 2 до 50 символов',
                PRIMARY KEY (`ClassTypesID`),
                UNIQUE KEY `uq_classtypes_name` (`ClassName`),
                INDEX `idx_classtypes_name` (`ClassName`)
            ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='Типы занятий / программы фитнес-центра';
            """;

        using var command = connection.CreateCommand();
        command.CommandText = sql;
        command.ExecuteNonQuery();
    }
}
