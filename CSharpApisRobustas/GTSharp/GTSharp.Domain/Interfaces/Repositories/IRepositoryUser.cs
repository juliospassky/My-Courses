using GTSharp.Domain.Arguments.User;
using GTSharp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace GTSharp.Domain.Interfaces.Repositories
{
    public interface IRepositoryUser
    {
        User AuthUser(string email, string password);

        User AddUser(User user);

        IEnumerable<User> UserList();
    }
}
