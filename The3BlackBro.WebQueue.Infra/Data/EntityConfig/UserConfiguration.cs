using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using The3BlackBro.WebQueue.Domain.Entities;
using The3BlackBro.WebQueue.Infra.CrossCutting.Utils;

namespace The3BlackBro.WebBaberShop.Infra.Data.EntityConfig {
    public class UserConfiguration : IEntityTypeConfiguration<User> {
        public void Configure(EntityTypeBuilder<User> builder) {

            builder
             .ToTable("SysUser")
             .HasKey(x => x.Id);

            builder
            .Property(c => c.RegisteringDate)
            .HasColumnType("timestamp")
            .HasColumnName("RegisteringDate")
            .IsRequired();

            builder
            .Property(c => c.Name)
            .HasColumnName("Name");

            builder
             .Property(c => c.LastName)
             .HasColumnName("LastName");

            builder
             .Property(c => c.LastUpdate)
             .HasColumnType("timestamp")
             .HasColumnName("LastUpdate");

            //builder
            // .Property(c => c.Picture)
            // .HasColumnName("Picture");

            builder
             .Property(c => c.LastVisitDate)
             .HasColumnType("timestamp")
             .HasColumnName("LastVisitDate");

            builder
             .Property(c => c.MobileInfo)
             .HasColumnName("MobileInfo");

            builder
             .Property(c => c.Activated)
             .HasColumnName("Activated")
             .HasColumnType("bit(1)")
             .HasConversion(ConverterProvider.GetBoolToBitArrayConverter());

            builder
            .Property(c => c.Email)
            .HasColumnName("Email");

            builder
            .Property(c => c.PassWord)
            .HasColumnName("PassWord");

            builder
            .Property(c => c.Owner)
            .HasColumnName("Owner");


            builder
                 .HasOne(x => x.Company)
                 .WithOne(x => x.User)
                 .HasForeignKey<Company>(x => x.UserId);

            builder
                .HasMany(x => x.Customer)
                .WithOne(x => x.User);
        }
    }
}
