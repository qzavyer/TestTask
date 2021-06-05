using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestTask.Data.Models;

namespace TestTask.Data.Configurations
{
    internal class OrderGoodConfiguration : IEntityTypeConfiguration<OrderGood>
    {
        public void Configure(EntityTypeBuilder<OrderGood> builder)
        {
            builder.HasKey(p => p.Id);
            builder.ToTable("OrderGoods");

            builder.HasOne(p => p.Good).WithMany(p => p.OrderGoods).HasForeignKey(p => p.GoodArticle);
            builder.HasOne(p => p.Order).WithMany(p => p.Goods).HasForeignKey(p => p.OrderNumber);
        }
    }
}