using System.ComponentModel.DataAnnotations;

namespace The3BlackBro.WebQueue.Service.Dto.EntitiesDto.Creating
{
    public class CreatingScheduleDayDto {
        /// <summary>
        /// Nome fanatasia da empresa.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório")]
        [Display(Name = "FantasyName")]
        public string FantasyName { get; set; }
    }
}