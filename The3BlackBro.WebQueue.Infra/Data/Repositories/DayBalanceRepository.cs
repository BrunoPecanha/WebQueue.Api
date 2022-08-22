using The3BlackBro.WebQueue.Domain.Entities;
using The3BlackBro.WebQueue.Domain.Interface.Repository;
using The3BlackBro.WebQueue.Infra.Context;
using System.Linq;

namespace The3BlackBro.WebQueue.Infra.Data.Repositories
{
    public class DayBalanceRepository : RepositoryBase<DayBalance>, IDayBalanceRepository
    {
        private IWebQueueContext _dbContext { get; }

        public DayBalanceRepository(IWebQueueContext context)
        {
            _dbContext = context;
        }     

        /// <summary>
        /// Recupera o saldo do dia através do company id recebido
        /// </summary>
        /// <param name="companyId">Identificação da empresa.</param>
        /// <returns></returns>
        public decimal DayAmount(int companyId)
        {
            return _dbContext.DayBalance
                      .FirstOrDefault(x => x.CompanyId == companyId)
                      .Amount;
        }

        public DayBalance GetDayBalanceById(int companyId, int queueId)
        {
            return _dbContext.DayBalance
                      .FirstOrDefault(x => x.CompanyId == companyId && x.QueueId == queueId);                      
        }
    }
}
