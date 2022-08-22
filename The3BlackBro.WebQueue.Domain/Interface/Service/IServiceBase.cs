using System.Collections.Generic;

namespace The3BlackBro.WebQueue.Domain.Interface.Service {
    public interface IServiceBase<TEntity> where TEntity : class {
        void Add(TEntity obj);
        TEntity GetById(int id);
        IList<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(TEntity obj);
        void Dispose();
    }
}
