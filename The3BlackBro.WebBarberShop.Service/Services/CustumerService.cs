using System.Globalization;
using The3BlackBro.WebQueue.Domain.Entities;
using The3BlackBro.WebQueue.Domain.Interface.Repository;
using The3BlackBro.WebQueue.Domain.Interface.Service;
using The3BlackBro.WebQueue.Infra.Context;
using The3BlackBro.WebQueue.Service.Properties;

namespace The3BlackBro.WebQueue.Service.Services
{
    public class CustumerService : ServiceBase<Customer>, ICustumerService {
        private readonly ICustumerRepository _customerRepositoy;
        private readonly ICustumerSelectedServicesRepository _customerSelectedServicesRepository;
        private readonly ICurrentQueueRepository _currentQueueRepository;
        private readonly IUserRepository _userRepository;
        private readonly IServiceTypeRepository _serviceTypeRepository;
        private readonly IWebQueueContext _dbContext;
        private readonly ICompanyRepository _companyRepository;
        private readonly IDayBalanceRepository _dayBalanceRepository;

        public CustumerService(IWebQueueContext context, IUserRepository userRepository, ICustumerRepository repository, ICustumerSelectedServicesRepository customer,
            ICurrentQueueRepository currentQueueRepository, IServiceTypeRepository serviceType, ICompanyRepository companyRepository, IDayBalanceRepository dayBalanceRepository)
            : base(repository) {
            _customerRepositoy = repository;
            _customerSelectedServicesRepository = customer;
            _currentQueueRepository = currentQueueRepository;
            _userRepository = userRepository;
            _serviceTypeRepository = serviceType;
            _companyRepository = companyRepository;
            _dayBalanceRepository = dayBalanceRepository;
            _dbContext = context;
        }

        /// <summary>
        /// Inseri um novo cliente e o retorna.
        /// </summary>
        /// <param name="customer">Objeto cliente recebido</param>
        /// <returns></returns>
        public Customer AddWithReturn(Customer customer) {
            _customerRepositoy.Add(customer);
            return customer;
        }

        /// <summary>
        /// Recupera os seviços selecionados pelo usuário que gerou o cliente.
        /// </summary>
        /// <param name="customerId">Id do cliente.</param>
        /// <returns></returns>
        public List<CustumerXServices> GetAllSelectedCustomerServices(int customerId) {
            return _customerSelectedServicesRepository.GetAllSelectedCustomerServices(customerId);
        }

        /// <summary>
        /// Finaliza todos os cliente da fila aberta para empresa.
        /// </summary>
        /// <param name="companyId">Id da empresa</param>
        public void EndAllCustomerServicesInQueue(int companyId) {
            ICollection<Customer> allcustomersInQueue = _currentQueueRepository.GetAllCustumersInCurrentQueue(companyId);

            foreach (var customer in allcustomersInQueue) {
                customer.UpdateServiceStatus();
                _customerRepositoy.Update(customer);
            }
        }

        /// <summary>
        /// Verifica se o cliente já está na fila.
        /// </summary>
        /// <param name="userId">Id do usuário.</param>
        /// <returns></returns>
        public bool IsCustomerAlreadyInQueue(int userId) {
            return _customerRepositoy.IsCustomerAlreadyInQueue(userId);
        }

        public string ElapsedTime(int customerId) {
            Customer customer = _customerRepositoy.GetById(customerId);


            if (customer is null) {
                throw new Exception(Resources.mCustomerNotFound);
            }

            TimeSpan diff = DateTime.Now - customer.RegisteringDate;
            return string.Format(
                            CultureInfo.CurrentCulture,
                            "{0}h:{1}m",
                            diff.Hours,
                            diff.Minutes
                            );

        }

        /// <summary>
        /// Chama o próximo da fila
        /// </summary>
        public bool CallNextCustomerInQueue(int queueId) {
            var newCurrentCustomer = _dbContext.Custumer
                             .OrderBy(x => x.QueuePosition)
                             .FirstOrDefault(x => x.QueueId == queueId && !x.IsServiceDone);

            if (newCurrentCustomer is null)
                return false;
            newCurrentCustomer.CurrentCustomerInService = true;
            _customerRepositoy.Update(newCurrentCustomer);
            return true;
        }

