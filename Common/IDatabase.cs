using MyAPP.Common.DB.IDBUnits;

namespace MyAPP.Common;

public interface IDatabase
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
}
