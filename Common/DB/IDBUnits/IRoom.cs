using MyAPP.Common.DB.Entity;

namespace MyAPP.Common.DB.IDBUnits;

public interface IRoom
{
    int RoomID { get; set; }
    string RoomName { get; set; }
    string RoomType { get; set; }

    // Базовые CRUD-операции
    List<Room> Get();
    Room? Get(int id);
    void Post(Room item);
    void Put(int id, Room item);
    void Delete(int id);

    // Поиск зала по точному названию 
    Room? GetByName(string roomName);

    // Получение залов по типу помещения 
    List<Room> GetByType(string roomType);

    // Получение залов, совместимых с данным типом занятия 
    List<Room> GetCompatibleRooms(int classTypesId);

    // Проверка, свободен ли зал в указанную дату и слот времени
    bool IsRoomAvailable(int roomId, DateOnly day, TimeOnly timeSlot);

    // Получение списка всех залов, свободных в указанное время
    List<Room> GetAvailableRooms(DateOnly day, TimeOnly timeSlot);

    // Получение залов, которые совместимы с типом занятия и свободны на указанный слот времени
    List<Room> GetAvailableRoomsForClass(int classTypesId, DateOnly day, TimeOnly timeSlot);
}