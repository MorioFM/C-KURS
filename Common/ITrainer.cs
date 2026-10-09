namespace MyAPP.Common;

public interface ITrainer
{
     int TrainerID { get; set; }
     string FullName { get; set; }
     string PhoneNumber { get; set; }
     string PassportData { get; set; }
     DateTime DateBirth { get; set; }
}