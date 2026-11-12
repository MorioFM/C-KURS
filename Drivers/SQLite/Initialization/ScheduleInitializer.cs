using Microsoft.Data.Sqlite;
using MyAPP.Common;

namespace MyAPP.Drivers.SQLite.Initialization;

/// <summary>
/// Инициализатор таблицы Schedule (Расписание занятий)
/// Таблица содержит внешние ключи на: Rooms, StudyGroups, Trainers, ClassTypes
/// </summary>
public class ScheduleInitializer : ITableInitializer
{
    public TableId Id => TableId.Schedule;
    public string TableName => "Schedule";

    public void Initialize(SqliteConnection connection)
    {
        const string sql = """
            CREATE TABLE IF NOT EXISTS Schedule (
                ScheduleID INTEGER PRIMARY KEY AUTOINCREMENT,
                Day TEXT NOT NULL,
                TimeSlot TEXT NOT NULL,
                RoomID INTEGER NOT NULL,
                GroupID INTEGER NOT NULL,
                TrainerID INTEGER NOT NULL,
                ClassTypesID INTEGER NOT NULL,
                FOREIGN KEY (RoomID) REFERENCES Rooms (RoomID) ON DELETE CASCADE ON UPDATE CASCADE,
                FOREIGN KEY (GroupID) REFERENCES StudyGroups (GroupID) ON DELETE CASCADE ON UPDATE CASCADE,
                FOREIGN KEY (TrainerID) REFERENCES Trainers (TrainerID) ON DELETE CASCADE ON UPDATE CASCADE,
                FOREIGN KEY (ClassTypesID) REFERENCES ClassTypes (ClassTypesID) ON DELETE CASCADE ON UPDATE CASCADE
            );

            CREATE INDEX IF NOT EXISTS idx_schedule_trainer_slot ON Schedule (Day, TimeSlot, TrainerID);
            CREATE INDEX IF NOT EXISTS idx_schedule_group_slot ON Schedule (Day, TimeSlot, GroupID);
            CREATE INDEX IF NOT EXISTS idx_schedule_room_slot ON Schedule (Day, TimeSlot, RoomID);
            CREATE INDEX IF NOT EXISTS idx_schedule_date ON Schedule (Day);
            CREATE INDEX IF NOT EXISTS idx_schedule_classtypes ON Schedule (ClassTypesID);
            """;

        using var command = connection.CreateCommand();
        command.CommandText = sql;
        command.ExecuteNonQuery();
    }
}
