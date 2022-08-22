using The3BlackBro.WebQueue.Domain.Entities;
using System.Collections.Generic;

namespace The3BlackBro.WebQueue.Domain.Interface.Service {
    public interface ICurrentQueueService : IServiceBase<CurrentQueue> {
        CurrentQueue StartQueue(CurrentQueue queue);
        ICollection<CurrentQueue> GetAllCurrentQueues(int page, int qtd);
        void FinishQueue(int companyId, int userId);
        ICollection<Customer> GetAllCustumersInCurrentQueue(int companyId);
        User GetLastInCurrentQueue(int companyId);
        bool IsThereQueueStarted(int companyId);
        CurrentQueue GetCurrentQueue(int companyId);
    }
}
