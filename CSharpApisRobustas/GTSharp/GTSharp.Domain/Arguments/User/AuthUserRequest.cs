using GTSharp.Domain.Interfaces.Arguments;

namespace GTSharp.Domain.Arguments.User
{
    public class AuthUserRequest : IRequest
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
