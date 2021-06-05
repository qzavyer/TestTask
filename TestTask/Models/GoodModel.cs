using TestTask.Data.Models;

namespace TestTask.Models
{
    public class GoodModel
    {
        public GoodModel() { }

        internal GoodModel(Good good)
        {
            Article = good?.Article ?? 0;
            Name = good?.Name;
            Price = good?.Price ?? 0;
        }

        public long Article { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        internal Good ToGood()
        {
            return new Good { Article = Article, Name = Name, Price = Price };
        }
    }
}
