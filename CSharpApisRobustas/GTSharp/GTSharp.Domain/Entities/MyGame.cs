using System;

namespace GTSharp.Domain.Entities
{
    public class MyGame
    {
        public Guid Id { get; set; }

        public PlataformGame PlataformGame { get; set; }

        public bool WishGame { get; set; }

        public DateTime WishDate { get; set; }
    }
}
