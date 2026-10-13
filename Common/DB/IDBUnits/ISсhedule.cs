using MyAPP.Common.DB.Entity;

namespace MyAPP.Common.DB.IDBUnits;

public interface ISсhedule
{
    int ScheduleID { get; set; }
    DateOnly Day { get; set; }
    TimeOnly TimeSlot { get; set; }
    int RoomID { get; set; }
    int GroupID { get; set; }
    int TrainerID { get; set; }
    int ClassTypesID { get; set; }

    // Базовые CRUD-операции
    List<Sсhedule> Get();
    Sсhedule? Get(int id);
    void Post(Sсhedule item);
    void Put(int id, Sсhedule item);
    void Delete(int id);


    // Поиск по составному индексу [Day, TimeSlot, TrainerID] (занятие тренера в указанный слот)
    Sсhedule? GetByTrainerSlot(DateOnly day, TimeOnly timeSlot, int trainerId);

    // Проверка занятости тренера на слот (по составному индексу [Day, TimeSlot, TrainerID])
    bool IsTrainerBusy(DateOnly day, TimeOnly timeSlot, int trainerId);

    // Поиск по составному индексу [Day, TimeSlot, GroupID] (занятие группы в указанный слот)
    Sсhedule? GetByGroupSlot(DateOnly day, TimeOnly timeSlot, int groupId);

    // Проверка занятости группы на слот (по составному индексу [Day, TimeSlot, GroupID])
    bool IsGroupBusy(DateOnly day, TimeOnly timeSlot, int groupId);

    // Проверка занятости зала на слот (предотвращение коллизий по RoomID, Day, TimeSlot)
    bool IsRoomOccupied(DateOnly day, TimeOnly timeSlot, int roomId);

    // Выборки по датам
    // Получение всех занятий на конкретную дату
    List<Sсhedule> GetByDate(DateOnly day);

    // Получение расписания за диапазон дат (неделя, месяц)
    List<Sсhedule> GetByDateRange(DateOnly startDate, DateOnly endDate);

    // Выборки по внешним ключам (FK)
    // Расписание конкретного тренера
    List<Sсhedule> GetByTrainerId(int trainerId);

    // Расписание тренера на конкретный день
    List<Sсhedule> GetByTrainerAndDate(int trainerId, DateOnly day);

    // Расписание конкретной группы
    List<Sсhedule> GetByGroupId(int groupId);

    // Расписание группы на конкретный день
    List<Sсhedule> GetByGroupAndDate(int groupId, DateOnly day);

    // Расписание конкретного зала
    List<Sсhedule> GetByRoomId(int roomId);

    // Расписание занятий в зале на конкретный день
    List<Sсhedule> GetByRoomAndDate(int roomId, DateOnly day);

    // Расписание занятий по типу занятия
    List<Sсhedule> GetByClassTypeId(int classTypesId);
}