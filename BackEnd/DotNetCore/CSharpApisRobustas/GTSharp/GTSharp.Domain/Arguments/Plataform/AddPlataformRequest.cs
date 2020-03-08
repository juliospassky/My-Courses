using GTSharp.Domain.Interfaces.Arguments;

namespace GTSharp.Domain.Arguments.Plataform
{
    public class AddPlataformRequest : IRequest
    {
        public string Name { get; set; }
    }
}
