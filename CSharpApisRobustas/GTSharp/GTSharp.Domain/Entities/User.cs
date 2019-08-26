using GTSharp.Domain.Enum;
using GTSharp.Domain.Resources;
using GTSharp.Domain.ValueObjects;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;

namespace GTSharp.Domain.Entities
{
    public class User : Notifiable
    {   
        public Guid Id { get; set; }

        public Name Name { get; set; }

        public Email Email { get; set; }

        public string Password { get; set; }

        public EnumUserStatus Status { get; set; }

        public User(Name name, Email email, string password)
        {
            Name = name;
            Email = email;
            Password = password;

            new AddNotifications<User>(this)
                .IfNullOrInvalidLength(o => o.Password, 6, 32, Message.X0_IsInvalid.ToFormat(Message.Password));
        }
    }
}
