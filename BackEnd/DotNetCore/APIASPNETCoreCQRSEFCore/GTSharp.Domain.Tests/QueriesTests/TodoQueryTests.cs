using System;
using System.Collections.Generic;
using System.Linq;
using GTSharp.Domain.Entities;
using GTSharp.Domain.Queries;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GTSharp.Domain.Tests.QuerriesTests{
    
    [TestClass]
    public class TodoQueryTests{
       
       private List<TodoItem> _items;

        public TodoQueryTests()
        {
            _items = new List<TodoItem>();
            _items.Add(new TodoItem("Tarefa 1", "usuario 1", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 2", "usuario 2", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 3", "usuario 1", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 4", "usuario 2", DateTime.Now));
        }

        [TestMethod]
        public void ReturnTodoItensByUser(){
            var result = _items.AsQueryable().Where(TodoQueries.GetAll("usuario 1"));
            Assert.AreEqual(2, result.Count());
        }
    }
}