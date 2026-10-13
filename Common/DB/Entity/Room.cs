using System.Text.RegularExpressions;
using MyAPP.Common;

namespace MyAPP.Common.DB.Entity;

public class Room
{
    // Поля и ограничения данных
    private int roomID;

    private string roomName = string.Empty;
    // Название зала: буквы, цифры, пробелы, дефис, знак №, от 2 до 50 символов
    private const string roomNamePattern = @"^[А-Яа-яЁёA-Za-z0-9\s\-№]{2,50}$";

    private string roomType = string.Empty;
    // Тип зала: буквы, пробелы и дефис, от 2 до 50 символов
    private const string roomTypePattern = @"^[А-Яа-яЁёA-Za-z\s\-]{2,50}$";

    // Свойства 
    public int RoomID
    {
        get
        {
            return roomID;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Некорректный RoomID! Идентификатор зала не может быть отрицательным.");
            }
            roomID = value;
        }
    }

    public string RoomName
    {
        get
        {
            return roomName;
        }
        set
        {
            Regex regex = new Regex(roomNamePattern);
            if (regex.IsMatch(value))
            {
                roomName = value;
            }
            else
            {
                throw new ArgumentException("Некорректное название зала! Допустимы буквы, цифры, дефисы и пробелы от 2 до 50 символов.");
            }
        }
    }

    public string RoomType
    {
        get
        {
            return roomType;
        }
        set
        {
            Regex regex = new Regex(roomTypePattern);
            if (regex.IsMatch(value))
            {
                roomType = value;
            }
            else
            {
                throw new ArgumentException("Некорректный тип зала! Допустимы буквы, дефисы и пробелы от 2 до 50 символов.");
            }
        }
    }
}
