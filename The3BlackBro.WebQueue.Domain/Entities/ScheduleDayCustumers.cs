using System;

namespace The3BlackBro.WebQueue.Domain.Entities {
    /// <summary>
    /// Classe que relaciona os cliente que estão na agenda do dia
    /// </summary>
    public class ScheduleDayXCustumers : To {       
        /// <summary>
        /// Id do Cliente.
        /// </summary>
        public virtual int CustumerId { get; set; }
        /// <summary>
        /// Propriedade que indica que é um relacionamento NxM
        /// </summary>
     //   public virtual Custumer Custumer { get; set; }
        /// <summary>
        /// Propriedade que indica que é um relacionamento NxM
        /// </summary>
      //  public virtual int ScheduleDayId { get; set; }
        ///// <summary>
        ///// Propriedade que indica que é um relacionamento NxM
        ///// </summary>
        public ScheduleDay ScheduleDay { get; set; }
    }
}
