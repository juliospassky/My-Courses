using GTSharp.Domain.Arguments.User;
using GTSharp.Domain.Entities;
using GTSharp.Domain.Interfaces.Repositories;
using GTSharp.Domain.Interfaces.Services;
using GTSharp.Domain.Resources;
using GTSharp.Domain.ValueObjects;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;

namespace GTSharp.Domain.Services
{
    public class ServiceUser : Notifiable, IServiceUser
    {
        private readonly IRepositoryUser _repositorieUser;

        public ServiceUser(IRepositoryUser repositorieUser)
        {
            _repositorieUser = repositorieUser;
        }

        public AddUserResponse AddUser(AddUserRequest request)
        {            
            Guid id = _repositorieUser.AddUser(null);

            return new AddUserResponse() { Id = id, Message = Message.SuccessOperation};
        }

        public AuthUserResponse AuthUser(AuthUserRequest request)
        {
            if (request == null) AddNotification("AuthUserRequest", Message.X0_IsRequired.ToFormat("AuthUserRequest"));

            var name = new Name(request.FirstName, request.LastName);
            var email = new Email(request.Email);
            var user = new User(name, email, request.Password);

            AddNotifications(name, email, user);

            return user.IsValid() ? _repositorieUser.AuthUser(request) : null;             
        }
    }
}
