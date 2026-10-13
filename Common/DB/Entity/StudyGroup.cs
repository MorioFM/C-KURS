using System.Text.RegularExpressions;
using MyAPP.Common;

namespace MyAPP.Common.DB.Entity;

public class StudyGroup
{
    // Поля и ограничения данных
    private int groupID;

    private string groupName = string.Empty;
    // Название группы: буквы (рус/англ), цифры, дефис и пробелы, от 2 до 50 символов
    private const string groupNamePattern = @"^[А-Яа-яЁёA-Za-z0-9\s\-]{2,50}$";

    // Свойства 
    public int GroupID
    {
        get
        {
            return groupID;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Некорректный GroupID! Идентификатор группы не может быть отрицательным.");
            }
            groupID = value;
        }
    }

    public string GroupName
    {
        get
        {
            return groupName;
        }
        set
        {
            Regex regex = new Regex(groupNamePattern);
            if (regex.IsMatch(value))
            {
                groupName = value;
            }
            else
            {
                throw new ArgumentException("Некорректное название группы! Допустимы буквы, цифры, дефисы и пробелы от 2 до 50 символов.");
            }
        }
    }
}
