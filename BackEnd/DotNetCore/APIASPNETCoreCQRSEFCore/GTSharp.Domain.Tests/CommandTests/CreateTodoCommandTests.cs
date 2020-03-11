using Microsoft.VisualStudio.TestTools.UnitTesting;
using GTSharp.Domain.Commands.Input;
using System;

namespace GTSharp.Domain.Tests.CommandTests
{
    [TestClass]
    public class CreateTodoCommandTests
    {
        private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("Cortar Grama", "Oliveira", DateTime.Now);
        private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand("Ca", "Ol", DateTime.Now);

        public CreateTodoCommandTests()
        {
            _validCommand.Validate();
            _invalidCommand.Validate();
        }

        [TestMethod]
        public void ValidCommand()
        {
            Assert.AreEqual(_validCommand.Valid, true);
        }

        [TestMethod]
        public void InvalidCommand()
        {
            Assert.AreEqual(_invalidCommand.Valid, false);

        }
    }
}
