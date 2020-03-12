using System;
using System.Collections.Generic;
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

        public IEnumerable<TodoItem> GetAll(string user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TodoItem> GetAllDone(string user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TodoItem> GetAllUndone(string user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TodoItem> GetByPeriod(string user, DateTime date, bool done)
        {
            throw new NotImplementedException();
        }
    }

}