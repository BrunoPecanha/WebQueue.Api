using The3BlackBro.WebQueue.Domain.Entities;
using System.Collections.Generic;

namespace The3BlackBro.WebQueue.Domain.Interface.Repository
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        bool isThereTransactionsForThisUser(int userId);
        bool IsThereAlreadyThisEmail(string email);
        User GetUserById(int id);
        IReadOnlyCollection<User> GetAllUsers(int companyId);
    }
}
