using System.ComponentModel;

namespace The3BlackBro.WebQueue.Domain.Enum {
    public enum MobileEnum {
        [Description("iPhone")]
        iPhone = 1,
        [Description("Android")]
        Android,
        [Description("Sem Celular")]
        NoCel
    }
}
