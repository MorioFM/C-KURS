namespace MyAPP.Common;

public interface IShedule
{
     int ScheduleID { get; set; }
     DateOnly Day { get; set; }
     TimeOnly TimeSlot { get; set; }
     int RoomID { get; set; }
     int GroupID { get; set; }
     int TrainerID { get; set; }
     int ClassTypesID { get; set; } 
}