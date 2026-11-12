using Microsoft.Data.Sqlite;
using MyAPP.Common;

namespace MyAPP.Drivers.SQLite.Initialization;

/// <summary>
/// Инициализатор таблицы TrainerSpecialities (Квалификации тренеров / связка M:N)
/// Таблица содержит внешние ключи на: Trainers, ClassTypes
/// </summary>
public class TrainerSpecialitiesInitializer : ITableInitializer
{
    public TableId Id => TableId.TrainerSpecialities;
    public string TableName => "TrainerSpecialities";

    public void Initialize(SqliteConnection connection)
    {
        const string sql = """
            CREATE TABLE IF NOT EXISTS TrainerSpecialities (
                TrainerSpecialitiesID INTEGER PRIMARY KEY AUTOINCREMENT,
                TrainerID INTEGER NOT NULL,
                ClassTypesID INTEGER NOT NULL,
                UNIQUE (TrainerID, ClassTypesID),
                FOREIGN KEY (TrainerID) REFERENCES Trainers (TrainerID) ON DELETE CASCADE ON UPDATE CASCADE,
                FOREIGN KEY (ClassTypesID) REFERENCES ClassTypes (ClassTypesID) ON DELETE CASCADE ON UPDATE CASCADE
            );

            CREATE INDEX IF NOT EXISTS idx_trainerspeciality_class ON TrainerSpecialities (ClassTypesID);
            CREATE INDEX IF NOT EXISTS idx_trainerspeciality_trainer ON TrainerSpecialities (TrainerID);
            """;

        using var command = connection.CreateCommand();
        command.CommandText = sql;
        command.ExecuteNonQuery();
    }
}
