using MyAPP.Common.DB.Entity;

namespace MyAPP.Common.DB.IDBUnits;

public interface IClient
{
    int ClientID { get; set; }
    string FirstName { get; set; }
    string LastName { get; set; }
    string? PhoneNumber { get; set; }
    string Adress { get; set; }

    // Базовые CRUD-операции
    List<Client> Get();
    Client? Get(int id);
    void Post(Client item);
    void Put(int id, Client item);
    void Delete(int id);

    // Поиск клиента по номеру телефона 
    Client? GetByPhoneNumber(string phoneNumber);

    // Поиск клиентов по ФИО 
    List<Client> SearchByFullName(string fullName);

    // Получение клиентов, состоящих в учебной группе
    List<Client> GetByGroupId(int groupId);

    // Проверка существования клиента по ID
    bool Exists(int clientId);
}