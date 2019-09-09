using GTSharp.Domain.Resources;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;

namespace GTSharp.Domain.ValueObjects
{
    public class Name : Notifiable
    {
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        protected Name()
        {
        }

        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            new AddNotifications<Name>(this)
                .IfNullOrInvalidLength(o => o.FirstName, 3, 80, Message.X2_Required_Between.ToFormat(Message.FirstName, "3", "80"))
                .IfNullOrInvalidLength(o => o.LastName, 3, 80, Message.X2_Required_Between.ToFormat(Message.LastName, "3", "80"));
        }
    }
}
