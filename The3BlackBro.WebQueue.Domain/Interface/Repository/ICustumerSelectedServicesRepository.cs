using The3BlackBro.WebQueue.Domain.Entities;
using System.Collections.Generic;

namespace The3BlackBro.WebQueue.Domain.Interface.Repository {
    public interface ICustumerSelectedServicesRepository : IRepositoryBase<CustumerXServices> {
        List<CustumerXServices> GetAllSelectedCustomerServices(int customerId);
        
    }
}
