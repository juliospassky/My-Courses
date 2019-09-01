using GTSharp.Domain.Arguments.User;
using System.Collections.Generic;

namespace GTSharp.Domain.Interfaces.Services
{
    public interface IServiceUser
    {
        AuthUserResponse AuthUser(AuthUserRequest request);

        AddUserResponse AddUser(AddUserRequest request);

        UpdateUserResponse UpdateUser(UpdateUserRequest request);

        IEnumerable<UserResponse> UserList();
    }
}
