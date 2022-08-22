using The3BlackBro.WebQueue.Domain.Entities;
using The3BlackBro.WebQueue.Domain.Interface.Repository;
using The3BlackBro.WebQueue.Domain.Interface.Service;

namespace The3BlackBro.WebQueue.Service.Services
{
    public class ScheduleDayService : ServiceBase<ScheduleDay>, IScheduleDayService {

        private readonly IScheduleDayRepository _repositoy;
        public ScheduleDayService(IScheduleDayRepository repository) 
            : base(repository) {
            _repositoy = repository;
        }       
    }
}
