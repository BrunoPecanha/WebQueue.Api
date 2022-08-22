namespace The3BlackBro.WebQueue.Api.Options
{
    public class AppSettingsOptions {
        public string Secret { get; set; }
        public int ExpirationHours { get; set; }
        public string Issuer { get; set; }
        public string ValidIn { get; set; }
    }
}
