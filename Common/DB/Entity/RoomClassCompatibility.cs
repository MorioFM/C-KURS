using MyAPP.Common;

namespace MyAPP.Common.DB.Entity;

public class RoomClassCompatibility
{
    // Поля и ограничения данных
    private int roomClassCompatibilityID;
    private int roomID;
    private int classTypesID;

    // Свойства 
    public int RoomClassCompatibilityID
    {
        get
        {
            return roomClassCompatibilityID;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Некорректный RoomClassCompatibilityID! Идентификатор не может быть отрицательным.");
            }
            roomClassCompatibilityID = value;
        }
    }

    public int RoomID
    {
        get
        {
            return roomID;
        }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Некорректный RoomID! Идентификатор зала должен быть больше 0.");
            }
            roomID = value;
        }
    }

    public int ClassTypesID
    {
        get
        {
            return classTypesID;
        }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Некорректный ClassTypesID! Идентификатор типа занятия должен быть больше 0.");
            }
            classTypesID = value;
        }
    }
}
