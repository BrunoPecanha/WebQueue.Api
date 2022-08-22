using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using The3BlackBro.WebQueue.Domain.Entities;

namespace The3BlackBro.WebBaberShop.Infra.Data.EntityConfig {
    public class ScheduleDayConfiguration : IEntityTypeConfiguration<ScheduleDay>
    {
        public void Configure(EntityTypeBuilder<ScheduleDay> builder) {

            builder
                .ToTable("ScheduleDay")
                .HasKey(x => x.Id);

            builder
                .Property(c => c.StartTime)
                .HasColumnName("StartTime")
                .HasColumnType("timestamp");

            builder
              .Property(c => c.EndTime)
              .HasColumnName("EndTime")
              .HasColumnType("timestamp");

            builder
              .Property(c => c.EstimatedTimeToNext)
              .HasColumnName("EstimatedTimeToNext")
              .HasColumnType("timestamp");

            builder
              .Property(x => x.LastUpdate)
              .HasColumnType("timestamp")
              .HasColumnName("LastUpdate");

            builder
             .Property(x => x.RegisteringDate)
             .HasColumnType("timestamp")
             .HasColumnName("RegisteringDate");

            //builder
            //.HasOne(c => c.Current)
            //.WithOne(s => s.ScheduleDay.ScheduleDay)
            //.HasForeignKey("ScheduleDayId");            
        }
    }
}

