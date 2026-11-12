using MyAPP.Common;
using MySqlConnector;

namespace MyAPP.Drivers.MariaDB.Scripts;

/// <summary>
/// Инициализатор таблицы Schedule (Расписание занятий)
/// Таблица содержит внешние ключи на: Rooms, StudyGroups, Trainers, ClassTypes
/// </summary>
public class ScheduleInitializer : ITableInitializer
{
    public TableId Id => TableId.Schedule;
    public string TableName => "Schedule";

    public void Initialize(MySqlConnection connection)
    {
        const string sql = """
            CREATE TABLE IF NOT EXISTS `Schedule` (
                `ScheduleID` INT NOT NULL AUTO_INCREMENT,
                `Day` DATE NOT NULL COMMENT 'Дата проведения: год от 2000 до 2100',
                `TimeSlot` TIME NOT NULL COMMENT 'Время проведения занятия',
                `RoomID` INT NOT NULL COMMENT 'Идентификатор зала (FK)',
                `GroupID` INT NOT NULL COMMENT 'Идентификатор учебной группы (FK)',
                `TrainerID` INT NOT NULL COMMENT 'Идентификатор тренера (FK)',
                `ClassTypesID` INT NOT NULL COMMENT 'Идентификатор типа занятия (FK)',
                PRIMARY KEY (`ScheduleID`),
                INDEX `idx_schedule_trainer_slot` (`Day`, `TimeSlot`, `TrainerID`),
                INDEX `idx_schedule_group_slot` (`Day`, `TimeSlot`, `GroupID`),
                INDEX `idx_schedule_room_slot` (`Day`, `TimeSlot`, `RoomID`),
                INDEX `idx_schedule_date` (`Day`),
                INDEX `idx_schedule_classtypes` (`ClassTypesID`),
                CONSTRAINT `fk_schedule_room` FOREIGN KEY (`RoomID`) REFERENCES `Rooms` (`RoomID`) ON DELETE CASCADE ON UPDATE CASCADE,
                CONSTRAINT `fk_schedule_group` FOREIGN KEY (`GroupID`) REFERENCES `StudyGroups` (`GroupID`) ON DELETE CASCADE ON UPDATE CASCADE,
                CONSTRAINT `fk_schedule_trainer` FOREIGN KEY (`TrainerID`) REFERENCES `Trainers` (`TrainerID`) ON DELETE CASCADE ON UPDATE CASCADE,
                CONSTRAINT `fk_schedule_classtypes` FOREIGN KEY (`ClassTypesID`) REFERENCES `ClassTypes` (`ClassTypesID`) ON DELETE CASCADE ON UPDATE CASCADE
            ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='Расписание занятий';
            """;

        using var command = connection.CreateCommand();
        command.CommandText = sql;
        command.ExecuteNonQuery();
    }
}
