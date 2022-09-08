namespace BudgetInterface.Models
{
    public class LogEntry
    {
        public int LogEntryId { get; set; }
        public DateTime Date { get; set; }
        public int ShopId { get; set; }
        public Shop? Shop { get; set; }
        public string? Description { get; set; }
        public float Bill { get; set; }
        public int PersonWhoPaidId { get; set; }
        public PersonWhoPaid? PersonWhoPaid { get; set; }
        public bool IsPaid { get; set; }
              
    }
}

