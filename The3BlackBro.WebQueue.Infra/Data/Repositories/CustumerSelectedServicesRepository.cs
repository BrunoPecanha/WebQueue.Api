using Microsoft.EntityFrameworkCore;
using The3BlackBro.WebQueue.Domain.Entities;
using The3BlackBro.WebQueue.Domain.Interface.Repository;
using The3BlackBro.WebQueue.Infra.Context;
using System.Collections.Generic;
using System.Linq;

namespace The3BlackBro.WebQueue.Infra.Data.Repositories 
{
    public class CustumerSelectedServicesRepository : RepositoryBase<CustumerXServices>, ICustumerSelectedServicesRepository
    {
        private IWebQueueContext _dbContext { get; }
        public CustumerSelectedServicesRepository(IWebQueueContext context)
        {
            _dbContext = context;
        }

        public List<CustumerXServices> GetAllSelectedCustomerServices(int customerId)
        {
            return _dbContext.CustumerSelectedServices
                             .Include(x => x.Custumer)
                             .Where(x => x.Custumer.Id == customerId)
                             .ToList();
        }
    }
}
