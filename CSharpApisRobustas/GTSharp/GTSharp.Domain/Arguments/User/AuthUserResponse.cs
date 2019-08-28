using GTSharp.Domain.Interfaces.Arguments;

namespace GTSharp.Domain.Arguments.User
{
    public class AuthUserResponse : IResponse
    {
        private static string enumStatus;

        public string FirstName { get; set; }

        public string Email { get; set; }

        public int Status { get; set; }

        public static explicit operator AuthUserResponse(Entities.User entitie)
        {
            return new AuthUserResponse()
            {
                FirstName = entitie.Name.FirstName,
                Email = entitie.Email.Adress,
                Status = (int)entitie.Status
            };
        }
    }
}
