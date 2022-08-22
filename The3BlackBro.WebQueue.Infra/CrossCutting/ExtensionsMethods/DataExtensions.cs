namespace The3BlackBro.WebQueue.Infra.CrossCutting.Utils.ExtensionsMethods
{
    public static class DataExtensions
    {
        private const string _date = "dd/MM/yyyy";
        private const string _dateAndTime = "dd/MM/yyyy HH:mm:ss";

        public static string ToBrazilianDate(this DateTime value) {
            return value.ToString(_date);
        }

        public static string ToBrazilianDateAndTime(this DateTime value) {
            return value.ToString(_dateAndTime);
        }
    }
}
