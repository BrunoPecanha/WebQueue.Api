using System.ComponentModel.DataAnnotations;
using The3BlackBro.WebQueue.Domain.Entities;

namespace The3BlackBro.WebQueue.Service.Dto.EntitiesDto.Creating
{
    public class CreatingCustomerDto
    {
        /// <summary>
        /// Id da empresa a qual será associado o usuário.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório")]
        [Display(Name = "CompanyId")]
        public int CompanyId { get; set; }

        /// <summary>
        /// Id da fila que o usuário ser inserido.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório")]
        [Display(Name = "QueueId")]
        public int QueueId { get; set; }

        /// <summary>
        /// Objeto usuário que será atribuído o serviço.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório")]
        [Display(Name = "UserId")]
        public int UserId { get; set; }

        /// <summary>
        /// Objeto usuário que será atribuído o serviço.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Comment")]
        public string Comment { get; set; }

        /// <summary>
        /// Lista de serviços escolhidos pelo usuário.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório")]
        [Display(Name = "ServiceList")]
        public int[] ServiceList { get; set; }

        public Customer ToEntity() {
            return new Customer(UserId, QueueId, Comment, 0);
        }
    }
}