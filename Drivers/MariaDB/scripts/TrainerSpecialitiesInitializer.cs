using MyAPP.Common;
using MySqlConnector;

namespace MyAPP.Drivers.MariaDB.Scripts;

/// <summary>
/// Инициализатор таблицы TrainerSpecialities (Квалификации тренеров / связка M:N)
/// Таблица содержит внешние ключи на: Trainers, ClassTypes
/// </summary>
public class TrainerSpecialitiesInitializer : ITableInitializer
{
    public TableId Id => TableId.TrainerSpecialities;
    public string TableName => "TrainerSpecialities";

    public void Initialize(MySqlConnection connection)
    {
        const string sql = """
            CREATE TABLE IF NOT EXISTS `TrainerSpecialities` (
                `TrainerSpecialitiesID` INT NOT NULL AUTO_INCREMENT,
                `TrainerID` INT NOT NULL COMMENT 'Идентификатор тренера (FK)',
                `ClassTypesID` INT NOT NULL COMMENT 'Идентификатор типа занятия (FK)',
                PRIMARY KEY (`TrainerSpecialitiesID`),
                UNIQUE KEY `uq_trainerspecialities_trainer_class` (`TrainerID`, `ClassTypesID`),
                INDEX `idx_trainerspecialities_trainer` (`TrainerID`),
                INDEX `idx_trainerspeciality_class` (`ClassTypesID`),
                CONSTRAINT `fk_trainerspecialities_trainer` FOREIGN KEY (`TrainerID`) REFERENCES `Trainers` (`TrainerID`) ON DELETE CASCADE ON UPDATE CASCADE,
                CONSTRAINT `fk_trainerspecialities_class` FOREIGN KEY (`ClassTypesID`) REFERENCES `ClassTypes` (`ClassTypesID`) ON DELETE CASCADE ON UPDATE CASCADE
            ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='Квалификации тренеров (M:N)';
            """;

        using var command = connection.CreateCommand();
        command.CommandText = sql;
        command.ExecuteNonQuery();
    }
}
