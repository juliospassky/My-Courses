using Microsoft.VisualStudio.TestTools.UnitTesting;
using GTSharp.Domain.Commands.Input;
using System;
using GTSharp.Domain.Handlers;
using GTSharp.Domain.Tests.Repositories;
using GTSharp.Domain.Commands.Output;

namespace GTSharp.Domain.Tests.HandlerTests
{
    [TestClass]
    public class CreateTodoHandlerTests
    {
        private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("Cortar Grama", "Oliveira", DateTime.Now);
        private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand("Ca", "Ol", DateTime.Now);
        private readonly TodoHandler _handler = new TodoHandler(new FakeTodoRepository());

        public CreateTodoHandlerTests()
        {
            _validCommand.Validate();
            _invalidCommand.Validate();
        }

        [TestMethod]
        public void InvalidCommandToHandlerStopTask()
        {
            var result = (GenericCommandResult)_handler.Handle(_invalidCommand);
            Assert.AreEqual(result.Success, false);

        }

        [TestMethod]
        public void ValidCommandToHandler()
        {
            var result = (GenericCommandResult)_handler.Handle(_invalidCommand);
            Assert.AreEqual(result.Success, false);
        }

    }
}
