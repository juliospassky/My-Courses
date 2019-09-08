using System;
using System.Collections.Generic;
using System.Linq;
using GTSharp.Domain.Arguments.Base;
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
            if (request == null)
                AddNotification("AddUser", Message.X0_IsRequired.ToFormat("AddUser"));

            var name = new Name(request.FirstName, request.LastName);
            var email = new Email(request.Email);
            var newUser = new User(name, email, request.Password);

            AddNotifications(newUser, name, email);

            if (IsInvalid())
                return null;

            newUser = _repositorieUser.Add(newUser);

            return (AddUserResponse)newUser;
        }

        public UpdateUserResponse UpdateUser(UpdateUserRequest request)
        {
            //TODO mudar mensagem
            if (request == null)
                AddNotification("UpdateUserRequest", Message.X0_IsRequired.ToFormat("UpdateUserRequest"));

            User userUpdate = _repositorieUser.GetById(request.Id);

            if (userUpdate == null)
            {
                AddNotification("Id", Message.DataNotFound);
                return null;
            }

            var name = new Name(request.FirstName, request.LastName);
            var email = new Email(request.Email);

            userUpdate.UpdateUser(name, email);

            AddNotifications(userUpdate);


            if (IsInvalid())
                return null;

            _repositorieUser.Update(userUpdate);

            return (UpdateUserResponse)userUpdate;
        }

        public AuthUserResponse AuthUser(AuthUserRequest request)
        {
            //TODO mudar mensagem
            if (request == null)
                AddNotification("AuthUserRequest", Message.X0_IsRequired.ToFormat("AuthUserRequest"));

            var email = new Email(request.Email);
            var authUser = new User(email, request.Password);

            AddNotifications(authUser, email);

            if (IsInvalid())
                return null;

            authUser = _repositorieUser.GetBy(o => o.Email.Adress == authUser.Email.Adress, o => o.Password == authUser.Password);

            return (AuthUserResponse)authUser;
        }


        public IEnumerable<UserResponse> UserList()
        {
            return _repositorieUser.List().Select(o => (UserResponse)o).ToList();
        }

        public ResponseBase RemoveUser(Guid id)
        {
            User removeUser = _repositorieUser.GetById(id);

            if (removeUser == null)
            {
                AddNotification("Id", Message.DataNotFound);
                return null;
            }

            _repositorieUser.Remove(removeUser);

            return new ResponseBase();
        }
    }
}
