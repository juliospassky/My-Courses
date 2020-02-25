using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests
{
    [TestClass]
    public class StudentTests
    {
        private readonly Name _name;
        private readonly Document _document;
        private readonly Address _address;
        private readonly Email _email;
        private readonly Student _student;
        private readonly Subscription _subscription;

        public StudentTests()
        {
            _name = new Name("Bruce", "Wayne");
            _document = new Document("08235866723", EDocumentType.CPF);
            _email = new Email("batman@dc.com");
            _address = new Address("Quincas", "344", "Bat", "BatCity", "BatState", "BatCountry", "12333");
            _student = new Student(_name, _document, _email);
            _subscription = new Subscription(null);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenHadActiveSubscription()
        {
            var payment = new PaypalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, _document, "Wayne Corp", _address, _email);
            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);
            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenHadSubscriptionHasNoPayment()
        {
            _student.AddSubscription(_subscription);
            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenAddSubscription()
        {
            var payment = new PaypalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, _document, "Wayne Corp", _address, _email);
            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);
            Assert.IsTrue(_student.Valid);
        }
    }
}
