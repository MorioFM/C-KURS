using MyAPP.Common;
using MySqlConnector;

namespace MyAPP.Drivers.MariaDB.Scripts;

/// <summary>
/// Инициализатор таблицы Clients (Клиенты фитнес-центра)
/// Базовая таблица без внешних ключей
/// </summary>
public class ClientsInitializer : ITableInitializer
{
    public TableId Id => TableId.Clients;
    public string TableName => "Clients";

    public void Initialize(MySqlConnection connection)
    {
        const string sql = """
            CREATE TABLE IF NOT EXISTS `Clients` (
                `ClientID` INT NOT NULL AUTO_INCREMENT,
                `FullName` VARCHAR(100) NOT NULL COMMENT 'ФИО клиента: от 2 до 100 символов',
                `PhoneNumber` VARCHAR(20) DEFAULT NULL COMMENT 'Номер телефона (nullable): от 7 до 20 символов',
                `Adress` VARCHAR(100) NOT NULL COMMENT 'Адрес проживания: от 5 до 100 символов',
                PRIMARY KEY (`ClientID`),
                INDEX `idx_clients_phone` (`PhoneNumber`),
                INDEX `idx_clients_fullname` (`FullName`)
            ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='Клиенты фитнес-центра';
            """;

        using var command = connection.CreateCommand();
        command.CommandText = sql;
        command.ExecuteNonQuery();
    }
}
