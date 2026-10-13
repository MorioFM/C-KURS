using MyAPP.Common;

namespace MyAPP.Common.DB.Entity;

public class GroupMembers
{
    // Поля и ограничения данных
    private int groupMembersID;
    private int groupID;
    private int clientID;

    // Свойства 
    public int GroupMembersID
    {
        get
        {
            return groupMembersID;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Некорректный GroupMembersID! Идентификатор не может быть отрицательным.");
            }
            groupMembersID = value;
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

    public int ClientID
    {
        get
        {
            return clientID;
        }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Некорректный ClientID! Идентификатор клиента должен быть больше 0.");
            }
            clientID = value;
        }
    }
}
