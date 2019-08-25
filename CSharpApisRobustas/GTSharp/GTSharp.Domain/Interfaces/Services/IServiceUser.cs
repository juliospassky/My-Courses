using GTSharp.Domain.Arguments.User;

namespace GTSharp.Domain.Interfaces.Services
{
    public interface IServiceUser
    {
        AuthUserResponse AuthUser(AuthUserRequest request);

        AddUserResponse AddUser(AddUserRequest request);
    }
}
