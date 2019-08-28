﻿using GTSharp.Domain.Interfaces.Arguments;
using GTSharp.Domain.ValueObjects;

namespace GTSharp.Domain.Arguments.User
{
    public class AddUserRequest : IRequest
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
