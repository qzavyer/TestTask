using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestTask.Data.Models;

namespace TestTask.Data.Configurations
{
    internal class GoodConfiguration : IEntityTypeConfiguration<Good>
    {
        public void Configure(EntityTypeBuilder<Good> builder)
        {
            builder.HasKey(p => p.Article);
            builder.ToTable("Goods");
        }
    }
}