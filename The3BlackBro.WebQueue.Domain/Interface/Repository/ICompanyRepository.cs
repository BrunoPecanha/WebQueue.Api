
using The3BlackBro.WebQueue.Domain.Entities;
using System.Collections.Generic;

namespace The3BlackBro.WebQueue.Domain.Interface.Repository {
    public interface ICompanyRepository : IRepositoryBase<Company> {

        /// <summary>
        /// Recupera
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Company GetCompanyById(int id);

        /// <summary>
        /// Rotina que verifica se uma empresa pode ou não ser excluída. Caso não possa ser removida da base, marca o flag de ativo para false.
        /// </summary>
        /// <param name="companyId">Id da empresa.</param>
        /// <returns></returns>
        bool CompanyHasTransactions(int companyId);

        /// <summary>
        /// Inseri o usuário ( convertido para cliente ) na fila atual
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="serviceListIds"></param>
        /// <returns></returns>
        bool InsertCustumerInHour(int userId, IList<int> serviceListIds);

        /// <summary>
        /// Rotina exclusiva para o proprietário incluir usuários que não possuem celular na fila.
        /// </summary>
        /// <param name="nome">Nome do novo usuário.</param>
        /// <param name="lastName">Sobrenome do novo usuário.</param>
        /// <param name="login">Login escolhido.</param>
        /// <param name="passWord">Senha escolhida.</param>
        /// <returns></returns>
        bool RegisterUserWithOutPhone(string nome, string lastName, string login, string passWord);

    }
}
