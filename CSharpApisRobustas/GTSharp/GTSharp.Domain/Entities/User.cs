using GTSharp.Domain.Enum;
using GTSharp.Domain.Extensions;
using GTSharp.Domain.Resources;
using GTSharp.Domain.ValueObjects;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;

namespace GTSharp.Domain.Entities
{
    public class User : Notifiable
    {   
        public Guid Id { get; private set; }

        public Name Name { get; private set; }

        public Email Email { get; private set; }

        public string Password { get; private set; }

        public EnumUserStatus Status { get; private set; }

        public User(Email email, string password)
        {
            Email = email;
            Password = password;

            new AddNotifications<User>(this)
                .IfNullOrInvalidLength(o => o.Password, 6, 32, Message.X1_Required_Between.ToFormat(Message.LastName, "6", "32"));
        }

        public User(Name name, Email email, string password)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            Password = password;
            Status = EnumUserStatus.InAnalysis;

            new AddNotifications<User>(this)
                .IfNullOrInvalidLength(o => o.Password, 6, 32, Message.X1_Required_Between.ToFormat(Message.LastName, "6", "32"));

            if (IsValid())
                password = password.ConvertToMD5();

            AddNotifications(name, email);
        }

        public override string ToString()
        {
            return $"{Name.FirstName} {Name.LastName}";
        }
    }
}
