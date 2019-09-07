using GTSharp.Domain.Entities;
using GTSharp.Domain.Interfaces.Repositories.Base;
using System;

namespace GTSharp.Domain.Interfaces.Repositories
{
    public interface IRepositoryUser : IRepositoryBase<User, Guid>
    {
    }
}
