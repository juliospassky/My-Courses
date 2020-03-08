using GTSharp.Domain.Arguments.Base;
using GTSharp.Domain.Arguments.GTUser;
using GTSharp.Domain.Interfaces.Services.Base;
using System;
using System.Collections.Generic;

namespace GTSharp.Domain.Interfaces.Services
{
    public interface IServiceUser : IServiceBase
    {
        AuthUserResponse AuthUser(AuthUserRequest request);

        AddUserResponse AddUser(AddUserRequest request);

        UpdateUserResponse UpdateUser(UpdateUserRequest request);

        ResponseBase RemoveUser(Guid id);

        IEnumerable<UserResponse> UserList();
    }
}
