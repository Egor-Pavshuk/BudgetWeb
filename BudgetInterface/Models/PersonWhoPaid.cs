using System.ComponentModel.DataAnnotations;

namespace BudgetInterface.Models
{
    public class PersonWhoPaid
    {
        public int PersonWhoPaidId { get; set; }
        public string? Name { get; set; }
        public List<LogEntry>? LogsEntrie { get; set; }
    }
}
