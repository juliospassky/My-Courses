using System;

namespace GTSharp.Domain.Entities
{
    public class PlataformGame
    {
        public Guid Id { get; set; }

        public Game Game { get; set; }

        public Platform Platform { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}

