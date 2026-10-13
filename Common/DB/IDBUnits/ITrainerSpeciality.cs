using MyAPP.Common.DB.Entity;

namespace MyAPP.Common.DB.IDBUnits;

public interface ITrainerSpeciality
{
    int TrainerSpecialitiesID { get; set; }
    int TrainerID { get; set; }
    int ClassTypesID { get; set; }

    // Базовые CRUD-операции
    List<TrainerSpeciality> Get();
    TrainerSpeciality? Get(int id);
    void Post(TrainerSpeciality item);
    void Put(int id, TrainerSpeciality item);
    void Delete(int id);


    // Получение всех специальностей конкретного тренера
    List<TrainerSpeciality> GetByTrainerId(int trainerId);

    // Получение всех тренеров, закреплённых за типом занятия
    List<TrainerSpeciality> GetByClassTypeId(int classTypesId);

    // Поиск конкретной связки тренер - тип занятия
    TrainerSpeciality? GetByTrainerAndClassType(int trainerId, int classTypesId);

    // Проверка наличия квалификации у тренера на ведение типа занятия
    bool HasSpeciality(int trainerId, int classTypesId);

    // Закрепление типа занятия за тренером
    void AddSpeciality(int trainerId, int classTypesId);

    // Снятие квалификации/специальности у тренера
    void RemoveSpeciality(int trainerId, int classTypesId);
}
