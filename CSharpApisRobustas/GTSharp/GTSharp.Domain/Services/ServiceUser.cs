using GTSharp.Domain.Arguments.User;
using GTSharp.Domain.Entities;
using GTSharp.Domain.Interfaces.Repositories;
using GTSharp.Domain.Interfaces.Services;
using System;

namespace GTSharp.Domain.Services
{
    public class ServiceUser : IServiceUser
    {
        private readonly IRepositoryUser _repositorieUser;

        public ServiceUser(IRepositoryUser repositorieUser)
        {
            _repositorieUser = repositorieUser;
        }

        public AddUserResponse AddUser(AddUserRequest request)
        {
            
            Guid id = _repositorieUser.AddUser(new User());

            return new AddUserResponse() { Id = id, Message = "Sucess" };
        }

        public AuthUserResponse AuthUser(AuthUserRequest request)
        {
            return null; 
        }
    }
}
