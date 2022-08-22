using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using The3BlackBro.WebQueue.Domain.Entities;
using The3BlackBro.WebQueue.Infra.CrossCutting.Utils;

namespace The3BlackBro.WebBaberShop.Infra.Data.EntityConfig {
    public class CustumerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder) {

            builder
                .ToTable("Custumer")
                .HasKey(x => x.Id);         

            builder
                .Property(c => c.IsServiceDone)
                .HasColumnName("IsServiceDone")
                .IsRequired();

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
              .Property(c => c.Comment)
              .HasColumnName("Comment");

            builder
              .Property(c => c.CurrentCustomerInService)
              .HasColumnName("CurrentCustomerInService")
              .HasColumnType("bit(1)")
              .HasConversion(ConverterProvider.GetBoolToBitArrayConverter());

            builder
              .Property(c => c.QueuePosition)
              .HasColumnName("QueuePosition");

            builder
                .HasOne(x => x.User)
                .WithMany(x => x.Customer)
                .HasForeignKey(x => x.UserId)
                .IsRequired();

            builder
                .HasOne(x => x.CurrentQueue)
                .WithMany(x => x.Custumers)
                .HasForeignKey(x => x.QueueId);

            builder
                .HasOne(x => x.ScheduleDay)
                .WithMany(x => x.Custumers)
                .HasForeignKey(x => x.ScheduleId);
        }
    }
}
