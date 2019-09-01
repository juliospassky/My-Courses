using System.Collections.Generic;
using System.Linq;
using GTSharp.Domain.Arguments.User;
using GTSharp.Domain.Entities;
using GTSharp.Domain.Interfaces.Repositories;
using GTSharp.Domain.Interfaces.Services;
using GTSharp.Domain.Resources;
using GTSharp.Domain.ValueObjects;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;

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
            //TODO mudar mensagem
            if (request == null) AddNotification("AddUser", Message.X0_IsRequired.ToFormat("AddUser"));

            var name = new Name(request.FirstName, request.LastName);
            var email = new Email(request.Email);
            var newUser = new User(name, email, request.Password);

            AddNotifications(newUser, email, name);
            
            if (IsInvalid())
                return null;

            return (AddUserResponse)newUser;
        }

        public UpdateUserResponse UpdateUser(UpdateUserRequest request)
        {
            throw new System.NotImplementedException();
        }

        public AuthUserResponse AuthUser(AuthUserRequest request)
        {
            //TODO mudar mensagem
            if (request == null) AddNotification("AuthUserRequest", Message.X0_IsRequired.ToFormat("AuthUserRequest"));

            var email = new Email(request.Email);
            var authUser = new User(email, request.Password);

            AddNotifications(authUser, email);

            if (IsInvalid())
                return null;

            authUser = _repositorieUser.AuthUser(authUser.Email.Adress, authUser.Password);

            return (AuthUserResponse) authUser;
        }
                

        public IEnumerable<UserResponse> UserList()
        {
            return _repositorieUser.UserList().ToList().Select(o => (UserResponse)o).ToList();
        }
    }
}
