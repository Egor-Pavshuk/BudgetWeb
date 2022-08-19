using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetWeb.Models;
using BudgetBll.DbContextBll;
using BudgetBll.Models;
using Microsoft.EntityFrameworkCore;

namespace BudgetBll
{
    public class BudgetServices : IBudget
    {
        private readonly BudgetContext _context;
        public BudgetServices()
        {
            _context = new BudgetContext();
        }
        public async void AddNewLog(LogEntryView logEntry)
        {
            var logEntryBll = new LogEntry()
            {
                Date = logEntry.Date,
                Shop = new Shop() { Name = logEntry.Shop },
                Description = logEntry.Description,
                PersonWhoPaid = new PersonWhoPaid() { Name = logEntry.PersonWhoPaid },
                IsPaid = logEntry.IsPaid
            };

            await _context.LogsEntrie.AddAsync(logEntryBll);
            await _context.SaveChangesAsync();
        }

        public async Task <List<LogEntryView>> GetAllLogs()
        {
            var logsEntryBll = await _context.LogsEntrie.Include(_ => _.Shop).Include(_ => _.PersonWhoPaid).ToListAsync();
            var logsEntryView = new List<LogEntryView>();
            foreach (var log in logsEntryBll)
            {
                logsEntryView.Add(new LogEntryView()
                {
                    Date = log.Date,
                    Shop = log.Shop.Name,
                    Description = log.Description,
                    Bill = log.Bill,
                    PersonWhoPaid = log.PersonWhoPaid.Name,
                    IsPaid = log.IsPaid
                });
                
            }
            return logsEntryView;
        }
    }
}
