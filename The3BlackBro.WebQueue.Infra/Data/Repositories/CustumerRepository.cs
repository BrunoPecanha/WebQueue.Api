using Microsoft.EntityFrameworkCore;
using The3BlackBro.WebQueue.Domain.Entities;
using The3BlackBro.WebQueue.Domain.Interface.Repository;
using The3BlackBro.WebQueue.Infra.Context;
using System.Collections.Generic;
using System.Linq;

namespace The3BlackBro.WebQueue.Infra.Data.Repositories {
    public class CustumerRepository : RepositoryBase<Customer>, ICustumerRepository {
        private IWebQueueContext _dbContext { get; }

        public CustumerRepository(IWebQueueContext context) {
            _dbContext = context;
        }

        /// <summary>
        /// Verifica se um cliente já está inserido numa fila.
        /// </summary>
        /// <param name="userId">Id do usuário.</param>
        /// <returns></returns>
        // TODO - MELHORAR A BUSCA COM O ID COMPANY
        public bool IsCustomerAlreadyInQueue(int userId) {
            return _dbContext.Custumer
                             .Any(x => x.UserId == userId && !x.IsServiceDone);
        }

        /// <summary>
        /// Recupera o atual cliente em atendimento
        /// </summary>
        /// <param name="companyId">Id da empresa para localizar a fila.</param>
        /// <returns></returns>
        public Customer CallNextCustomerInQueue(int queueId) {
            return _dbContext.Custumer
                             .OrderBy(x => x.QueuePosition)
                             .FirstOrDefault(x => x.QueueId == queueId && !x.IsServiceDone);
        }

        /// <summary>
        /// Recupera os cliente que batem com a string passada 
        /// </summary>
        /// <param name="name">Parte do nome ou nome do usuário procurado.</param>
        /// <returns>Lista com todos os usuários que batem com a pesquisa.</returns>
        public IList<Customer> GetCustomerByName(string name) {
            return _dbContext.Custumer
                             .Include(x => x.User)
                             .Where(x => x.User.Name.Contains(name))                            
                             .ToArray();
        }
    }
}

