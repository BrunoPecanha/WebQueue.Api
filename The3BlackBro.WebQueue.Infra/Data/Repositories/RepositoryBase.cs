using Microsoft.EntityFrameworkCore;
using The3BlackBro.WebQueue.Domain.Interface.Repository;
using The3BlackBro.WebQueue.Infra.Context;

namespace The3BlackBro.WebQueue.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class {

        // Cria uma instância de acesso ao BD.
        protected WebQueueContext Db = new WebQueueContext(new DbContextOptions<WebQueueContext>());

        public void Add(TEntity obj) {

            Db.Set<TEntity>().Add(obj);
            Db.SaveChanges();
        }

        public void Dispose() {
            Db.Dispose();
        }

        public IList<TEntity> GetAll() {
            return Db.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id) {
            return Db.Set<TEntity>().Find(id) ;
        }

        public void Remove(TEntity obj) {
            Db.Set<TEntity>().Remove(obj);
            Db.SaveChanges();
        }

        public void Update(TEntity obj) {
            Db.Entry(obj).State = EntityState.Modified;
            Db.SaveChanges();
        }
    }
}
