using Microsoft.Data.Sqlite;
using MyAPP.Common;

namespace MyAPP.Drivers.SQLite.Initialization;

/// <summary>
/// Инициализатор таблицы StudyGroups (Учебные группы)
/// Базовая таблица без внешних ключей
/// </summary>
public class StudyGroupsInitializer : ITableInitializer
{
    public TableId Id => TableId.StudyGroups;
    public string TableName => "StudyGroups";

    public void Initialize(SqliteConnection connection)
    {
        const string sql = """
            CREATE TABLE IF NOT EXISTS StudyGroups (
                GroupID INTEGER PRIMARY KEY AUTOINCREMENT,
                GroupName TEXT NOT NULL UNIQUE
            );
            """;

        using var command = connection.CreateCommand();
        command.CommandText = sql;
        command.ExecuteNonQuery();
    }
}
