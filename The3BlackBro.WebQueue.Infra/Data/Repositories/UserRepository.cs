using Microsoft.EntityFrameworkCore;
using The3BlackBro.WebQueue.Domain.Entities;
using The3BlackBro.WebQueue.Domain.Interface.Repository;
using The3BlackBro.WebQueue.Infra.Context;
using System.Collections.Generic;
using System.Linq;

namespace The3BlackBro.WebQueue.Infra.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository {
        private IWebQueueContext _dbContext { get; }

        public UserRepository(IWebQueueContext context) {
            _dbContext = context;
           
        }
        public void DeleteUser(int userId) {
            User user = _dbContext.User
                      .Include(x => x.Company)
                      .FirstOrDefault(x => x.Id == userId);
            _dbContext.User.Remove(user);        
        }

        public bool isThereTransactionsForThisUser(int userId) {
            return _dbContext.Custumer
                             .Any(x => x.UserId == userId);
        }

        public void SoftDeleteUser(User user) {
            _dbContext.User.Update(user);
        }

        public bool IsThereAlreadyThisEmail(string email) {
            return _dbContext.User
                             .Any(x => x.Email.Equals(email));
        }

        public User GetUserById(int id) {
            return _dbContext.User
                             .FirstOrDefault(x => x.Id == id);
        }

        public IReadOnlyCollection<User> GetAllUsers(int companyId) {
            return _dbContext.User
                             .Where(x => x.CompanyId == companyId)
                             .ToArray();
        }
    }
}
