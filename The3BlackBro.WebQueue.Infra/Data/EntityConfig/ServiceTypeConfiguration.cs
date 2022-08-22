using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using The3BlackBro.WebQueue.Domain.Entities;
using The3BlackBro.WebQueue.Infra.CrossCutting.Utils;

namespace The3BlackBro.WebBaberShop.Infra.Data.EntityConfig {
    public class ServiceTypeConfiguration : IEntityTypeConfiguration<ServiceType>
    {
        public void Configure(EntityTypeBuilder<ServiceType> builder) {

            builder
                .ToTable("ServiceType")
                .HasKey(x => x.Id);          

            builder
                .Property(c => c.Name)
                .HasColumnName("Name")
                .HasMaxLength(50);

            builder
              .Property(c => c.MediumTime)
              .HasColumnName("MediumTime")
              .IsRequired();

            builder
              .Property(c => c.Price)
              .HasColumnName("Price")
              .IsRequired();

            builder
              .Property(c => c.Activated)
              .HasColumnName("Activated")
              .HasColumnType("bit(1)")
              .HasConversion(ConverterProvider.GetBoolToBitArrayConverter())
              .IsRequired();           


            builder
              .Property(x => x.LastUpdate)
              .HasColumnType("timestamp")
              .HasColumnName("LastUpdate");

            builder
             .Property(x => x.RegisteringDate)
             .HasColumnType("timestamp")
             .HasColumnName("RegisteringDate");

            builder
            .HasOne(x => x.Company)
            .WithMany(x => x.ServiceTypes)
            .HasForeignKey(x => x.CompanyId)
            .IsRequired();
        }
    }
}
