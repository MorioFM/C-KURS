using Microsoft.Data.Sqlite;
using MyAPP.Common;

namespace MyAPP.Drivers.SQLite.Initialization;

/// <summary>
/// Инициализатор таблицы ClassTypes (Типы занятий / программы фитнес-центра)
/// Базовая таблица без внешних ключей
/// </summary>
public class ClassTypesInitializer : ITableInitializer
{
    public TableId Id => TableId.ClassTypes;
    public string TableName => "ClassTypes";

    public void Initialize(SqliteConnection connection)
    {
        const string sql = """
            CREATE TABLE IF NOT EXISTS ClassTypes (
                ClassTypesID INTEGER PRIMARY KEY AUTOINCREMENT,
                ClassName TEXT NOT NULL UNIQUE
            );

            CREATE INDEX IF NOT EXISTS idx_classtypes_name ON ClassTypes (ClassName);
            """;

        using var command = connection.CreateCommand();
        command.CommandText = sql;
        command.ExecuteNonQuery();
    }
}
