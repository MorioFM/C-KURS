namespace MyAPP.Common;

public interface IClient
{
     int ClientID { get; set; }
     string FirstName { get; set; }
     string LastName { get; set; }
     string? PhoneNumber { get; set; }
     string Adress { get; set; }
}