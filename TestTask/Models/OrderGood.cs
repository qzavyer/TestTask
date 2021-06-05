using TestTask.Data.Models;

namespace TestTask.Models
{
    public class OrderGoodModel
    {
        public OrderGoodModel() { }
        public OrderGoodModel(OrderGood orderGood)
        {
            Count = orderGood.Count;
            if (orderGood.Good != null) Good = new GoodModel(orderGood.Good);
        }

        public GoodModel Good { get; set; }
        public int Count { get; set; }

        internal OrderGood ToOrderGood()
        {
            return new OrderGood
            {
                GoodArticle = Good.Article,
                Count = Count,
                Good = Good.ToGood()
            };
        }
    }
}
