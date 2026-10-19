using MyAPP.Common;
using MyAPP.Common.DB.IDBUnits;

namespace MyAPP.Drivers;

public class Database : IDatabase
{
    public IClassType ClassTypes => throw new NotImplementedException();
    public IClient Clients => throw new NotImplementedException();
    public IGroupMembers GroupMembers => throw new NotImplementedException();
    public IRoom Rooms => throw new NotImplementedException();
    public IRoomClassCompatibility RoomClassCompatibilities => throw new NotImplementedException();
    public IStudyGroup StudyGroups => throw new NotImplementedException();
    public ISсhedule Schedules => throw new NotImplementedException();
    public ITrainer Trainers => throw new NotImplementedException();
    public ITrainerSpeciality TrainerSpecialities => throw new NotImplementedException();
}
