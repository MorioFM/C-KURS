namespace MyAPP.Common;

/// Идентификаторы таблиц базы данных (задают последовательный порядок создания)
public enum TableId
{
    // 1. Базовые таблицы (без внешних ключей)
    Clients = 1,
    StudyGroups = 2,
    Trainers = 3,
    ClassTypes = 4,
    Rooms = 5,

    // 2. Зависимые таблицы и связки M:N (с внешними ключами)
    GroupMembers = 6,
    TrainerSpecialities = 7,
    RoomClassCompatibility = 8,
    Schedule = 9
}

