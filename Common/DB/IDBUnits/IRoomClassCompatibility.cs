using MyAPP.Common.DB.Entity;

namespace MyAPP.Common.DB.IDBUnits;

public interface IRoomClassCompatibility
{
    int RoomClassCompatibilityID { get; set; }
    int RoomID { get; set; }
    int ClassTypesID { get; set; }

    // Базовые CRUD-операции
    List<RoomClassCompatibility> Get();
    RoomClassCompatibility? Get(int id);
    void Post(RoomClassCompatibility item);
    void Put(int id, RoomClassCompatibility item);
    void Delete(int id);

    // Получение всех совместимостей для конкретного зала
    List<RoomClassCompatibility> GetByRoomId(int roomId);

    // Получение всех залов, совместимых с данным типом занятия
    List<RoomClassCompatibility> GetByClassTypeId(int classTypesId);

    // Поиск конкретной связки зал - тип занятия
    RoomClassCompatibility? GetByRoomAndClassType(int roomId, int classTypesId);

    // Проверка совместимости зала с типом занятия
    bool IsCompatible(int roomId, int classTypesId);

    // Добавление совместимости зала и типа занятия
    void AddCompatibility(int roomId, int classTypesId);

    // Удаление совместимости зала и типа занятия
    void RemoveCompatibility(int roomId, int classTypesId);
}