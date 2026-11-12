using MyAPP.Common;
using MySqlConnector;

namespace MyAPP.Drivers.MariaDB.Scripts;

/// <summary>
/// Инициализатор таблицы Trainers (Тренеры)
/// Базовая таблица без внешних ключей
/// </summary>
public class TrainersInitializer : ITableInitializer
{
    public TableId Id => TableId.Trainers;
    public string TableName => "Trainers";

    public void Initialize(MySqlConnection connection)
    {
        const string sql = """
            CREATE TABLE IF NOT EXISTS `Trainers` (
                `TrainerID` INT NOT NULL AUTO_INCREMENT,
                `FullName` VARCHAR(100) NOT NULL COMMENT 'ФИО тренера: от 2 до 100 символов',
                `PhoneNumber` VARCHAR(20) NOT NULL COMMENT 'Номер телефона: от 7 до 20 символов',
                `PassportData` VARCHAR(30) NOT NULL COMMENT 'Паспортные данные: от 6 до 30 символов',
                `DateBirth` DATE NOT NULL COMMENT 'Дата рождения: возраст от 18 до 100 лет',
                PRIMARY KEY (`TrainerID`),
                UNIQUE KEY `uq_trainers_passport` (`PassportData`),
                INDEX `idx_trainers_phone` (`PhoneNumber`),
                INDEX `idx_trainers_fullname` (`FullName`)
            ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='Тренеры фитнес-центра';
            """;

        using var command = connection.CreateCommand();
        command.CommandText = sql;
        command.ExecuteNonQuery();
    }
}
