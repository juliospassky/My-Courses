using System;
using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.Commands;

namespace PaymentContext.Domain.Commands
{
    public class CreatePaypalSuscriptionCommand : Notifiable, ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string TransactionCode { get; set; }
        public string PayerNumber { get; set; }
        public DateTime PaidDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public Decimal Total { get; set; }
        public Decimal TotalPaid { get; set; }
        public string Payer { get; set; }
        public string PayerDocument { get; set; }
        public EDocumentType Type { get; set; }
        public string PayerEmail { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
            .Requires()
            .HasMinLen(FirstName, 3, "Name.FirstName", "Nome deve conter pelo menos 3 caracteres")
            .HasMaxLen(FirstName, 40, "Name.FirstName", "Nome deve conter menos de 40 caracteres")
            .IsNotNullOrEmpty(FirstName, "Name.FirstName", "Nome nao pode ser vazio")
            .HasMinLen(LastName, 3, "Name.LastName", "Sobre nome deve conter pelo menos 3 caracteres")
            .IsNotNullOrEmpty(LastName, "Name.LastName", "Sobre nome nao pode ser vazio"));
        }
    }

}