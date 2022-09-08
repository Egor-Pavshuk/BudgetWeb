namespace BudgetWeb.Models
{
    internal class DateInterval
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateInterval()
        {
            StartDate = DateTime.Now.Subtract(TimeSpan.FromDays(7));
            EndDate = DateTime.Now;
        }
        public DateInterval(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
