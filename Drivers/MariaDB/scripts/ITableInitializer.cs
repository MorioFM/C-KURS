using MyAPP.Common;
using MySqlConnector;

namespace MyAPP.Drivers.MariaDB.Scripts;

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
    /// <param name="connection">Открытое подключение к MariaDB</param>
    void Initialize(MySqlConnection connection);
}
