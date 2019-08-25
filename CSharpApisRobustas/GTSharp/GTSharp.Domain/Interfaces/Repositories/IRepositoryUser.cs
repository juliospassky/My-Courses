using GTSharp.Domain.Arguments.User;
using GTSharp.Domain.Entities;
using System;

namespace GTSharp.Domain.Interfaces.Repositories
{
    public interface IRepositoryUser
    {
        AuthUserResponse AuthUser(AuthUserRequest request);

        Guid AddUser(User user);
    }
}
