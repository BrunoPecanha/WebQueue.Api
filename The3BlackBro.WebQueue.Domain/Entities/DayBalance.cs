namespace The3BlackBro.WebQueue.Domain.Entities {
    public class DayBalance : To
    {
        private DayBalance()
        {
        }

        public DayBalance(int companyId, int queueId, decimal value)
        {
            Amount = value;
            CompanyId = companyId;
            QueueId = queueId;
        }

        public decimal Amount { get; private set; }
        public int CompanyId { get; private set; }
        public virtual Company Company { get; set; }

        public int? QueueId { get; private set; }
        public virtual CurrentQueue Queue { get; set; }

        public int? ScheduleDayId { get; private set; }
        public virtual ScheduleDay ScheduleDay { get; set; }

        public void WithDraw(decimal value)
        {
            this.Amount -= value;
        }

        public void Deposit(decimal value)
        {
            this.Amount += value;
        }
    }
}
