using GTSharp.Domain.Entities.Base;
using GTSharp.Domain.Enum;
using GTSharp.Domain.Extensions;
using GTSharp.Domain.Resources;
using GTSharp.Domain.ValueObjects;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;

namespace GTSharp.Domain.Entities
{
    public class GTUser : EntityBase
    {   
        public Name Name { get; private set; }

        public Email Email { get; private set; }

        public string Password { get; private set; }

        public EnumUserStatus Status { get; private set; }

        public GTUser(Email email, string password)
        {
            Email = email;
            Password = password;

            new AddNotifications<GTUser>(this)
                .IfNullOrInvalidLength(o => o.Password, 6, 32, Message.X2_Required_Between.ToFormat(Message.Password, "6", "32"));

            if (IsValid())
                password = password.ConvertToMD5();
        }

        public GTUser(Name name, Email email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
            Status = EnumUserStatus.InAnalysis;

            new AddNotifications<GTUser>(this)
                .IfNullOrInvalidLength(o => o.Password, 6, 32, Message.X2_Required_Between.ToFormat(Message.Password, "6", "32"));

            if (IsValid())
                Password = password.ConvertToMD5();
        }

        public void UpdateUser(Name name, Email email)
        {
            Name = name;
            Email = email;
                        
            AddNotifications(name, email);
        }

        public override string ToString()
        {
            return $"{Name.FirstName} {Name.LastName}";
        }
    }
}