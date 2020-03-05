using System;
using System.Collections.Generic;
using System.Linq;
using Store.Domain.StoreContext.Enums;

namespace Store.Domain.StoreContext.Entities
{
    public class Order
    {
        private IList<OrderItem> _Items;
        private IList<Delivery> _Deliveries;

        public Customer Customer { get; private set; }
        public string Number { get; private set; }
        public DateTime CreateDate { get; private set; }
        public EOrderStatus Status { get; private set; }
        public IReadOnlyList<OrderItem> Items { get { return _Items.ToArray(); } }
        public IReadOnlyList<Delivery> Deliveries { get { return _Deliveries.ToArray(); } }

        public Order(Customer customer)
        {
            Customer = customer;
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8).ToUpper();
            CreateDate = DateTime.Now;
            Status = EOrderStatus.Created;
            _Items = new List<OrderItem>();
            _Deliveries = new List<Delivery>();
        }

        public void AddItem(OrderItem item)
        {
            //Valida o item
            //Adiciona o item
        }

        public void Place()
        {

        }
    }
}