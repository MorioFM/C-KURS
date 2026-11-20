using Microsoft.Data.Sqlite;
using MyAPP.Common;

namespace MyAPP.Drivers.SQLite.Initialization;

/// <summary>
/// Инициализатор таблицы Trainers (Тренеры)
/// Базовая таблица без внешних ключей
/// </summary>
public class TrainersInitializer : ITableInitializer
{
    public TableId Id => TableId.Trainers;
    public string TableName => "Trainers";
    public void Initialize(SqliteConnection connection)
    {
        const string sql = """
            CREATE TABLE IF NOT EXISTS Trainers (
                TrainerID INTEGER PRIMARY KEY AUTOINCREMENT,
                FullName TEXT NOT NULL,
                PhoneNumber TEXT NOT NULL,
                PassportData TEXT NOT NULL UNIQUE,
                DateBirth TEXT NOT NULL
            );

            CREATE INDEX IF NOT EXISTS idx_trainers_phone ON Trainers (PhoneNumber);
            CREATE INDEX IF NOT EXISTS idx_trainers_fullname ON Trainers (FullName);
            """;

        using var command = connection.CreateCommand();
        command.CommandText = sql;
        command.ExecuteNonQuery();
    }
}
