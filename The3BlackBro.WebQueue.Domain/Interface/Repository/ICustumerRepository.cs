using The3BlackBro.WebQueue.Domain.Entities;
using System.Collections.Generic;

namespace The3BlackBro.WebQueue.Domain.Interface.Repository {
    public interface ICustumerRepository : IRepositoryBase<Customer> {       
        bool IsCustomerAlreadyInQueue(int userId);
        Customer CallNextCustomerInQueue(int queueId);
        IList<Customer> GetCustomerByName(string name);
    }
}
