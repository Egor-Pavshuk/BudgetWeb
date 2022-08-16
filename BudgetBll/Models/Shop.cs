using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetBll.Models
{
    internal class Shop
    {
        public int ShopId { get; set; }        
        public string? Name { get; set; }
        public List<LogEntry>? LogsEntrie { get; set; }
    }
}
