using The3BlackBro.WebQueue.Domain.Entities;
using The3BlackBro.WebQueue.Domain.Interface.Repository;
using The3BlackBro.WebQueue.Domain.Interface.Service;
using The3BlackBro.WebQueue.Service.Properties;

namespace The3BlackBro.WebQueue.Service.Services
{
    public class DayBalanceService : ServiceBase<DayBalance>, IDayBalanceService
    {
        private readonly IDayBalanceRepository _dayBalanceRepositoy;
        private readonly ICurrentQueueRepository _currentQueueRepository;
        private readonly ICompanyRepository _companyRepository;

        public DayBalanceService(IDayBalanceRepository repository, ICurrentQueueRepository currentQueueRepository, ICompanyRepository companyRepository)
            : base(repository)
        {
            _dayBalanceRepositoy = repository;
            _currentQueueRepository = currentQueueRepository;
            _companyRepository = companyRepository;
        }

        public decimal DayAmount(int companyId)
        {
            return _dayBalanceRepositoy.DayAmount(companyId);
        }

        public DayBalance GetDayBalanceById(int companyId, int queueId)
        {
            return _dayBalanceRepositoy.GetDayBalanceById(companyId, queueId);
        }

        /// <summary>
        /// Saque do saldo do dia.
        /// </summary>
        /// <param name="companyId">Id da empresa</param>
        /// <param name="value">Valor a ser sacado.</param>
        public void Withdraw(int companyId, decimal value)
        {

            if (!_currentQueueRepository.IsThereQueueStarted(companyId))
            {
                throw new Exception(string.Format(Resources.mThereNoAmountForToday, companyId));
            }

            Company company = _companyRepository.GetById(companyId);
            CurrentQueue currentQueue = _currentQueueRepository.GetCurrentQueue(companyId);

            if (company is null)
            {
                throw new Exception(string.Format(Resources.mNoCompanyWasFoundWithId, companyId));
            }

            DayBalance dayBalance = _dayBalanceRepositoy.GetDayBalanceById(companyId, currentQueue.Id);
            dayBalance.WithDraw(value);
            _dayBalanceRepositoy.Update(dayBalance);
        }

        public void Deposit(int companyId, decimal value)
        {
            if (!_currentQueueRepository.IsThereQueueStarted(companyId))
            {
                throw new Exception(string.Format(Resources.mThereNoAmountForToday, companyId));
            }

            Company company = _companyRepository.GetById(companyId);
            CurrentQueue currentQueue = _currentQueueRepository.GetCurrentQueue(companyId);

            if (company is null)
            {
                throw new Exception(string.Format(Resources.mNoCompanyWasFoundWithId, companyId));
            }

            DayBalance dayBalance = _dayBalanceRepositoy.GetDayBalanceById(companyId, currentQueue.Id);
            dayBalance.Deposit(value);
            _dayBalanceRepositoy.Update(dayBalance);
        }
    }
}
