using GTSharp.Domain.Resources;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;

namespace GTSharp.Domain.ValueObjects
{
    public class Email : Notifiable
    {
        public string Adress { get; private set; }

        protected Email()
        {                
        }

        public Email(string adress)
        {
            Adress = adress;

            new AddNotifications<Email>(this)
                .IfNotEmail(o => o.Adress, Message.X0_IsInvalid.ToFormat(Message.Email));
        }
    }
}
