using System;
using System.Collections.Generic;
using TestTask.Enums;

namespace TestTask.Data.Models
{
    public class Order
    {
        public DateTime Date { get; set; } = DateTime.Now;
        public short Number { get; set; }
        public Status Status { get; set; } = Status.Registred;
        public string Name { get; set; }
        public ICollection<OrderGood> Goods { get; set; } = new List<OrderGood>();
    }
}