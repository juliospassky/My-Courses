using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new Contract()
              .Requires()
              .HasMinLen(firstName, 3, "Name.FirstName", "Nome deve conter pelo menos 3 caracteres")
              .HasMaxLen(firstName, 40, "Name.FirstName", "Nome deve conter menos de 40 caracteres")
              .IsNotNullOrEmpty(firstName, "Name.FirstName", "Nome nao pode ser vazio")
              .HasMinLen(lastName, 3, "Name.LastName", "Sobre nome deve conter pelo menos 3 caracteres")
              .IsNotNullOrEmpty(lastName, "Name.LastName", "Sobre nome nao pode ser vazio")
              );
        }

        public override string ToString(){
            return $"{FirstName} {LastName}";
        } 
    }
}