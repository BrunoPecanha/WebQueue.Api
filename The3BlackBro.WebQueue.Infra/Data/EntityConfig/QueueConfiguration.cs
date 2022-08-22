using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using The3BlackBro.WebQueue.Domain.Entities;

namespace The3BlackBro.WebBaberShop.Infra.Data.EntityConfig {
    public class QueueConfiguration : IEntityTypeConfiguration<CurrentQueue> {
        public void Configure(EntityTypeBuilder<CurrentQueue> builder) {

            builder
            .ToTable("Queue")
            .HasKey(x => x.Id);           

            builder
            .Property(c => c.RegisteringDate)
            .HasColumnType("timestamp")
            .HasColumnName("RegisteringDate")
            .IsRequired();


            builder
            .Property(c => c.LastUpdate)
            .HasColumnType("timestamp")
            .HasColumnName("LastUpdate")
            .IsRequired();

            builder
           .Property(c => c.FinalizationTime)
           .HasColumnType("timestamp")
           .HasColumnName("FinalizationTime")
           .IsRequired();

            builder
            .HasOne(x => x.Company)
            .WithMany(x => x.Queue);           


            builder
           .Property(c => c.IsWorking)
           .HasColumnName("IsWorking")
           .IsRequired();
        }
    }
}
