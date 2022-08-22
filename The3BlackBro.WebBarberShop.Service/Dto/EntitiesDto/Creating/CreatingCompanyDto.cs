using System.ComponentModel.DataAnnotations;
using The3BlackBro.WebQueue.Domain.Entities;

namespace The3BlackBro.WebQueue.Service.Dto.EntitiesDto.Creating {
    public class CreatingCompanyDto {
        /// <summary>
        /// Nome fanatasia da empresa.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório")]
        [Display(Name = "FantasyName")]
        public string FantasyName { get; set; }

        /// <summary>
        /// Razão Social da empresa
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório")]
        [Display(Name = "RealName")]
        public string RealName { get; set; }

        /// <summary>
        /// CNPJ da empresa
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Cnpj")]
        public string Cnpj { get; set; }

        /// <summary>
        /// Endereço da empresa
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        // <summary>
        /// Forma como trabalha ( Agendado ou Fila )
        /// </summary>        
        [Display(Name = "UseQueue")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório")]
        public bool UseQueue { get; set; }
        /// <summary>
        /// Logo do estabelecimento
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Logo")]
        public string Logo { get; set; }
        /// <summary>
        /// Flag que indica se haverá aviso de chamada no App.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório")]
        [Display(Name = "ConfirmationNotice")]
        public bool ConfirmationNotice { get; set; }
        /// <summary>
        /// Id do usuário proprietário
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório")]
        [Display(Name = "UserId")]
        public int UserId { get; set; }

        public Company ToEntity() {
            return new Company(FantasyName.ToUpper(), RealName.ToUpper(), Cnpj, Address.ToUpper(), UseQueue, Logo, ConfirmationNotice, UserId);
        }
    }
}