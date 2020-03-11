using System;
using Flunt.Notifications;
using Flunt.Validations;

namespace GTSharp.Domain.Commands.Input
{
    public class UpdateTodoCommand : Notifiable, ICommand
    {
         public Guid Id  { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string User { get; set; }

        public UpdateTodoCommand() { }

        public UpdateTodoCommand(Guid id, string title, DateTime date, string user)
        {
            Id = id;
            Title = title;
            Date = date;
            User = user;
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