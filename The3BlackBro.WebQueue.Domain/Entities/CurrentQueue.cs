using System;
using System.Collections.Generic;

namespace The3BlackBro.WebQueue.Domain.Entities {
    /// <summary>
    /// Classe que cuida dos clientes da fila
    /// </summary>
    public class CurrentQueue : To {

        private CurrentQueue() {
        }

        public CurrentQueue(int companyId, bool isWorking) {
            CompanyId = companyId;
            IsWorking = isWorking;
        }

        /// <summary>
        /// Id da empresa.
        /// </summary>
        public int CompanyId { get; private set; }

        /// <summary>
        /// Empresa associada à fila
        /// </summary>
        public virtual Company Company { get; private set; }

        /// <summary>
        /// Valida se já existe fila funcionando.
        /// </summary>
        public bool IsWorking { get; private set; }

        /// <summary>
        /// Saldo do dia.
        /// </summary>
        public virtual DayBalance DayBalance { get; set; }

        /// <summary>
        /// Propriedade de ligação entre cliente e a fila
        /// </summary>
        public ICollection<Customer> Custumers { get; private set; }        
        
        // <summary>
        /// Hora que foi finalizada a fila do dia
        /// </summary>
        public DateTime FinalizationTime { get; private set; }

        /// <summary>
        /// Atualiza a empresa | 
        /// </summary>
        /// <param name="id">Id da nova empresa</param>
        public void UpdateCompany(int id) {
            this.CompanyId = id;
        }     

        /// <summary>
        /// Caso este método seja 
        /// </summary>
        public void UpdateIsWorking(bool isWorking) {
            this.IsWorking = isWorking;
        }

        /// <summary>
        /// Encerra o dia da fila.
        /// </summary>
        public void EndQueue() {
            this.IsWorking = false;
            this.FinalizationTime = DateTime.Now;
        }
    }
}
