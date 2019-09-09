using GTSharp.Domain.Interfaces.Arguments;

namespace GTSharp.Domain.Arguments.GTUser
{
    public class AuthUserRequest : IRequest
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
