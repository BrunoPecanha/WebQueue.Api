using The3BlackBro.WebQueue.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace The3BlackBro.WebQueue.Service.Dto.EntitiesDto.Creating
{
    public class CreatingServiceTypeDto
    {
        /// <summary>
        /// Id da empresa dona do serviço.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório")]
        [Display(Name = "CompanyId")]
        public int CompanyId { get; set; }
        /// <summary>
        /// Nome do serviço.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        /// <summary>
        /// Tempo médio de cada serviço
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório")]
        [Display(Name = "MediumTime")]
        public int MediumTime { get; set; }

        /// <summary>
        /// Preço do serviço.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        public ServiceType ToEntity() {
            return new ServiceType(Name, MediumTime, Price, CompanyId);
        }
    }
}