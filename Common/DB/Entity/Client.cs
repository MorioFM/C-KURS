using System.Text.RegularExpressions;

namespace MyAPP.Common.DB.Entity;

public class Client
{
    private string firstName = string.Empty;
    // Имя: только буквы (рус/англ) и дефис, от 2 до 50 символов
    private const string firstNamePattern = @"^[А-Яа-яЁёA-Za-z\-]{2,50}$";

    private string lastName = string.Empty;
    // Фамилия: только буквы (рус/англ), дефис и возможные пробелы, от 2 до 50 символов
    private const string lastNamePattern = @"^[А-Яа-яЁёA-Za-z\s\-]{2,50}$";

    private string? phoneNumber = null;
    // Телефон: плюс, цифры, скобки, пробелы и тире (от 7 до 20 символов)
    private const string phoneNumberPattern = @"^\+?[0-9\s\-\(\)]{7,20}$";

    private string adress = string.Empty;
    // Адрес: буквы, цифры, знаки препинания (точка, запятая, слэш, дефис, знак номера), от 5 до 150 символов
    private const string adressPattern = @"^[А-Яа-яЁёA-Za-z0-9\s.,\-\/#№]{5,150}$";

    public int ClientID { get; set; }

    public string FirstName
    {
        get
        {
            return firstName;
        }
        set
        {
            Regex regex = new Regex(firstNamePattern);
            if (regex.IsMatch(value))
            {
                firstName = value;
            }
            else
            {
                throw new ArgumentException("Некорректное имя! Допустимы только буквы и дефис от 2 до 50 символов.");
            }
        }
    }

    public string LastName
    {
        get
        {
            return lastName;
        }
        set
        {
            Regex regex = new Regex(lastNamePattern);
            if (regex.IsMatch(value))
            {
                lastName = value;
            }
            else
            {
                throw new ArgumentException("Некорректная фамилия! Допустимы только буквы, пробелы и дефис от 2 до 50 символов.");
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
                throw new ArgumentException("Некорректный адрес! Длина должна быть от 5 до 150 символов.");
            }
        }
    }
}