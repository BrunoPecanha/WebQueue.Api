using System.ComponentModel.DataAnnotations;

namespace The3BlackBro.WebQueue.Service.Dto.EntitiesDto.Updating
{
    public class UpdatingQueueDto {       
        /// <summary>
        /// Objeto usuário que iniciará a fila.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório")]
        [Display(Name = "UserId")]
        public int UserId { get; set; } 
    }
}