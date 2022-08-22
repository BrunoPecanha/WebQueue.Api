using The3BlackBro.WebQueue.Domain.Entities;

namespace The3BlackBro.WebQueue.Domain.Interface.Service {
    public interface IUserService : IServiceBase<User> {
        void CreateNewUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int userId);       
    }
}
