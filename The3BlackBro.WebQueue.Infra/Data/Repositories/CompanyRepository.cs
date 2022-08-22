using Microsoft.EntityFrameworkCore;
using The3BlackBro.WebQueue.Domain.Entities;
using The3BlackBro.WebQueue.Domain.Interface.Repository;
using The3BlackBro.WebQueue.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace The3BlackBro.WebQueue.Infra.Data.Repositories {
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository {
        private const string _companyWasnFound = "Company was not found";

        private IWebQueueContext _dbContext { get; }

        public CompanyRepository(IWebQueueContext dbContext) {
            _dbContext = dbContext;
        }

        public Company GetCompanyById(int id) {
            return _dbContext.Company
                             .Include(x => x.User)
                             .FirstOrDefault(x => x.Id == id && x.Activated);
        }

        /// <summary>
        /// Cadastro do usuário sem celular
        /// </summary>
        /// <param name="nome">Nome</param>
        /// <param name="lastName">Sobrenome</param>
        /// <param name="login">Login ( Tirar isso )</param>
        /// <param name="passWord"></param>
        /// <returns></returns>
        public bool RegisterUserWithOutPhone(string nome, string lastName, string login, string passWord) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Rotina para o usuário administrador inserir cliente em um horário marcado
        /// </summary>
        /// <param name="userId">Id do usuário</param>
        /// <param name="serviceListIds">Lista de id's dos serviços</param>
        /// <returns></returns>
        public bool InsertCustumerInHour(int userId, IList<int> serviceListIds) {
            throw new NotImplementedException();
        }

        public Company GetCompanyAndUserById(int id) {
            var company = _dbContext.Company.FirstOrDefault(x => x.Id == id);

            if (company is null) {
                throw new Exception(string.Format(_companyWasnFound));
            }
            return company;
        }

        /// <summary>
        /// Rotina para o usuário administrador inserir cliente no meio da fila
        /// </summary>
        /// <param name="userId">Id do usuário</param>
        /// <param name="serviceListIds">Lista de id's dos serviços</param>
        /// <returns></returns>
        public bool InsertCustumerInQueue(int userId, IList<int> serviceListIds) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Valida se uma empresa possui qualquer transação. 
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public bool CompanyHasTransactions(int companyId) {
            return _dbContext.Company
                            .Include(x => x.User)
                            .ThenInclude(x => x.Customer)
                            .Any(x => x.Id == companyId);
        }
    }
}

