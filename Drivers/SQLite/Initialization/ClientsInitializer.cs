using Microsoft.Data.Sqlite;
using MyAPP.Common;

namespace MyAPP.Drivers.SQLite.Initialization;

/// <summary>
/// Инициализатор таблицы Clients (Клиенты фитнес-центра)
/// Базовая таблица без внешних ключей
/// </summary>
public class ClientsInitializer : ITableInitializer
{
    public TableId Id => TableId.Clients;
    public string TableName => "Clients";

    public void Initialize(SqliteConnection connection)
    {
        const string sql = """
            CREATE TABLE IF NOT EXISTS Clients (
                ClientID INTEGER PRIMARY KEY AUTOINCREMENT,
                FullName TEXT NOT NULL,
                PhoneNumber TEXT,
                Adress TEXT NOT NULL
            );

            CREATE INDEX IF NOT EXISTS idx_clients_phone ON Clients (PhoneNumber);
            CREATE INDEX IF NOT EXISTS idx_clients_fullname ON Clients (FullName);
            """;

        using var command = connection.CreateCommand();
        command.CommandText = sql;
        command.ExecuteNonQuery();
    }
}
