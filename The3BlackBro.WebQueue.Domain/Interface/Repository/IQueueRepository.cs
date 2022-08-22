using The3BlackBro.WebQueue.Domain.Entities;
using System.Collections.Generic;

namespace The3BlackBro.WebQueue.Domain.Interface.Repository {
    public interface ICurrentQueueRepository : IRepositoryBase<CurrentQueue> {


        /// <summary>
        /// Recupera a proxima posição na fila para criação de um novo usuário.
        /// </summary>
        /// <param name="companyId">Ida da empresa</param>
        /// <param name="queueId">Id da fila.</param>
        /// <returns></returns>
        int GetNextPositionInQueue(int companyId, int queueId);       

        /// <summary>
        /// Valida se existe alguma fila aberta.
        /// </summary>
        bool IsThereQueueStarted(int? companyId);

        /// <summary>
        /// Recupera a fila pelo id empresa e tras também o usuário responsável.
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        CurrentQueue GetCurrentQueue(int companyId);     
        
        /// <summary>
        /// Valida se a fila está vazia.
        /// </summary>
        /// <returns></returns>
        bool IsQueueEmpty(int companyId, int queueId);

        /// <summary>
        /// Recupera todos os clientes na fila atual.
        /// </summary>
        /// <param name="companyId">Ida da empresa.</param>
        /// <returns></returns>
        ICollection<Customer> GetAllCostumersInCurrentQueue(int companyId);

        /// <summary>
        /// Recupera todas as filas ( Função de administrador do sistema )
        /// </summary>
        /// <param name="page"></param>
        /// <param name="qtd"></param>
        /// <returns></returns>
        ICollection<CurrentQueue> GetAllCurrentQueues(int page, int qtd);            

        /// <summary>
        /// Recuperar todos os clientes na fila atual.
        /// </summary>
        /// <param name="companyId">Id da empresa.</param>
        /// <returns></returns>
        ICollection<Customer> GetAllCustumersInCurrentQueue(int companyId);
        User GetLastInCurrentQueue(int companyId);
    }
}
