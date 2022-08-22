using The3BlackBro.WebQueue.Domain.Entities;
using The3BlackBro.WebQueue.Domain.Interface.Repository;
using The3BlackBro.WebQueue.Domain.Interface.Service;
using The3BlackBro.WebQueue.Service.Properties;

namespace The3BlackBro.WebQueue.Service.Services
{
    public class CurrentQueueService : ServiceBase<CurrentQueue>, ICurrentQueueService {
        private ICurrentQueueRepository _currentRepository { get; }
        private ICompanyRepository _companyRepository { get; }
        private ICustumerService _customerService { get; }

        public CurrentQueueService(ICurrentQueueRepository currentRepositoy, ICompanyRepository companyRepository, ICustumerService customerService)
            : base(currentRepositoy) {
            _currentRepository = currentRepositoy;
            _companyRepository = companyRepository;
            _customerService = customerService;
        }

        /// <summary>
        /// Finaliza a fila para aquele dia e encerra todos os cliente que estiverem em aberto.
        /// </summary>
        /// <param name="companyId">Id da empresa.</param>
        public CurrentQueue FinishQueue(int companyId) {
            CurrentQueue queue = _currentRepository.GetCurrentQueue(companyId);

            _customerService.EndAllCustomerServicesInQueue(companyId);
            queue.EndQueue();

            _currentRepository.Update(queue);
            return queue;
        }

        public ICollection<CurrentQueue> GetAllCurrentQueues(int page, int qtd) {
            return _currentRepository.GetAllCurrentQueues(page, qtd);
        }

        /// <summary>
        /// Inicia a fila para a empresa.
        /// </summary>
        /// <param name="queue">Fila a ser inicializada.</param>
        /// <returns></returns>
        public CurrentQueue StartQueue(CurrentQueue queue) {
            if (_currentRepository.IsThereQueueStarted(queue.CompanyId))
                throw new Exception(Resources.mQueueAlreadyStarted);

            var company = _companyRepository.GetById(queue.CompanyId);

            queue.UpdateCompany(company.Id);
            _currentRepository.Add(queue);
            company.UpdateQueue(queue.Id);
            _companyRepository.Update(company);


            return queue;
        }

        /// <summary>
        /// Recupera todos os clientes da fila atual
        /// </summary>
        /// <param name="companyId">Id da empresa</param>
        /// <returns></returns>
        public ICollection<Customer> GetAllCustumersInCurrentQueue(int companyId) {
            return _currentRepository.GetAllCustumersInCurrentQueue(companyId);
        }

        public User GetLastInCurrentQueue(int companyId) {
            var isThereQueueStarted = _currentRepository.IsThereQueueStarted(companyId);
            if (!isThereQueueStarted)
                throw new Exception(Resources.mNoQueueWasFound);

            return _currentRepository.GetLastInCurrentQueue(companyId);
        }

        public bool IsThereQueueStarted(int companyId) {
           return  _currentRepository.IsThereQueueStarted(companyId);           
        }

        public CurrentQueue GetCurrentQueue(int companyId) {
            return _currentRepository.GetCurrentQueue(companyId);
        }

        public void FinishQueue(int companyId, int userId) {
            var queue = _currentRepository.GetById(companyId);

            if (queue is null) {
                throw new Exception(string.Format(Resources.mNoQueueWasFound, companyId));
            }

            if (queue.Company.User.Id != userId)
                throw new Exception(Resources.mCompanyNotAssociatedToThisUser);
           
            queue.EndQueue();
            _currentRepository.Update(queue);

        }
    }
}