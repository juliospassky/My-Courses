using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests
{
    [TestClass]
    public class DocumentTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenCNPJIsInvalid()
        {
            var doc = new  Document("12345", EDocumentType.CNPJ);
            Assert.IsTrue(doc.Invalid);  
        }

        [TestMethod]
        public void ShouldReturnSucessWhenCNPJIsValid()
        {
            var doc = new  Document("12345678901234", EDocumentType.CNPJ);
            Assert.IsTrue(doc.Valid);  
        }

        [TestMethod]
        public void ShouldReturnErrorWhenCPFIsInvalid()
        {
            var doc = new  Document("12345", EDocumentType.CPF);
            Assert.IsTrue(doc.Invalid);  
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("12345678912")]
        [DataRow("12345678913")]
        [DataRow("12345678914")]        
        public void ShouldReturnSucessWhenCPFIsValid(string cpf)
        {
             var doc = new  Document(cpf, EDocumentType.CPF);
            Assert.IsTrue(doc.Valid);  
        }
    }
}
