using GTSharp.Domain.Interfaces.Arguments;
using GTSharp.Domain.ValueObjects;

namespace GTSharp.Domain.Arguments.User
{
    public class AuthUserResponse : IResponse
    {
        public string FirstName { get; set; }

        public string Email { get; set; }
    }
}
