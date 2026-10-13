using MyAPP.Common;

namespace MyAPP.Common.DB.Entity;

public class TrainerSpeciality
{
    // Поля и ограничения данных
    private int trainerSpecialitiesID;
    private int trainerID;
    private int classTypesID;

    // Свойства 
    public int TrainerSpecialitiesID
    {
        get
        {
            return trainerSpecialitiesID;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Некорректный TrainerSpecialitiesID! Идентификатор не может быть отрицательным.");
            }
            trainerSpecialitiesID = value;
        }
    }

    public int TrainerID
    {
        get
        {
            return trainerID;
        }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Некорректный TrainerID! Идентификатор тренера должен быть больше 0.");
            }
            trainerID = value;
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
