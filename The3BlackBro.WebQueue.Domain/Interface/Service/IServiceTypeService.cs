using The3BlackBro.WebQueue.Domain.Entities;

namespace The3BlackBro.WebQueue.Domain.Interface.Service
{
    public interface IServiceTypeService : IServiceBase<ServiceType> {
        ICollection<ServiceType> GetAllServicesType(int companyId, int page, int qtd);
        void UpdateService(ServiceType serviceType);
        void TryHardDelete(int id);
        void CreateNewService(ServiceType serviceDto);
        ServiceType GetServiceById( int id);
        ICollection<ServiceType> GetServicesByCustomer(int userId);
    }
}
