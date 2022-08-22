using Microsoft.EntityFrameworkCore;
using The3BlackBro.WebQueue.Domain.Entities;

namespace The3BlackBro.WebQueue.Infra.Context {
    public interface IWebQueueContext
    {
        DbSet<Customer> Custumer { get; }
        DbSet<CurrentQueue> Queue { get; }
        DbSet<ScheduleDay> ScheduleDay { get; }
        DbSet<ServiceType> ServiceType { get; }
        DbSet<Company> Company { get; }
        DbSet<User> User { get; }
        DbSet<CustumerXServices> CustumerSelectedServices { get; }
        DbSet<ScheduleDayXCustumers> ScheduleDayCustumers { get; }
        DbSet<DayBalance> DayBalance { get; }
    }
}
