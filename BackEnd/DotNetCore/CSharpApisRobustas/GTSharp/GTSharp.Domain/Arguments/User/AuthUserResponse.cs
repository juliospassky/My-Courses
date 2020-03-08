using GTSharp.Domain.Interfaces.Arguments;
using System;

namespace GTSharp.Domain.Arguments.GTUser
{
    public class AuthUserResponse : IResponse
    {
        private Guid Id { get; set; }

        public string FirstName { get; set; }

        public string Email { get; set; }

        public int Status { get; set; }

        public static explicit operator AuthUserResponse(Entities.GTUser entitie)
        {
            return new AuthUserResponse()
            {
                Id = entitie.Id,
                FirstName = entitie.Name.FirstName,
                Email = entitie.Email.Adress,
                Status = (int)entitie.Status
            };
        }
    }
}
