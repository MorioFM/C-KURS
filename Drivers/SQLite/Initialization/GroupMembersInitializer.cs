using Microsoft.Data.Sqlite;
using MyAPP.Common;

namespace MyAPP.Drivers.SQLite.Initialization;

/// <summary>
/// Инициализатор таблицы GroupMembers (Состав учебных групп / связка M:N)
/// Таблица содержит внешние ключи на: StudyGroups, Clients
/// </summary>
public class GroupMembersInitializer : ITableInitializer
{
    public TableId Id => TableId.GroupMembers;
    public string TableName => "GroupMembers";

    public void Initialize(SqliteConnection connection)
    {
        const string sql = """
            CREATE TABLE IF NOT EXISTS GroupMembers (
                GroupMembersID INTEGER PRIMARY KEY AUTOINCREMENT,
                GroupID INTEGER NOT NULL,
                ClientID INTEGER NOT NULL,
                UNIQUE (GroupID, ClientID),
                FOREIGN KEY (GroupID) REFERENCES StudyGroups (GroupID) ON DELETE CASCADE ON UPDATE CASCADE,
                FOREIGN KEY (ClientID) REFERENCES Clients (ClientID) ON DELETE CASCADE ON UPDATE CASCADE
            );

            CREATE INDEX IF NOT EXISTS idx_groupmembers_client ON GroupMembers (ClientID);
            CREATE INDEX IF NOT EXISTS idx_groupmembers_group ON GroupMembers (GroupID);
            """;

        using var command = connection.CreateCommand();
        command.CommandText = sql;
        command.ExecuteNonQuery();
    }
}
