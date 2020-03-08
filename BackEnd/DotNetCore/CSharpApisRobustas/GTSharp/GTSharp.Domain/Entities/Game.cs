using System;

namespace GTSharp.Domain.Entities
{
    public class Game
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Genere { get; set; }

        public string Site { get; set; }

    }
}
