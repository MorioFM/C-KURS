using Microsoft.Data.Sqlite;
using MyAPP.Common;

namespace MyAPP.Drivers.SQLite.Initialization;

/// <summary>
/// Интерфейс декомпозиции инициализации отдельной таблицы базы данных
/// </summary>
public interface ITableInitializer
{
    /// <summary>
    /// Идентификатор инициализируемой таблицы
    /// </summary>
    TableId Id { get; }

    /// <summary>
    /// Имя инициализируемой таблицы
    /// </summary>
    string TableName { get; }

    /// <summary>
    /// Создание таблицы и сопутствующих индексов
    /// </summary>
    /// <param name="connection">Открытое подключение к SQLite</param>
    void Initialize(SqliteConnection connection);
}
