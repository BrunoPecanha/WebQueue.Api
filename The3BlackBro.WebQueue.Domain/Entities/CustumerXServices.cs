using The3BlackBro.WebQueue.Domain.Entities;

namespace The3BlackBro.WebQueue.Domain.Entities {
    public class CustumerXServices : To
    {
        private CustumerXServices() {
        }

        public CustumerXServices(ServiceType serviceType, Customer custumer) {           
            this.CustumerId = custumer.Id;        
            this.ServiceId = serviceType.Id;
        }

        /// <summary>
        /// Id do Cliente.
        /// </summary>
        public int CustumerId { get; private set; }
        /// <summary>
        /// Propriedade que indica que é um relacionamento NxM
        /// </summary>
        public virtual Customer Custumer { get; private set; }
        /// <summary>
        /// Propriedade que indica que é um relacionamento NxM
        /// </summary>
        public int ServiceId { get; private set; }
        /// <summary>
        /// Propriedade que indica que é um relacionamento NxM
        /// </summary>
        public virtual ServiceType Service { get; private set; }        

        public void UpdateService(int serviceId) {
            this.ServiceId = serviceId;
        }
    }
}
