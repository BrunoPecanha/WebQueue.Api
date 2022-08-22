using The3BlackBro.WebQueue.Domain.Entities;
using The3BlackBro.WebQueue.Domain.Interface.Repository;
using The3BlackBro.WebQueue.Domain.Interface.Service;
using The3BlackBro.WebQueue.Service.Properties;

namespace The3BlackBro.WebQueue.Service.Services
{
    public class UserService : ServiceBase<User>, IUserService {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
            : base(repository) {
            _repository = repository;
        }

        public void CreateNewUser(User user) {
            if (_repository.IsThereAlreadyThisEmail(user.Email))
                throw new Exception(Resources.mEmailAlreadyInUse);

            _repository.Add(user);
        }

        public void DeleteUser(int id) {

            User user = _repository.GetById(id);

            if (user is null) {
                throw new Exception(Resources.mUserNotFound);

            } else if (user.Owner) {
                throw new Exception(Resources.mCantDeleteOwnerUser);
            }

            bool isThereTransactionsForThisUser = _repository.isThereTransactionsForThisUser(user.Id);

            if (isThereTransactionsForThisUser) {
                user.UpdateActivated(false);
                _repository.Update(user);
            } else {
                _repository.Remove(user);
            }
        }

        public void UpdateUser(User user) {
            //return new DefaultOutPutContainer()
            //{
            //    Valid = true,
            //    Message = Resources.mSuceedDeleted
            //};
        }
    }
}
