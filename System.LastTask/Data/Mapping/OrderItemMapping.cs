using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.LastTask.Entities;

namespace System.LastTask.Data.Mapping
{
    public class OrderItemMapping : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItems", table =>
            {
                table.HasCheckConstraint("CK_OrderItems_Quantity", "[Quantity] > 0");
                table.HasCheckConstraint("CK_OrderItems_Price", "[Price] >= 0");
            });

            builder.HasKey(oi => oi.Id);

            builder.Property(oi => oi.Quantity)
                .IsRequired();

            builder.Property(oi => oi.Price)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.HasOne(oi => oi.Ticket)
                .WithMany(t => t.OrderItems)
                .HasForeignKey(oi => oi.TicketId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