        /// <summary>
        /// Recupera os clientes que batem com a string passada.
        /// </summary>
        /// <param name="name">Nome do cliente.</param>
        /// <returns>Retorna a lista com os cliente que batem com a descrição.</returns>
        public IList<Customer> GetCustomerByName(string name) {
            return _customerRepositoy.GetCustomerByName(name);
        }


        /// <summary>
        /// Exclui o cliente da fila.
        /// </summary>
        /// <param name="customerId">Identificação do cliente.</param>
        /// <returns></returns>
        public void DeleteFromQueue(int customerId) {
            List<CustumerXServices> custumerXServicesBd = _customerSelectedServicesRepository.GetAllSelectedCustomerServices(customerId);
            Customer custumer = custumerXServicesBd.Select(x => x.Custumer).First();

            if (custumer.IsServiceDone) {
                throw new Exception(Resources.mUsersServicesAlreadyDone);
            }

            custumerXServicesBd.ForEach(x => _customerSelectedServicesRepository.Remove(x));
            _dbContext.Custumer.Remove(custumer);
        }

        /// <summary>
        /// Salva os serviços selecionados pelo usuário.
        /// </summary>
        /// <param name="companyId">Id da empresa</param>
        /// <param name="custumer">Cliente que será inserido na fila</param>
        /// <param name="serviceList">Lista de serviços do cliente.</param>
        public void SaveCustumerSelectedServices(int companyId, Customer custumer, int[] serviceList) {
            bool isThereQueStarted = _currentQueueRepository.IsThereQueueStarted(companyId);
            bool isCustomerAlreadyInQueue = this.IsCustomerAlreadyInQueue(custumer.Id);

            if (!isThereQueStarted)
                throw new Exception(Resources.mNoQueueWasFound);
            else if (isCustomerAlreadyInQueue) {
                throw new Exception(Resources.mCustomerAlreadyInQueue);
            }

            User user = _userRepository.GetById(custumer.UserId);
            CurrentQueue currentQueue = _currentQueueRepository.GetCurrentQueue(companyId);

            if (user is null) {
                throw new Exception(string.Format(Resources.mNoUserWasFoundWithId, custumer.UserId));
            } else if (currentQueue is null) {
                throw new Exception(string.Format(Resources.mNoQueueWasFound));
            }

            int position = _currentQueueRepository.GetNextPositionInQueue(companyId, currentQueue.Id);
            var customer = new Customer(user.Id, currentQueue.Id, custumer.Comment, position);

            _customerRepositoy.Add(customer);

            foreach (int serviceId in serviceList) {
                ServiceType service = _serviceTypeRepository.GetServiceById(companyId, serviceId);

                if (service != null) {
                    _customerSelectedServicesRepository.Add(new CustumerXServices(service, customer));
                }
            }
        }

        /// <summary>
        /// Finaliza o serviço de um cliente
        /// </summary>
        /// <param name="customerId">Id da empresa.</param>
        /// <returns></returns>
        public void EndCustomerService(int customerId, int companyId) {
            Customer customer = _customerRepositoy.GetById(customerId);
            Company company = _companyRepository.GetById(companyId);

            if (customer is null)
                throw new Exception(Resources.mCustomerNotFound);
            else if (company is null)
                throw new Exception(Resources.mCompanyNotFound);
            else if (customer.IsServiceDone)
                throw new Exception(Resources.mUsersServicesAlreadyDone);
            else if (!customer.CurrentCustomerInService)
                throw new Exception(Resources.mCustomerIsNotInService);

            User usuario = _userRepository.GetById(customer.UserId);

            customer.UpdateServiceStatus();
            usuario.UpdateLastVisitDate();
            _customerRepositoy.Update(customer);
            _userRepository.Update(usuario);

            decimal totalServices = _serviceTypeRepository.GetServicesByCustomer(customerId).Sum(x => x.Price);
            DayBalance dayBalance = _dayBalanceRepository.GetDayBalanceById(companyId, customer.QueueId ?? 0);

            dayBalance.Deposit(totalServices);
            _dayBalanceRepository.Update(dayBalance);
        }

        public void UpdateCustomer(int companyId, int customerId, int[] serviceList, string comment) {
            Customer customer = _customerRepositoy.GetById(customerId);

            customer.CustumerServices.Clear();
            foreach (int serviceId in serviceList) {
                ServiceType service = _serviceTypeRepository.GetServiceById(companyId, serviceId);

                if (service != null) {
                    customer.AddServiceToCustumer(new CustumerXServices(service, customer));
                }
            }
        }
    }
}
