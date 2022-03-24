using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Porto.Domain.Entities;

namespace Porto.Infra.Mapping
{
    public class ContainerMap : IEntityTypeConfiguration<Container>
    {

        public void Configure(EntityTypeBuilder<Container> builder)
        {
            builder.ToTable("Container");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                    .UseIdentityColumn()
                    .HasColumnType("BIGINT");

            builder.Property(x => x.ClientContainer)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("cliente")
                    .HasColumnType("VARCHAR(80)");

            builder.Property(x => x.NumContainer)
                    .IsRequired()
                    .HasMaxLength(11)
                    .HasColumnName("numContainer")
                    .HasColumnType("VARCHAR(11)");

            builder.Property(x => x.TypeContainer)
                    .IsRequired()
                    .HasColumnName("typeContainer")
                    .HasColumnType("INT");

            builder.Property(x => x.StatusContainer)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("statusContainer")
                    .HasColumnType("VARCHAR(5)");

            builder.Property(x => x.CategoryContainer)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("categoryContainer")
                    .HasColumnType("VARCHAR(10)");
        }
    }
}