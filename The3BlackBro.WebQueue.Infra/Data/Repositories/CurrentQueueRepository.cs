using Microsoft.EntityFrameworkCore;
using The3BlackBro.WebQueue.Domain.Entities;
using The3BlackBro.WebQueue.Domain.Interface.Repository;
using The3BlackBro.WebQueue.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace The3BlackBro.WebQueue.Infra.Data.Repositories {
    public class CurrentQueueRepository : RepositoryBase<CurrentQueue>, ICurrentQueueRepository {
        private IWebQueueContext Context { get; }

        public CurrentQueueRepository(IWebQueueContext context) {
            Context = context;
        }

        /// <summary>
        /// Valida se a fila está vazia.
        /// </summary>
        /// <returns></returns> 
        public bool IsQueueEmpty(int companyId, int queueId) {
            return !Context.Custumer
                          .Any(x => x.CurrentQueue.CompanyId == companyId
                                 && !x.IsServiceDone && x.QueueId == queueId);
        }

        /// <summary>
        /// Valida se existe alguma fila aberta para empresa.
        /// </summary>
        /// <returns></returns>
        public bool IsThereQueueStarted(int? companyId) {
            return Context.Queue
                          .Any(x => x.IsWorking && x.CompanyId == companyId);

        }

        /// <summary>
        /// Recupera todas as filas disponíveis de todas as empresas.
        /// </summary>
        /// <param name="page">Página que será recuperada.</param>
        /// <param name="qtd">Quantidade de registros por página.</param>
        /// <returns></returns>
        public ICollection<CurrentQueue> GetAllCurrentQueues(int page, int qtd) {
            int skip = (page - 1) * qtd;

            return Context.Queue
                          .Where(x => x.IsWorking)
                          .Skip(skip)
                          .Take(qtd)
                          .AsNoTracking()
                          .OrderBy(x => x.RegisteringDate)
                          .ToArray();
        }


        /// <summary>
        /// Recupera, se existir, a fila aberta para empresa.
        /// </summary>
        /// <returns></returns>
        public CurrentQueue GetCurrentQueue(int companyId) {
            return Context.Queue
                          .Include(x => x.Company)
                          .ThenInclude(x => x.User)
                          .AsNoTracking()
                          .FirstOrDefault(x => x.CompanyId == companyId && x.IsWorking);
        }

        /// <summary>
        /// Recupera todos os clientes de uma fila
        /// </summary>
        /// <param name="companyId">Id da empresa.</param>
        /// <returns></returns>
        public ICollection<Customer> GetAllCostumersInCurrentQueue(int companyId) {
            return Context.Custumer
                          .Include(x => x.User)
                          .Where(x => x.CurrentQueue.CompanyId == companyId && !x.IsServiceDone)
                          .OrderBy(x => x.Id)                         
                          .Distinct()
                          .AsNoTracking()
                          .ToArray();

        }

        /// <summary>
        /// Recupera todos os clientes na fila atualmente.
        /// </summary>
        /// <param name="companyId">Id da empresa</param>
        /// <returns></returns>
        public ICollection<Customer> GetAllCustumersInCurrentQueue(int companyId) {
            return Context.Custumer
                          .Where(x => x.CurrentQueue.CompanyId == companyId && !x.IsServiceDone)
                          .OrderBy(x => x.Id)
                          .AsNoTracking()
                          .ToList();
        }

        /// <summary>
        /// Recupera a próxima posição para inserção na fila.
        /// </summary>
        /// <param name="companyId">Id da empresa.</param>
        /// <param name="queueId">Id da fila.</param>
        /// <returns></returns>
        public int GetNextPositionInQueue(int companyId, int queueId) {
            if (IsQueueEmpty(companyId, queueId))
                return 1;

            return Context.Custumer
                          .Where(x => x.CurrentQueue.CompanyId == companyId && !x.IsServiceDone)
                          .Select(x => x.QueuePosition).Max() + 1;
        }

        /// <summary>
        /// Recupera a posição do último na fila.
        /// </summary>
        /// <param name="companyId">Id da empresa.</param>
        /// <returns></returns>
        public User GetLastInCurrentQueue(int companyId) {
            return Context.Custumer
                          .Include(x => x.User)
                          .Where(x => x.CurrentQueue.CompanyId == companyId && !x.IsServiceDone)
                          .OrderByDescending(x => x.QueuePosition)
                          .Take(1)
                          .Select(x => x.User)
                          .FirstOrDefault();
        }
    }
}
