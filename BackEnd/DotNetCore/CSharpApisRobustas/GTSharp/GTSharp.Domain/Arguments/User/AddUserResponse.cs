using System;
using GTSharp.Domain.Interfaces.Arguments;

namespace GTSharp.Domain.Arguments.GTUser
{
    public class AddUserResponse : IResponse
    {
        public Guid Id { get; set; }

        public string Message { get; set; }

        public static explicit operator AddUserResponse(Entities.GTUser entitie)
        {
            return new AddUserResponse()
            {
                Id = entitie.Id,
                Message = Resources.Message.SuccessOperation
            };
        }
    }
}
