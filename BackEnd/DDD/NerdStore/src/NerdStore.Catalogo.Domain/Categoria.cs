using NerdStore.Core.DomainObjects;

namespace NerdStore.Catalogo.Domain
{
    public class Categoria : Entity
    {
        public string Nome { get; set; }
        public string Codigo { get; set; }

        public Categoria(string nome, string codigo)
        {
            Nome = nome;
            Codigo = codigo;

            Validar();
        }

        public void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, "O campo Nome da categoria não pode estar vazio");
            Validacoes.ValidarSeIgual(Codigo, 0, "O campo Codigo da categoria não pode ser 0");
        }

        public override string ToString()
        {
            return $"{Nome} - {Codigo}";
        }
    }
}
