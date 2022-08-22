using The3BlackBro.WebQueue.Domain.Entities;

namespace The3BlackBro.WebQueue.Domain.Interface.Service {
    public interface IDayBalanceService : IServiceBase<DayBalance>
    {
        decimal DayAmount(int companyId);

        /// <summary>
        /// Recupera o saldo do dia para uma empresa e uma determinada fila.
        /// </summary>
        /// <param name="companyId">Id da empresa.</param>
        /// <param name="queueId">Id da fila.</param>
        /// <returns></returns>
        DayBalance GetDayBalanceById(int companyId, int queueId);
        void Withdraw(int companyId, decimal value);
        void Deposit(int companyId, decimal value);
    }
}
