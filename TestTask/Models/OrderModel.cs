using System;
using System.Collections.Generic;
using System.Linq;
using TestTask.Data.Models;
using TestTask.Enums;

namespace TestTask.Models
{
    public class OrderModel : OrderPutModel
    {
        public OrderModel() { }

        internal OrderModel(Order order)
        {
            Number = order.Number;
            Status = order.Status;
            Date = order.Date;
            Name = order.Name;
            Goods = order.Goods.Select(g => new OrderGoodModel(g));
        }

        public DateTime? Date { get; set; } = DateTime.Now;

        internal override Order ToOrder()
        {
            var order = base.ToOrder();
            order.Date = Date.Value;

            return order;
        }
    }

    public class OrderPutModel : OrderPostModel
    {
        public short Number { get; set; }
        public Status? Status { get; set; } = Enums.Status.Registred;

        internal override Order ToOrder()
        {
            var order = base.ToOrder();
            order.Number = Number;
            order.Status = Status.Value;

            foreach (var good in order.Goods)
            {
                good.OrderNumber = Number;
            }

            return order;
        }
    }

    public class OrderPostModel
    {
        public string Name { get; set; }
        public IEnumerable<OrderGoodModel> Goods { get; set; }

        internal virtual Order ToOrder()
        {
            return new Order { Name = Name, Goods = Goods.Select(g => g.ToOrderGood()).ToArray() };
        }
    }

    public class OrderPutchModel : OrderModel
    {
        public new Status? Status { get; set; }
        public new DateTime? Date { get; set; }
    }
}
