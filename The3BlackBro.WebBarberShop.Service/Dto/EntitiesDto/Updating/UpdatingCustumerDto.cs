using System.ComponentModel.DataAnnotations;

namespace The3BlackBro.WebQueue.Service.Dto.EntitiesDto.Updating
{
    public class UpdatingCustumerDto {
        /// <summary>
        /// Id do cliente
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório")]
        [Display(Name = "CustomerId")]
        public int CustomerId { get; set; }

        // <summary>
        /// Id da empresa
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório")]
        [Display(Name = "CompanyId")]
        public int CompanyId { get; set; }

        /// <summary>
        /// Lista de serviços escolhidos pelo usuário.
        /// </summary>  
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório")]
        [Display(Name = "ServiceList")]
        public int[] ServiceList { get; set; }

        /// <summary>
        /// Objeto usuário que será atribuído o serviço.
        /// </summary>
        [Display(Name = "Comment")]
        public string Comment { get; set; }       
    }
}