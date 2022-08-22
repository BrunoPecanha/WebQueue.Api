using System.ComponentModel.DataAnnotations;
using The3BlackBro.WebQueue.Domain.Entities;
using The3BlackBro.WebQueue.Domain.Enum;

namespace The3BlackBro.WebQueue.Service.Dto.EntitiesDto.Updating
{
    public class UpdatingUserDto
    {
        /// <summary>
        /// Informações do aparelho.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório")]
        [Display(Name = "MobileInfo")]
        public int MobileInfo { get; set; }

        /// <summary>
        /// Nome do usuário
        /// </summary>   
        public string Name { get; set; }

        /// <summary>
        /// Sobrenome do usuário
        /// </summary>       
        public string LastName { get; set; }

        //TODO - Ver como enviar e gravar imagens no BD
        /// <summary>
        /// Foto do usuário
        /// </summary>      
        public string Picture { get; set; }
        /// <summary>
        /// Email do usuário
        /// </summary>        
        public string Email { get; set; }

        //  public string Login { get; set; }
        /// <summary>
        /// Senha do usuário
        /// </summary>        
        public string PassWord { get; set; }
        /// <summary>
        /// Indica se o usuário é o proprietário.
        /// </summary>       
        public bool Owner { get; set; }
        /// <summary>
        /// Indica se o usuário é o funcionário.
        /// </summary>       
        public bool Employee { get; set; }

        /// <summary>
        /// Gera uma instância de User a partir do container
        /// </summary>
        /// <returns></returns>
        public User ToEntity() {
            return new User(Name, LastName, Email, PassWord, (MobileEnum)MobileInfo, Picture,  Owner, Employee);
        }
    }
}