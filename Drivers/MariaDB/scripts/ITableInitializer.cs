using MyAPP.Common;
using MySqlConnector;

namespace MyAPP.Drivers.MariaDB.Scripts;

/// Интерфейс декомпозиции инициализации отдельной таблицы базы данных
public interface ITableInitializer
{
    /// Идентификатор инициализируемой таблицы
    TableId Id { get; }

    /// Имя инициализируемой таблицы
    string TableName { get; }

    /// Создание таблицы и сопутствующих индексов
    /// <param name="connection">Открытое подключение к MariaDB</param>
    void Initialize(MySqlConnection connection);
}
