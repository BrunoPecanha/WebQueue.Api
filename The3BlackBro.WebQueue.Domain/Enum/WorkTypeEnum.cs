using System.ComponentModel;

namespace The3BlackBro.WebQueue.Domain.Enum {
    /// <summary>
    /// Enum que resolve o tipo da forma de trabalho do salão.
    /// </summary>
    public enum WorkTypeEnum {
        [Description("Queue")]
        Queue = 1,
        [Description("Scheduled")]
        Scheduled
    }
}
