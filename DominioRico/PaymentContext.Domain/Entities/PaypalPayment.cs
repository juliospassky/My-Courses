using System;

namespace PaymentContext.Domain.Entities
{
    public class PaypalPayment : Payment
    {
        public string TransactionCode { get; private set; }

        public PaypalPayment(string transactionCode, DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, string document, string payer, string address, string email)
        : base(paidDate, expireDate, total, totalPaid, document, payer, address, email)
        {
            TransactionCode = transactionCode;

        }
    }
}