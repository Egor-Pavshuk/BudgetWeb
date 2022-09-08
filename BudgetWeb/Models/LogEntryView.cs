using System.ComponentModel.DataAnnotations;

namespace BudgetWeb.Models
{
    public class LogEntryView
    {
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string? Shop { get; set; }
        public string? Description { get; set; }
        [Required]
        public float Bill { get; set; }
        [Required]
        public string? PersonWhoPaid { get; set; }
        [Required]
        public bool IsPaid { get; set; }
    }
}
