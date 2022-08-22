using The3BlackBro.WebQueue.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace The3BlackBro.WebQueue.Service.Dto.EntitiesDto.Updating
{
    public class UpdatingServiceTypeDto {

        /// <summary>
        /// Id da empresa
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório")]
        [Display(Name = "CompanyId")]
        public int CompanyId { get; set; }
        /// <summary>
        /// Id do serviço.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório")]
        [Display(Name = "ServiceId")]
        public int ServiceId { get; set; }
        /// <summary>
        /// Indica se o serviço está ou não ativo.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Activated")]
        public bool Activated { get; set; }
        /// <summary>
        /// Nome do serviço.
        /// </summary>

        [Display(Name = "Name")]
        public string Name { get; set; }

        /// <summary>
        /// Tempo médio de cada serviço
        /// </summary>
     
        [Display(Name = "MediumTime")]
        public int MediumTime { get; set; }

        /// <summary>
        /// Preço do serviço.
        /// </summary>
  
        [Display(Name = "Price")]
        public decimal Price { get; set; } 

        public ServiceType ToEntity() {
            return new ServiceType(Name, MediumTime, Price, CompanyId);
        }
    }
}