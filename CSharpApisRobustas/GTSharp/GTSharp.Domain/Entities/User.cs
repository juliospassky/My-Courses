using GTSharp.Domain.Enum;
using GTSharp.Domain.ValueObjects;
using System;

namespace GTSharp.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }

        public Name Name { get; set; }

        public Email Email { get; set; }

        public string Password { get; set; }

        public EnumUserStatus Status { get; set; }
    }
}
