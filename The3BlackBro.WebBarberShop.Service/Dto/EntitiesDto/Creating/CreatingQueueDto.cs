using System.ComponentModel.DataAnnotations;
using The3BlackBro.WebQueue.Domain.Entities;

namespace The3BlackBro.WebQueue.Service.Dto.EntitiesDto.Creating {
    public class CreatingQueueDto {
        /// <summary>
        /// Objeto usuário que iniciará a fila.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório")]
        [Display(Name = "UserId")]
        public int UserId { get; set; }

        /// <summary>
        /// Objeto usuário que iniciará a fila.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório")]
        [Display(Name = "CompanyId")]
        public int CompanyId { get; set; }

        public CurrentQueue ToEntity() {
            return new CurrentQueue(CompanyId, true);
        }
    }
}