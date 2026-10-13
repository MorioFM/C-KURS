using MyAPP.Common.DB.Entity;

namespace MyAPP.Common.DB.IDBUnits;

public interface IClassType
{
    int ClassTypesID { get; set; }
    string ClassName { get; set; }

    // Базовые CRUD-операции
    List<ClassType> Get();
    ClassType? Get(int id);
    void Post(ClassType item);
    void Put(int id, ClassType item);
    void Delete(int id);

    // Поиск по названию занятия (индекс ClassName на схеме БД)
    ClassType? GetByName(string className);

    // Поиск занятий по части названия
    List<ClassType> SearchByName(string searchPattern);

    // Проверка существования типа занятия по названию 
    bool ExistsByName(string className);

    // Получение типов занятий, которые ведёт тренер
    List<ClassType> GetByTrainerId(int trainerId);

    // Получение типов занятий, совместимых с залом 
    List<ClassType> GetByRoomId(int roomId);
}