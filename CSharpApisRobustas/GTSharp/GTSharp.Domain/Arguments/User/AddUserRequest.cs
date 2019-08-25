using GTSharp.Domain.Interfaces.Arguments;
using GTSharp.Domain.ValueObjects;

namespace GTSharp.Domain.Arguments.User
{
    public class AddUserRequest : IRequest
    {
        public Name Name { get; set; }

        public Email Email { get; set; }

        public string Password { get; set; }
    }
}
