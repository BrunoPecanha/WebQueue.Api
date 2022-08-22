using Newtonsoft.Json;
using System.Collections.Generic;

namespace The3BlackBro.WebQueue.Domain.Entities {
    public class ServiceType : To {

        private ServiceType() {
        }

        public ServiceType(string nome, int mediumTime, decimal price, int companyId) {
            Name = nome;
            MediumTime = mediumTime;
            Price = price;
            CompanyId = companyId;
        }
        /// <summary>
        /// Indica se o serviço está ativo
        /// </summary>
        public bool Activated { get; private set; }
        /// <summary>
        /// Nome do Serviço
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Tempo médio de espera
        /// </summary>
        public int MediumTime { get; private set; }
        /// <summary>
        /// Preço do serviço
        /// </summary>
        public decimal Price { get; private set; }

        public int CompanyId { get; private set; }

        public string Img { get; private set; }

        public virtual Company Company { get; private set; }

        /// <summary>
        /// Referência dos serviços selecionados pelo cliente
        /// </summary>
        [JsonIgnore]
        public virtual ICollection<CustumerXServices> CustumerServices { get; private set; }  
        
        //TODO - Método administrador geral para alterar uma empresa dona de um serviço

        public void UpdateCompany(int id) {
            this.CompanyId = id;
        }

        public void UpdateServiceName(string serviceName) {
            if (!string.IsNullOrEmpty(serviceName))
                this.Name = serviceName;
        }

        public void Validate() {
           // Validar se os campos estão Ok
           // Lançar exceção senão estiverem
        }

        public void UpdateMediumTime(int mediumTime) {
            if (mediumTime > 0)
                this.MediumTime = mediumTime;
        }

        public void UpdatePrice(decimal value) {
            if (value > 0)
                this.Price = value;
        }

        public void UpdataServiceStatus(bool isActivated) {
            this.Activated = isActivated;
        }
    }
}
