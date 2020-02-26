using System;
using Flunt.Notifications;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.Services;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Commands;
using PaymentContext.Shared.Handlers;

namespace PaymentContext.Domain.Handlers
{
    public class SubscriptionHandler :
    Notifiable,
    IHandler<CreateBoletoSubscriptionCommand>,
    IHandler<CreatePaypalSuscriptionCommand>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IEmailService _emailService;

        public SubscriptionHandler(IStudentRepository repository, IEmailService emailService)
        {
            _studentRepository = repository;
            _emailService = emailService;
        }

        public ICommandResult Handle(CreateBoletoSubscriptionCommand command)
        {
            //Fail Fast Validations
            command.Validate();

            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Falha no cadastro");
            }

            //Verificar se o dominio já está cadastrado
            if (_studentRepository.DocumentExists(command.Document))
                AddNotification("Document", "Este CPF já está em uso");

            //Verificar se E-mail já está cadastrado
            if (_studentRepository.DocumentExists(command.Email))
                AddNotification("Email", "Este Email já está em uso");

            //Gerar os VOs
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document, EDocumentType.CPF);
            var email = new Email(command.Document);
            var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode);
            var student = new Student(name, document, email);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new BoletoPayment(command.BarCode, command.BoletoNumber, command.PaidDate, command.ExpireDate, command.Total,
             command.TotalPaid, new Document(command.Number, command.Type), command.Payer, address, email);

            //Relacionamentos
            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            //Agrupar as notificaçõs
            AddNotifications(name, document, email, address, student, subscription, payment);

            //Checar as Notificações
            if(Invalid)
                return new CommandResult(false, "Falha na sua assinatura");

            //Salvar as informações
            _studentRepository.CreateSubscription(student);

            //Enviar E-mail de boas vindas
            _emailService.Send(student.Name.ToString(), student.Email.Address, "Bem vindo ao Sistema", "Assinatura criada");

            return new CommandResult(true, "Assinatura realizada com sucesso");
        }

        public ICommandResult Handle(CreatePaypalSuscriptionCommand command)
        {
            //Verificar se o dominio já está cadastrado
            if (_studentRepository.DocumentExists(command.Document))
                AddNotification("Document", "Este CPF já está em uso");

            //Verificar se E-mail já está cadastrado
            if (_studentRepository.DocumentExists(command.Email))
                AddNotification("Email", "Este Email já está em uso");

            //Gerar os VOs
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document, EDocumentType.CPF);
            var email = new Email(command.Document);
            var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode);
            var student = new Student(name, document, email);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new PaypalPayment(command.TransactionCode, command.PaidDate, command.ExpireDate, command.Total,
             command.TotalPaid, new Document(command.Number, command.Type), command.Payer, address, email);

            //Relacionamentos
            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            //Agrupar as notificaçõs
            AddNotifications(name, document, email, address, student, subscription, payment);

            //Salvar as informações
            _studentRepository.CreateSubscription(student);

            //Enviar E-mail de boas vindas
            _emailService.Send(student.Name.ToString(), student.Email.Address, "Bem vindo ao Sistema", "Assinatura criada");

            return new CommandResult(true, "Assinatura realizada com sucesso");
        }
    }
}