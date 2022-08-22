using System.Collections.Generic;

namespace The3BlackBro.WebQueue.Domain.Entities {
    /// <summary>
    /// Classe que trata da empresa.
    /// </summary>
    public class Company : To
    {
        private Company() {
        }

        public Company(string fantasyName, string realName, string cnpj, string address, bool useQueue, string logo, bool confirmationNotice, int userId) {
            FantasyName = fantasyName;
            RealName = realName;
            Cnpj = cnpj;
            Address = address;
            UseQueue = useQueue;
            Logo = logo;
            ConfirmationNotice = confirmationNotice;
            UserId = userId;
        }

        /// <summary>
        /// Indica se a empresa está ativa
        /// </summary>
        public bool Activated { get; private set; }

        /// <summary>
        /// Nome fantasia da empresa
        /// </summary>
        public string FantasyName { get; private set; }
        /// <summary>
        /// Razaão Social
        /// </summary>
        public string RealName { get; private set; }
        /// <summary>
        /// Cnpj da empresa
        /// </summary>
        public string Cnpj { get; private set; }
        /// <summary>
        /// Endereço da empresa
        /// </summary>
        public string Address { get; private set; }     

        /// <summary>
        /// Tipo funcionamento | Fila ou Agenda
        /// </summary>
        public bool UseQueue { get; private set; }
        /// <summary>
        /// Logo do estabelecimento
        /// </summary>
        public string Logo { get; private set; }
        /// <summary>
        /// Flag que indica se haverá aviso de chamada no App.
        /// </summary>
        public bool ConfirmationNotice { get; private set; }
        /// <summary>
        /// Id referente ao usuário
        /// </summary>
        public int UserId { get; private set; }
        /// <summary>
        /// Instância do usuário em Company
        /// </summary>
        public virtual User User { get; private set; }
        /// <summary>
        /// Id do fila ativa
        /// </summary>
        public int? LastQueueId { get; set; }
        /// <summary>
        /// Propriedade da fila de navegação do EF.
        /// </summary>
        public virtual ICollection<CurrentQueue> Queue { get; private set; }
        public virtual ICollection<ServiceType>  ServiceTypes{ get; private set; }

        public virtual ICollection<DayBalance> DayBalances { get; private set; }
        /// <summary>
        /// Método que valida se um CNPJ é válido.
        /// </summary>
        /// <param name="cnpj">Entrada do usuário.</param>
        /// <returns></returns>
        private bool ValidateCNPJ(string cnpj) {
            return true;
        }

        public void UpdateUser(int id) {
            this.UserId = id;
        }

        public void UpdateFantasyName(string newFantasyName) {
            if (!string.IsNullOrEmpty(newFantasyName)) {
                this.FantasyName = newFantasyName;
            }
        }

        public void UpdateRealName(string newRealName) {
            if (!string.IsNullOrEmpty(newRealName)) {
                this.RealName = newRealName;
            }
        }

        public void UpdateCnpj(string newCnpj) {
            if (!string.IsNullOrEmpty(newCnpj) && this.ValidateCNPJ(newCnpj)) {
                this.Cnpj = newCnpj;
            }
        }

        public void UpdateQueue(int  id) {
            this.LastQueueId = id;
            this.Queue = null;
        }

        public void UpdateAdress(string newAdress) {
            if (!string.IsNullOrEmpty(newAdress)) {
                this.Address = newAdress;
            }
        }

        public void UpdateWorkType(bool workType) {
            this.UseQueue = workType;
        }

        public void UpdateActivated(bool activated)
        {
            this.Activated = activated;
        }

        public void UpdateLogo(string logo) {
            if (!string.IsNullOrEmpty(logo)) {
                this.Logo = logo;
            }
        }

        public void UpdateOwnerUser(User user) {
            if (user != null)
                this.User = user;
        }

        public void UpdateConfirmationNotice(bool confirmationNotice) {
            this.ConfirmationNotice = confirmationNotice;
        }       
    }
}
