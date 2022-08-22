using The3BlackBro.WebQueue.Domain.Entities;
using System.Collections.Generic;

namespace The3BlackBro.WebQueue.Domain.Interface.Repository {
    public interface IServiceTypeRepository : IRepositoryBase<ServiceType> {
        /// <summary>
        /// Recupera todos os serviços de acordo com o array de serviços recebido
        /// </summary>
        /// <param name="ids">Identificador dos serviços.</param>
        /// <returns></returns>
        ICollection<ServiceType> GetListByIds(int[] ids);
        ServiceType GetServiceById(int companyId, int serviceId);
        IList<ServiceType> GetServicesByCustomer(int customerId);
    }
}
