using System.Text.RegularExpressions;
using MyAPP.Common;

namespace MyAPP.Common.DB.Entity;

public class Trainer
{
    // Поля и ограничения данных
    private int trainerID;

    private string fullName = string.Empty;
    // ФИО тренера: буквы (рус/англ), дефис, точка и пробелы, от 2 до 100 символов
    private const string fullNamePattern = @"^[А-Яа-яЁёA-Za-z\s.\-]{2,100}$";

    private string phoneNumber = string.Empty;
    // Телефон: плюс, цифры, скобки, пробелы и тире, от 7 до 20 символов
    private const string phoneNumberPattern = @"^\+?[0-9\s\-\(\)]{7,20}$";

    private string passportData = string.Empty;
    // Паспортные данные: серия и номер (буквы, цифры, дефис, пробелы), от 6 до 30 символов
    private const string passportDataPattern = @"^[А-Яа-яЁёA-Za-z0-9\s\-]{6,30}$";

    private DateTime dateBirth = DateTime.Today.AddYears(-25);

    // Свойства 
    public int TrainerID
    {
        get
        {
            return trainerID;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Некорректный TrainerID! Идентификатор тренера не может быть отрицательным.");
            }
            trainerID = value;
        }
    }

    public string FullName
    {
        get
        {
            return fullName;
        }
        set
        {
            Regex regex = new Regex(fullNamePattern);
            if (regex.IsMatch(value))
            {
                fullName = value;
            }
            else
            {
                throw new ArgumentException("Некорректное ФИО тренера! Допустимы буквы, пробелы, дефисы и точки от 2 до 100 символов.");
            }
        }
    }

    public string PhoneNumber
    {
        get
        {
            return phoneNumber;
        }
        set
        {
            Regex regex = new Regex(phoneNumberPattern);
            if (regex.IsMatch(value))
            {
                phoneNumber = value;
            }
            else
            {
                throw new ArgumentException("Некорректный формат номера телефона!");
            }
        }
    }

    public string PassportData
    {
        get
        {
            return passportData;
        }
        set
        {
            Regex regex = new Regex(passportDataPattern);
            if (regex.IsMatch(value))
            {
                passportData = value;
            }
            else
            {
                throw new ArgumentException("Некорректные паспортные данные! Длина должна быть от 6 до 30 символов.");
            }
        }
    }

    public DateTime DateBirth
    {
        get
        {
            return dateBirth;
        }
        set
        {
            if (value > DateTime.Today.AddYears(-18) || value < DateTime.Today.AddYears(-100))
            {
                throw new ArgumentException("Некорректная дата рождения! Тренер должен быть в возрасте от 18 до 100 лет.");
            }
            dateBirth = value;
        }
    }
}
