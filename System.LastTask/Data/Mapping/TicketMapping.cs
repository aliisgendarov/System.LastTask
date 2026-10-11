using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.LastTask.Entities;

namespace System.LastTask.Data.Mapping
{
    public class TicketMapping : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.ToTable("Tickets", table =>
            {
                table.HasCheckConstraint("CK_Tickets_Stock", "[Stock] >= 0");
                table.HasCheckConstraint("CK_Tickets_Price", "[Price] >= 0");
            });

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(t => t.Price)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(t => t.Stock)
                .IsRequired();
        }
    }
}
