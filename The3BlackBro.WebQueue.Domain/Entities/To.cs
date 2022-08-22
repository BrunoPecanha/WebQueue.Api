using System;

namespace The3BlackBro.WebQueue.Domain.Entities {
    public class To {
        /// <summary>
        /// Id Interno dos registros.
        /// </summary>  
        public int Id { get; private set; }
        /// <summary>
        /// Data de cadastro do registro.
        /// </summary>
        public DateTime RegisteringDate { get; private set; }
        /// <summary>
        /// Última atualização do registro.
        /// </summary>
        public DateTime LastUpdate { get; private set; }
    }
}
