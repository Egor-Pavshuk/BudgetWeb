namespace BudgetWeb.Models
{
    public class LogEntryView
    {
        public DateTime Date { get; set; }
        public string? Shop { get; set; }
        public string? Description { get; set; }
        public float Bill { get; set; }
        public string? PersonWhoPaid { get; set; }
        public bool IsPaid { get; set; }
    }
}
