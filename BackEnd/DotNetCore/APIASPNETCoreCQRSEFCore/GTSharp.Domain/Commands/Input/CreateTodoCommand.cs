using System;
using Flunt.Notifications;
using Flunt.Validations;

namespace GTSharp.Domain.Commands.Input
{
    public class CreateTodoCommand : Notifiable, ICommand
    {
        public string Title { get; set; }
        public string User { get; set; }

        public DateTime Date { get; set; }

        public CreateTodoCommand() { }

        public CreateTodoCommand(string title, string user, DateTime date)
        {
            Title = title;
            User = user;
            Date = date;
        }

        public void Validate()
        {
            AddNotifications(new Contract()
            .Requires()
            .HasMinLen(Title, 3, "Title", "Título deve ter mais de 3 caracteres")
            .HasMinLen(User, 6, "User", "Usuário deve ter mais de 6 caracteres")
            );
        }
    }
}