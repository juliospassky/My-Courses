using System;
using GTSharp.Domain.Interfaces.Arguments;

namespace GTSharp.Domain.Arguments.User
{
    public class AddUserResponse : IResponse
    {
        public Guid Id { get; set; }

        public string Message { get; set; }

        public static explicit operator AddUserResponse(Entities.User entitie)
        {
            return new AddUserResponse()
            {
                Id = entitie.Id,
                Message = Resources.Message.SuccessOperation
            };
        }
    }
}
