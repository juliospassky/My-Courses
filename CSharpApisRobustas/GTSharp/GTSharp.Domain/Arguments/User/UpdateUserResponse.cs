using System;
using GTSharp.Domain.Entities;

namespace GTSharp.Domain.Arguments.User
{
    public class UpdateUserResponse
    {
        public Guid Id { get; private set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Message { get; set; }

        public static explicit operator UpdateUserResponse(Entities.User entitie)
        {
            return new UpdateUserResponse()
            {
                Id = entitie.Id,
                FirstName = entitie.Name.FirstName,
                LastName = entitie.Name.LastName,
                Email = entitie.Email.Adress,
                Message = Resources.Message.SuccessOperation
            };
        }
    }
}
