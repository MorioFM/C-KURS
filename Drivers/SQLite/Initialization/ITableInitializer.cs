using Microsoft.Data.Sqlite;
using MyAPP.Common;

namespace MyAPP.Drivers.SQLite.Initialization;


// Интерфейс декомпозиции инициализации отдельной таблицы базы данных

public interface ITableInitializer
{

    TableId Id { get; }

    string TableName { get; }

    /// <param name="connection">Открытое подключение к SQLite</param>
    void Initialize(SqliteConnection connection);
}
