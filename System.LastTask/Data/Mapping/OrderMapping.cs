using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.LastTask.Entities;

namespace System.LastTask.Data.Mapping
{
    public class OrderMapping : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.CustomerName)
                .HasMaxLength(150);

            builder.Property(o => o.CreatedTime)
                .IsRequired();
        }
    }
}
