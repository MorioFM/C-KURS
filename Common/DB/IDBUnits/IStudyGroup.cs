using MyAPP.Common.DB.Entity;

namespace MyAPP.Common.DB.IDBUnits;

public interface IStudyGroup
{
    int GroupID { get; set; }
    string GroupName { get; set; }

    // Базовые CRUD-операции
    List<StudyGroup> Get();
    StudyGroup? Get(int id);
    void Post(StudyGroup item);
    void Put(int id, StudyGroup item);
    void Delete(int id);

    // Поиск группы по названию 
    StudyGroup? GetByName(string groupName);

    // Поиск групп по части названия
    List<StudyGroup> SearchByName(string searchPattern);

    // Получение учебных групп, в которых состоит клиент 
    List<StudyGroup> GetByClientId(int clientId);

    // Получение групп, с которыми работает тренер 
    List<StudyGroup> GetByTrainerId(int trainerId);

    // Проверка существования группы с указанным названием
    bool ExistsByName(string groupName);

    // Получение количества участников в группе
    int GetMembersCount(int groupId);
}