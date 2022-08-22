using System.Collections.Generic;

namespace The3BlackBro.WebQueue.Domain.Interface.Repository {
    public interface IRepositoryBase<TEntity> where TEntity : class {
        /// <summary>
        /// Grava o objeto T.
        /// </summary>
        /// <param name="obj">Objeto que será persistido.</param>
        void Add(TEntity obj);
        /// <summary>
        /// Retorna um registro de acordo com o Id passado.
        /// </summary>
        /// <param name="id">Id do registro que será procurado no BD.</param>
        TEntity GetById(int id);
        /// <summary>
        /// Retorna todos os elementos do tipo T.
        /// </summary>
        /// <returns></returns>
        IList<TEntity> GetAll();
        /// <summary>
        /// Atualiza um registro TEntity já existente no BD.
        /// </summary>
        /// <param name="obj">Objeto que sera atualizado.</param>
        void Update(TEntity obj);
        /// <summary>
        /// Remove um registro do BD
        /// </summary>
        /// <param name="obj">Objeto que será removido.</param>
        void Remove(TEntity obj);
        /// <summary>
        /// Liberar recursos não gerenciados.
        /// </summary>
        void Dispose();
    }
}
