using GTSharp.Domain.Interfaces.Arguments;
using System;

namespace GTSharp.Domain.Arguments.User
{
    public class AddUserResponse : IResponse
    {
        public Guid Id { get; set; }

        public string Message { get; set; }
    }
}
