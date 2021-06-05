using System.Collections.Generic;

namespace TestTask.Data.Models
{
    public class Good
    {
        public long Article { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ICollection<OrderGood> OrderGoods { get; set; } = new List<OrderGood>();
    }
}