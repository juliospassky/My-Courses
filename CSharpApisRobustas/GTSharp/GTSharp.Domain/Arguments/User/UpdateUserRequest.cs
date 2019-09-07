using System;

namespace GTSharp.Domain.Arguments.User
{
    public class UpdateUserRequest
    {
        public Guid Id { get; private set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
    }
}
