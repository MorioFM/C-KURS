using MyAPP.Common;
using MySqlConnector;

namespace MyAPP.Drivers.MariaDB.Scripts;

/// <summary>
/// Инициализатор таблицы GroupMembers (Состав учебных групп / связка M:N)
/// Таблица содержит внешние ключи на: StudyGroups, Clients
/// </summary>
public class GroupMembersInitializer : ITableInitializer
{
    public TableId Id => TableId.GroupMembers;
    public string TableName => "GroupMembers";

    public void Initialize(MySqlConnection connection)
    {
        const string sql = """
            CREATE TABLE IF NOT EXISTS `GroupMembers` (
                `GroupMembersID` INT NOT NULL AUTO_INCREMENT,
                `GroupID` INT NOT NULL COMMENT 'Идентификатор учебной группы (FK)',
                `ClientID` INT NOT NULL COMMENT 'Идентификатор клиента (FK)',
                PRIMARY KEY (`GroupMembersID`),
                UNIQUE KEY `uq_groupmembers_group_client` (`GroupID`, `ClientID`),
                INDEX `idx_groupmembers_group` (`GroupID`),
                INDEX `idx_groupmembers_client` (`ClientID`),
                CONSTRAINT `fk_groupmembers_group` FOREIGN KEY (`GroupID`) REFERENCES `StudyGroups` (`GroupID`) ON DELETE CASCADE ON UPDATE CASCADE,
                CONSTRAINT `fk_groupmembers_client` FOREIGN KEY (`ClientID`) REFERENCES `Clients` (`ClientID`) ON DELETE CASCADE ON UPDATE CASCADE
            ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='Состав учебных групп (M:N)';
            """;

        using var command = connection.CreateCommand();
        command.CommandText = sql;
        command.ExecuteNonQuery();
    }
}
