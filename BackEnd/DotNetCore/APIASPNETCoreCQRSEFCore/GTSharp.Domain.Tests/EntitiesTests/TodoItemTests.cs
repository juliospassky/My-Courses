using System;
using GTSharp.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GTSharp.Domain.Tests.EntitiesTests{
    
    [TestClass]
    public class TodoItemTests{
       private readonly TodoItem _todo = new TodoItem("Programar mto", "Julio", DateTime.Now);
            
       
        [TestMethod]
        public void TodoItemNotConcludedOnCreate(){
            Assert.AreEqual(_todo.Done, false);
        }
    }
}