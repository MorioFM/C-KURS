using MyAPP.Common.DB.IDBUnits;

namespace MyAPP.Common;

public interface IDatabase : IDisposable
{
    IClassType ClassTypes { get; }
    IClient Clients { get; }
    IGroupMembers GroupMembers { get; }
    IRoom Rooms { get; }
    IRoomClassCompatibility RoomClassCompatibilities { get; }
    IStudyGroup StudyGroups { get; }
    ISсhedule Schedules { get; }
    ITrainer Trainers { get; }
    ITrainerSpeciality TrainerSpecialities { get; }

    /// <summary>
    /// Инициализация схемы и таблиц базы данных
    /// </summary>
    void Initialize();
}
