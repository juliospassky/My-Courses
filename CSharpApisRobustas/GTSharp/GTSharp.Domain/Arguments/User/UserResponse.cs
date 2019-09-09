using System;

namespace GTSharp.Domain.Arguments.GTUser
{
    public class UserResponse
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ComplettName { get; set; }

        public string Email { get; set; }

        public int Status { get; set; }
        
        public static explicit operator UserResponse(Entities.GTUser entite)
        {
            return new UserResponse()
            {
                ComplettName = entite.ToString(),
                FirstName = entite.Name.FirstName,
                LastName = entite.Name.LastName,
                Email = entite.Email.Adress,
                Status = (int)entite.Status
            };
        }
    }
}
