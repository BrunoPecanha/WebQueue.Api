using The3BlackBro.WebQueue.Domain.Entities;

namespace The3BlackBro.WebQueue.Domain.Interface.Repository {
    public interface IDayBalanceRepository : IRepositoryBase<DayBalance>
    {
        /// <summary>
        /// Recupera o saldo do dia pelo id da empresa.
        /// </summary>
        /// <param name="companyId">Id da empresa.</param>
        /// <returns></returns>
        decimal DayAmount(int companyId);
        /// <summary>
        /// Recupera o saldo do dia pelo id da empresa e o da fila
        /// </summary>
        /// <param name="companyId">Id da empresa.</param>
        /// <param name="queueId">Id da fila.</param>
        /// <returns></returns>
        DayBalance GetDayBalanceById(int companyId, int queueId);
    }
}
