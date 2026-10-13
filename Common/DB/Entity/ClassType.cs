using System.Text.RegularExpressions;
using MyAPP.Common;

namespace MyAPP.Common.DB.Entity;

public class ClassType
{
    // Поля и ограничения данных
    private int classTypesID;

    private string className = string.Empty;
    // Название типа занятия: буквы (рус/англ), цифры, дефис и пробелы, от 2 до 50 символов
    private const string classNamePattern = @"^[А-Яа-яЁёA-Za-z0-9\s\-]{2,50}$";

    // Свойства 
    public int ClassTypesID
    {
        get
        {
            return classTypesID;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Некорректный ClassTypesID! Идентификатор не может быть отрицательным.");
            }
            classTypesID = value;
        }
    }

    public string ClassName
    {
        get
        {
            return className;
        }
        set
        {
            Regex regex = new Regex(classNamePattern);
            if (regex.IsMatch(value))
            {
                className = value;
            }
            else
            {
                throw new ArgumentException("Некорректное название типа занятия! Допустимы буквы, цифры, дефисы и пробелы от 2 до 50 символов.");
            }
        }
    }
}
