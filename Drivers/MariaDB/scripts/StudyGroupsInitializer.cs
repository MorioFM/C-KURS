using MyAPP.Common;
using MySqlConnector;

namespace MyAPP.Drivers.MariaDB.Scripts;

/// <summary>
/// Инициализатор таблицы StudyGroups (Учебные группы)
/// Базовая таблица без внешних ключей
/// </summary>
public class StudyGroupsInitializer : ITableInitializer
{
    public TableId Id => TableId.StudyGroups;
    public string TableName => "StudyGroups";

    public void Initialize(MySqlConnection connection)
    {
        const string sql = """
            CREATE TABLE IF NOT EXISTS `StudyGroups` (
                `GroupID` INT NOT NULL AUTO_INCREMENT,
                `GroupName` VARCHAR(50) NOT NULL COMMENT 'Название группы: от 2 до 50 символов',
                PRIMARY KEY (`GroupID`),
                UNIQUE KEY `uq_studygroups_name` (`GroupName`)
            ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='Учебные группы';
            """;

        using var command = connection.CreateCommand();
        command.CommandText = sql;
        command.ExecuteNonQuery();
    }
}
