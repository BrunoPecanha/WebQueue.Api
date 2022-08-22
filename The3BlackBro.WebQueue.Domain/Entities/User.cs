using The3BlackBro.WebQueue.Domain.Enum;

namespace The3BlackBro.WebQueue.Domain.Entities
{
    public class User : To
    {
        private User() {
        }

        public User(string name, string lastName,  string email,
            string passWord, MobileEnum mobileInfo, string picture, bool owner = false, bool employee = false) {
            Name = name;
            LastName = lastName;
            Picture = picture;            
            Email = email;
            PassWord = passWord;
            Owner = owner;
            Employee = employee;
            Activated = true;
            MobileInfo = mobileInfo;
        }

        /// <summary>
        /// Foto do usuário
        /// </summary>
        public string Picture { get; private set; }

        /// <summary>
        /// Indica se o usuário está ativo
        /// </summary>
        public bool Activated { get; private set; }

        /// <summary>
        /// Nome do Usuário
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Sobrenome do usuário
        /// </summary>
        public string LastName { get; private set; }

        /// <summary>
        /// Foto do usuário.
        /// </summary>
        //[NotMapped]
        //public IFormFile Picture { get; private set; }

        /// <summary>
        /// Última visita do usuário ao estabelecimento.
        /// </summary>
        public DateTime LastVisitDate { get; private set; }
        /// <summary>
        /// Email do usuarário
        /// </summary>
        public string Email { get; private set; }
        /// <summary>
        /// Senha do usuário para acesso ao sistema
        /// </summary>
        public string PassWord { get; private set; }

        /// <summary>
        /// Informações do aparelho
        /// </summary>
        public MobileEnum MobileInfo { get; private set; }

        /// <summary>
        /// Indica se o usuário é propritário
        /// </summary>
        public bool Owner { get; private set; }

        /// <summary>
        /// Indica se o usuário é funcionário
        /// </summary>
        public bool Employee { get; private set; }

        /// <summary>
        /// Id da empresa caso o usuário seja proprietário.
        /// </summary>
        public int? CompanyId { get; private set; }

        ///// <summary>
        ///// Propriedade de navegação.
        ///// </summary>
        public virtual Company Company { get; private set; }

        /// <summary>
        /// Lista dos clientes
        /// </summary>
        public ICollection<Customer> Customer { get; private set; }

        /// <summary>
        /// Atualiza o nome do usuário.
        /// </summary>
        /// <param name="name">Nome do usuário.</param>
        public void UpdateName(string name) {
            if (!string.IsNullOrEmpty(name)) {
                this.Name = name;
            }
        }

        /// <summary>
        /// Atualiza o sobrenome do usuário.
        /// </summary>
        /// <param name="lastName">Novo sobrenome</param>
        public void UpdateLastName(string lastName) {
            if (!string.IsNullOrEmpty(lastName)) {
                this.LastName = lastName;
            }
        }

        /// <summary>
        /// Atualiza a foto do usuário.
        /// </summary>
        /// <param name="picture">Array de bytes da foto do usuário.</param>
        public void UpdatePicture(string picture) {
            if (!(picture is null)) {
              //  this.Picture = picture;
            }
        }

        /// <summary>
        /// Atualiza a última visita do usuário para a data atual.
        /// </summary>
        public void UpdateLastVisitDate() {
            this.LastVisitDate = DateTime.Now;
        }

        /// <summary>
        /// Atualiza o email do usuário.
        /// </summary>
        /// <param name="email">Novo email do usuário</param>
        public void UpdateEmail(string email) {
            if (!string.IsNullOrEmpty(email)) {
                this.Email = email;
            }
        }       

        /// <summary>
        /// Atualiza a senha do usuário
        /// </summary>
        /// <param name="password">Nova senha.</param>
        public void UpdatePassword(string password) {
            if (!string.IsNullOrEmpty(password)) {
                this.PassWord = password;
            }
        }

        /// <summary>
        /// Atualiaza se o usuário é proprietário
        /// </summary>
        /// <param name="isOwner">Boleano indicador.</param>
        public void UpdateOwner(bool isOwner) {
            this.Owner = isOwner;
        }

        /// <summary>
        /// Só quem pode usar desta função são admnistradores do sistema.
        /// Verifica se se trata de exclusão. Se for, põe o id para 0, do contrário trata como troca de proprietário.
        /// </summary>
        /// <param name="company">Nova empresa que será associada ao usuário.</param>
        /// /// <param name="IsDeleting">Valida se se trata de uma exclusão.</param>
        public void UpdateCompany(Company company, bool IsDeleting) {
            if (IsDeleting) {
                this.CompanyId = 0;
            } else {
                this.CompanyId = company.Id;
            }
        }

        /// <summary>
        /// Desabilita o usuário caso ele possua transações registradas
        /// </summary>
        /// <param name="isActivated">Flag que indica se desativa / ativa o usuário.</param>
        public void UpdateActivated(bool isActivated) {
            this.Activated = isActivated;
        }
    }
}
