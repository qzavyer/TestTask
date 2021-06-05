namespace TestTask.Data.Models
{
    public class OrderGood
    {
        public int Id { get; set; }

        public long GoodArticle { get; set; }
        public short OrderNumber { get; set; }
        public int Count { get; set; }
        public Good Good { get; set; }
        public Order Order { get; set; }
    }
}