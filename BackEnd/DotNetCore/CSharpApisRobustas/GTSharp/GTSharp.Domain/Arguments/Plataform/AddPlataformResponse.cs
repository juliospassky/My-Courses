using GTSharp.Domain.Interfaces.Arguments;
using System;

namespace GTSharp.Domain.Arguments.Plataform
{
    public class AddPlataformResponse : IResponse
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string Message { get; set; }
    }
}
