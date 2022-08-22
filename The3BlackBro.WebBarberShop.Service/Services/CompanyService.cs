using The3BlackBro.WebQueue.Domain.Entities;
using The3BlackBro.WebQueue.Domain.Interface.Repository;
using The3BlackBro.WebQueue.Domain.Interface.Service;
using The3BlackBro.WebQueue.Service.Properties;

namespace The3BlackBro.WebQueue.Service.Services
{
    public class CompanyService : ServiceBase<Company>, ICompanyService {
        private readonly ICompanyRepository _companyRepositoy;
        private readonly IUserRepository _userRepository;

        public CompanyService(ICompanyRepository repository, IUserRepository userrepository)
            : base(repository) {
            _companyRepositoy = repository;
            _userRepository = userrepository;
        }

        public void CreateNewCompany(Company company) {
            User user = _userRepository.GetById(company.UserId);

            if (user is null) {
                throw new Exception(Resources.mUserNotFound);
            }

            company.UpdateUser(company.UserId);
            user.UpdateOwner(true);
            _companyRepositoy.Add(company);
            user.UpdateCompany(company, false);
            _userRepository.Update(user);
        }

        public void UpdateCompany(Company company) {
            Company companyXUser = _companyRepositoy.GetById(company.Id);

            if (companyXUser is null)
                throw new Exception(string.Format(Resources.mCompanyNotFound));

            companyXUser.UpdateAdress(company.Address);
            companyXUser.UpdateCnpj(company.Cnpj);
            companyXUser.UpdateConfirmationNotice(company.ConfirmationNotice);
            companyXUser.UpdateFantasyName(company.FantasyName);
            companyXUser.UpdateLogo(company.Logo);
            companyXUser.UpdateOwnerUser(companyXUser.User);
            companyXUser.UpdateRealName(company.RealName);
            companyXUser.UpdateWorkType(company.UseQueue);

            _companyRepositoy.Update(companyXUser);
        }

        public bool CreatingCustumerWithOutPhone(ICollection<ServiceType> serviceList, User user) {
            throw new System.NotImplementedException();
        }

        public User RegisterUserWithOutPhone(User user) {
            if (_userRepository.IsThereAlreadyThisEmail(user.Email))
                throw new Exception(Resources.mEmailAlreadyInUse);

            _userRepository.Add(user);
            return user;
        }

        public bool CompanyHasTransactions(int companyId) {
            return _companyRepositoy.CompanyHasTransactions(companyId);
        }

        public void RemoveCompany(int id) {
            var company = _companyRepositoy.GetById(id);

            if (company is null) {
                throw new Exception(string.Format(Resources.mCompanyNotFound));
            }

            company.User.UpdateCompany(company, true);
            company.User.UpdateOwner(false);

            if (_companyRepositoy.CompanyHasTransactions(company.Id)) {
                company.UpdateActivated(false);
                _companyRepositoy.Update(company);
            } else {
                _companyRepositoy.Remove(company);
            }
        }
    }
}
