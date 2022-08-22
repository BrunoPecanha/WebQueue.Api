using The3BlackBro.WebQueue.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace The3BlackBro.WebQueue.Service.Dto.EntitiesDto.Updating
{
    public class UpdatingCompanyDto {
        /// <summary>
        /// Id da empresa que será atualizada.
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Id")]
        public int Id { get; set; }
        /// <summary>
        /// Nome fanatasia da empresa.
        /// </summary>        
        [Display(Name = "FantasyName")]
        public string FantasyName { get; set; }

        /// <summary>
        /// Razão Social da empresa
        /// </summary>        
        [Display(Name = "RealName")]
        public string RealName { get; set; }

        /// <summary>
        /// CNPJ da empresa
        /// </summary>        
        [Display(Name = "Cnpj")]
        public string Cnpj { get; set; }

        /// <summary>
        /// Endereço da empresa
        /// </summary>        
        [Display(Name = "Address")]
        public string Address { get; set; }

        /// <summary>
        /// Forma como trabalha ( Agendado ou Fila )
        /// </summary>        
        [Display(Name = "UseQueue")]
        public bool UseQueue { get; set; }    
        
        /// <summary>
        /// Logo do estabelecimento
        /// </summary>        
        [Display(Name = "Logo")]
        public string Logo { get; set; }

        /// <summary>
        /// Flag que indica se haverá aviso de chamada no App.
        /// </summary>        
        [Display(Name = "ConfirmationNotice")]
        public bool ConfirmationNotice { get; set; }

        /// <summary>
        /// Id do usuário proprietário
        /// </summary>        
        [Display(Name = "UserId")]
        public int UserId { get; set; }


        public Company ToEntity() {
            return new Company(FantasyName, RealName, Cnpj, Address, UseQueue, Logo, ConfirmationNotice, UserId);           
        }
    }
}