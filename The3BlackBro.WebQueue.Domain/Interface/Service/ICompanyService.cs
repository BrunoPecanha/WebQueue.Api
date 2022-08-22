using The3BlackBro.WebQueue.Domain.Entities;
using System.Collections.Generic;

namespace The3BlackBro.WebQueue.Domain.Interface.Service {
    public interface ICompanyService : IServiceBase<Company> {
        bool CompanyHasTransactions(int companyId);

        void UpdateCompany(Company company);

        void RemoveCompany(int id);

        void CreateNewCompany(Company company);
        /// <summary>
        /// Rotina exclusiva para o proprietário incluir usuários que não possuem celular na fila.
        /// </summary>
        /// <param name="nome">Nome do novo usuário.</param>
        /// <param name="lastName">Sobrenome do novo usuário.</param>
        /// <param name="login">Login escolhido.</param>
        /// <param name="passWord">Senha escolhida.</param>
        /// <returns></returns>
        User RegisterUserWithOutPhone(User user);
        /// <summary>
        /// Rotina exclusiva para o proprietário incluir clientes que não possuem celular na fila.
        /// </summary>
        /// <param name="serviceList">Lista de serviços que o usuário irá adquirir.</param>
        /// <param name="user">Objeto usuário.</param>
        /// <returns></returns>
        bool CreatingCustumerWithOutPhone(ICollection<ServiceType> serviceList, User user);
    }
}
