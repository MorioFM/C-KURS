using System.Text.RegularExpressions;

namespace MyAPP.Common.DB.Entity;

public class Client
{
    private string fullName = string.Empty;
    // ФИО клиента: буквы (рус/англ), дефис, точка и пробелы, от 2 до 100 символов
    private const string fullNamePattern = @"^[А-Яа-яЁёA-Za-z\s.\-]{2,100}$";

    private string? phoneNumber = null;
    // Телефон: плюс, цифры, скобки, пробелы и тире (от 7 до 20 символов)
    private const string phoneNumberPattern = @"^\+?[0-9\s\-\(\)]{7,20}$";

    private string adress = string.Empty;
    // Адрес: буквы, цифры, знаки препинания (точка, запятая, слэш, дефис, знак номера), от 5 до 100 символов
    private const string adressPattern = @"^[А-Яа-яЁёA-Za-z0-9\s.,\-\/#№]{5,100}$";

    public int ClientID { get; set; }

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
                throw new ArgumentException("Некорректное ФИО клиента! Допустимы буквы, пробелы, дефисы и точки от 2 до 100 символов.");
            }
        }
    }

    public string? PhoneNumber
    {
        get
        {
            return phoneNumber;
        }
        set
        {
            // Так как поле nullable (string?), разрешаем пустые значения
            if (string.IsNullOrWhiteSpace(value))
            {
                phoneNumber = null;
                return;
            }

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

    // Название свойства Adress оставлено с одной 'd', строго в соответствии с интерфейсом IClient
    public string Adress
    {
        get
        {
            return adress;
        }
        set
        {
            Regex regex = new Regex(adressPattern);
            if (regex.IsMatch(value))
            {
                adress = value;
            }
            else
            {
                throw new ArgumentException("Некорректный адрес! Длина должна быть от 5 до 100 символов.");
            }
        }
    }
}