using MyAPP.Common;

namespace MyAPP.Common.DB.Entity;

public class Sсhedule
{
    // Поля и ограничения данных
    private int scheduleID;

    // Ограничение даты занятия: диапазон допустимых годов в БД (от 2000 до 2100)
    private const int minYear = 2000;
    private const int maxYear = 2100;
    private DateOnly day = DateOnly.FromDateTime(DateTime.Today);

    // Ограничение времени занятия: рабочие часы заведения (с 06:00 до 23:00)
    private static readonly TimeOnly minTimeSlot = new TimeOnly(6, 0);
    private static readonly TimeOnly maxTimeSlot = new TimeOnly(23, 0);
    private TimeOnly timeSlot = new TimeOnly(8, 0);

    // Внешние ключи БД 
    private int roomID;
    private int groupID;
    private int trainerID;
    private int classTypesID;

    // Свойства 
    public int ScheduleID
    {
        get
        {
            return scheduleID;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Некорректный ScheduleID! Идентификатор расписания не может быть отрицательным.");
            }
            scheduleID = value;
        }
    }

    public DateOnly Day
    {
        get
        {
            return day;
        }
        set
        {
            if (value.Year < minYear || value.Year > maxYear)
            {
                throw new ArgumentException($"Некорректная дата! Год занятия должен быть в диапазоне от {minYear} до {maxYear}.");
            }
            day = value;
        }
    }

    public TimeOnly TimeSlot
    {
        get
        {
            return timeSlot;
        }
        set
        {
            if (value < minTimeSlot || value > maxTimeSlot)
            {
                throw new ArgumentException("Некорректное время занятия! Время должно быть в пределах от 06:00 до 23:00.");
            }
            timeSlot = value;
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

    public int GroupID
    {
        get
        {
            return groupID;
        }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Некорректный GroupID! Идентификатор группы должен быть больше 0.");
            }
            groupID = value;
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
