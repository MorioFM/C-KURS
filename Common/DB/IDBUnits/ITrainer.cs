using MyAPP.Common.DB.Entity;

namespace MyAPP.Common.DB.IDBUnits;

public interface ITrainer
{
    int TrainerID { get; set; }
    string FullName { get; set; }
    string PhoneNumber { get; set; }
    string PassportData { get; set; }
    DateTime DateBirth { get; set; }

    // Базовые CRUD-операции
    List<Trainer> Get();
    Trainer? Get(int id);
    void Post(Trainer item);
    void Put(int id, Trainer item);
    void Delete(int id);

    // Поиск тренера по номеру телефона 
    Trainer? GetByPhoneNumber(string phoneNumber);

    // Поиск тренера по паспортным данным 
    Trainer? GetByPassportData(string passportData);

    // Поиск тренеров по ФИО 
    List<Trainer> SearchByFullName(string fullName);

    // Получение тренеров, проводящих конкретный тип занятия 
    List<Trainer> GetByClassTypeId(int classTypesId);

    // Получение тренеров, работающих с указанной группой 
    List<Trainer> GetByGroupId(int groupId);

    // Проверка доступности тренера на слот (соответствует индексу Schedule: Day, TimeSlot, TrainerID)
    bool IsTrainerAvailable(int trainerId, DateOnly day, TimeOnly timeSlot);

    // Получение списка тренеров, свободных в указанный день и время
    List<Trainer> GetAvailableTrainers(DateOnly day, TimeOnly timeSlot);
}