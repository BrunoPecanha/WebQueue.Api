using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using The3BlackBro.WebQueue.Domain.Entities;
using The3BlackBro.WebQueue.Infra.CrossCutting.Utils;

namespace The3BlackBro.WebBaberShop.Infra.Data.EntityConfig {
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder) {

            builder
             .ToTable("Company")
             .HasKey(x => x.Id);

            builder
            .Property(c => c.RegisteringDate)
             .HasColumnType("timestamp")
            .HasColumnName("RegisteringDate")
            .IsRequired();

            builder
            .Property(c => c.LastUpdate)
            .HasColumnType("timestamp")
            .HasColumnName("LastUpdate");

            builder
            .Property(c => c.FantasyName)
            .HasColumnName("FantasyName");

            builder
            .Property(c => c.RealName)
            .HasColumnName("RealName");

            builder
           .Property(c => c.Cnpj)
           .HasColumnName("Cnpj");

            builder
           .Property(c => c.Address)
           .HasColumnName("Address");

            builder
           .Property(c => c.UseQueue)
           .HasColumnName("UseQueue")
           .HasColumnType("bit(1)")
           .HasConversion(ConverterProvider.GetBoolToBitArrayConverter());

            builder
            .Property(c => c.Logo)
            .HasColumnName("Logo");

            builder
           .Property(c => c.Activated)
           .HasColumnName("Activated")
           .HasColumnType("bit(1)")
           .HasConversion(ConverterProvider.GetBoolToBitArrayConverter());

            builder
            .Property(c => c.ConfirmationNotice)
            .HasColumnName("ConfirmationNotice")
            .HasColumnType("bit(1)")
            .HasConversion(ConverterProvider.GetBoolToBitArrayConverter());

            builder
            .Property(x => x.UserId)
            .HasColumnName("UserId");

            builder
            .HasOne(x => x.User)
            .WithOne(x => x.Company)
            .HasForeignKey<User>(x => x.CompanyId);

            builder
            .HasMany(x => x.Queue)
            .WithOne(x => x.Company);           
        }
    }
}
