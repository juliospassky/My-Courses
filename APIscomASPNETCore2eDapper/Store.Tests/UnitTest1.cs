using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.StoreContext.Entities;

namespace Store.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var c = new Customer("Julio", "Oliveira", "1111111", "j@gmail.com", "32184194", "endereco");
            var order = new Order(c);   
        }
    }
}
