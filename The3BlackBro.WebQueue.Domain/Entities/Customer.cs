using System;
using System.Collections.Generic;

namespace The3BlackBro.WebQueue.Domain.Entities {
    /// <summary>
    /// Classe que trata do cliente que será incluído na fila.
    /// </summary>
    public class Customer : To {
        private Customer() {
        }

        public Customer(int userId, int queueId, string comment, int queuePosition) {
            IsServiceDone = false;
            UserId = userId;
            Comment = comment.ToUpper();
            QueueId = queueId;
            QueuePosition = queuePosition;
        }

        /// Flag que indica se o serviço já foi concluído.
        /// </summary>
        public bool IsServiceDone { get; private set; }
        /// <summary>
        /// Id do usuário
        /// </summary>
        public int UserId { get; private set; }
        /// <summary>
        /// Referência do usuário com o cliente.
        /// </summary>
        public User User { get; private set; }
        /// <summary>
        /// Referência dos serviços selecionados pelo cliente
        /// </summary>
        public ICollection<CustumerXServices> CustumerServices { get; private set; }
        /// <summary>
        /// Data e hora que o serviço foi concluído
        /// </summary>
        public DateTime FinalizationDateAndTime { get; private set; }

        /// <summary>
        /// Posição do cliente na fila
        /// </summary>
        public int QueuePosition { get; set; }

        /// <summary>
        /// Identifica o cliente que está em atendimento.
        /// </summary>
        public bool CurrentCustomerInService { get; set; }

        /// <summary>
        /// Comentario opcional
        /// </summary>
        public string Comment { get; private set; }
        /// <summary>
        /// Id da fila 
        /// </summary>
        public int? QueueId { get; set; }
        public virtual CurrentQueue CurrentQueue { get; private set; }
        public int? ScheduleId { get; set; }
        public virtual ScheduleDay ScheduleDay { get; private set; }

        public void UpdateServiceStatus() {
            this.IsServiceDone = true;
            this.FinalizationDateAndTime = DateTime.Now;
            this.CurrentCustomerInService = false;
        }

        public void AddServiceToCustumer(CustumerXServices custumerXServices) {
            this.CustumerServices.Add(custumerXServices);
        }

        public void UpdateComment(string comment) {
            if (!string.IsNullOrEmpty(comment))
                this.Comment = comment.ToUpper();
        }

        public bool UpdateCustumerPositionInQueue(Customer customerOrin, Customer customerDest) {
            if (customerOrin is null || customerDest is null) {
                var positionTemp = customerOrin.QueuePosition;
                customerOrin.QueuePosition = customerDest.QueuePosition;
                customerDest.QueuePosition = positionTemp;

                return true;
            }
            return false;
        }
    }
}
