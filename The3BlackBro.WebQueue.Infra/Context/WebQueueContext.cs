using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using The3BlackBro.WebQueue.Domain.Entities;

namespace The3BlackBro.WebQueue.Infra.Context
{
    public class WebQueueContext : DbContext, IWebQueueContext {       
        public WebQueueContext(DbContextOptions<WebQueueContext> options)
                : base(options) {
        }


        public DbSet<Customer> Custumer { get; set; }
        public DbSet<CurrentQueue> Queue { get; set; }
        public DbSet<ScheduleDay> ScheduleDay { get; set; }
        public DbSet<ServiceType> ServiceType { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<CustumerXServices> CustumerSelectedServices { get; set; }
        public DbSet<ScheduleDayXCustumers> ScheduleDayCustumers { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<DayBalance> DayBalance { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(WebQueueContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            //optionsBuilder.UseLoggerFactory(_loggerFactory);
            //optionsBuilder.EnableSensitiveDataLogging();
            if (!optionsBuilder.IsConfigured) {
                  optionsBuilder.UseNpgsql(SqlHelper.ConnectionString);
            }

            optionsBuilder.UseNpgsql(SqlHelper.ConnectionString);
            optionsBuilder.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));
        }

        /// <summary>
        /// SaveChanges alterado para manter a data de registro do usuário inalterada após a inserção.
        /// </summary>
        /// <returns></returns>
        public override int SaveChanges() {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("RegisteringDate") != null)) {
                if (entry.State == EntityState.Added) {
                    entry.Property("RegisteringDate").CurrentValue = DateTime.Now;
                    entry.Property("LastUpdate").CurrentValue = DateTime.Now;
                } else if (entry.State == EntityState.Modified) {
                    entry.Property("RegisteringDate").IsModified = false;
                    entry.Property("Id").IsModified = false;
                    entry.Property("LastUpdate").CurrentValue = DateTime.Now;
                }
            }
            return base.SaveChanges();
        }
    }
}
