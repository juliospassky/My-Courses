using System;
using GTSharp.Domain.Entities;
using GTSharp.Domain.Repositories;

namespace GTSharp.Domain.Tests.Repositories
{

    public class FakeTodoRepository : ITodoRepository
    {
        public void Create(TodoItem todoItem)
        {
        }

        public void Update(TodoItem todoItem)
        {
        }
        
        public TodoItem GetById(Guid id, string user)
        {
            return new TodoItem("Título", "Julio", DateTime.Now);
        }
    }

}