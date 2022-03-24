using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Porto.Domain.Entities;

namespace Porto.Infra.Mapping{
    public class MovementMap : IEntityTypeConfiguration<Movement>{
        public void Configure(EntityTypeBuilder<Movement> builder){
            builder.ToTable("Movement");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                    .UseIdentityColumn()
                    .HasColumnType("BIGINT");

            builder.Property(x=>x.TypeMovement)
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasColumnName("typeMovement")
                    .HasColumnType("VARCHAR(16)");

            builder.Property(x=>x.DateInitial)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("dateInitial")
                    .HasColumnType("VARCHAR(10)");

            builder.Property(x=>x.HourInitial)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("hourInitial")
                    .HasColumnType("VARCHAR(5)");  
                    
            builder.Property(x=>x.DateFinish)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("dateFinish")
                    .HasColumnType("VARCHAR(10)");
                    
            builder.Property(x=>x.HourFinish)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("hourFinish")
                    .HasColumnType("VARCHAR(5)");      
        }
    }
}