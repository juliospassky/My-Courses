using GTSharp.Domain.Entities;
using GTSharp.Domain.Interfaces.Repositories;
using GTSharp.Infra.Persistence.Repositories.Base;
using System;

namespace GTSharp.Infra.Persistence.Repositories
{
    public class RepositoryUser : RepositoryBase<User,Guid>, IRepositoryUser
    {
        protected readonly GTSharpContext _context;

        public RepositoryUser(GTSharpContext context) : base(context)
        {
            _context = context;
        }
    }
}
