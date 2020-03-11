using System;
using Flunt.Notifications;
using Flunt.Validations;

namespace GTSharp.Domain.Commands.Input
{
    public class MarkAsDoneTodoCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public string User { get; set; }

        public MarkAsDoneTodoCommand() { }

        public MarkAsDoneTodoCommand(Guid id, string user)
        {
            Id = id;
            User = user;
        }

        public void Validate()
        {
            AddNotifications( new Contract()
            .Requires()
            .HasMinLen(User, 6, "User", "Usuário deve ter mais de 6 caracteres"));
        }
    }
}