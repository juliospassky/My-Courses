using GTSharp.Domain.Resources;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;

namespace GTSharp.Domain.ValueObjects
{
    public class Name : Notifiable
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            new AddNotifications<Name>(this)
                .IfNullOrWhiteSpace(o => o.FirstName, Message.X0_IsInvalid.ToFormat(Message.FirstName))
                .IfNullOrWhiteSpace(o => o.LastName, Message.X0_IsInvalid.ToFormat(Message.LastName));
        }
    }
}
