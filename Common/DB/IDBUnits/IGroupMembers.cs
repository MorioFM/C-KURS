using MyAPP.Common.DB.Entity;

namespace MyAPP.Common.DB.IDBUnits;

public interface IGroupMembers
{
    int GroupMembersID { get; set; }
    int GroupID { get; set; }
    int ClientID { get; set; }

    // Базовые CRUD-операции
    List<GroupMembers> Get();
    GroupMembers? Get(int id);
    void Post(GroupMembers item);
    void Put(int id, GroupMembers item);
    void Delete(int id);

    // Получение участников конкретной группы
    List<GroupMembers> GetByGroupId(int groupId);

    // Получение групп, в которых состоит клиент
    List<GroupMembers> GetByClientId(int clientId);

    // Поиск конкретной записи о членстве клиента в группе
    GroupMembers? GetByGroupAndClient(int groupId, int clientId);

    // Проверка, состоит ли клиент в группе
    bool IsClientInGroup(int groupId, int clientId);

    // Добавление клиента в группу
    void AddClientToGroup(int groupId, int clientId);

    // Удаление клиента из группы
    void RemoveClientFromGroup(int groupId, int clientId);

    // Количество участников в группе
    int GetCountByGroupId(int groupId);
}