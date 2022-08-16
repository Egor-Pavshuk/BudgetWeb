using System.ComponentModel.DataAnnotations;

namespace BudgetBll.Models
{
    internal class PersonWhoPaid
    {
        public int PersonWhoPaidId { get; set; }
        public string? Name { get; set; }
        public List<LogEntry>? LogsEntrie { get; set; }
    }
}
