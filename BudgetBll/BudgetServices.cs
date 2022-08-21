using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetBll.DbContextBll;
using BudgetInterface.Models;
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
        public async void AddNewLog(LogEntry logEntry)
        {
            await _context.LogsEntrie.AddAsync(logEntry);
            await _context.SaveChangesAsync();
        }

        public async Task <List<LogEntry>> GetAllLogs() => await _context.LogsEntrie.Include(_ => _.Shop).Include(_ => _.PersonWhoPaid).ToListAsync();
        
        public async Task<List<LogEntry>> GetLogsByDate(DateTime startDate, DateTime endDate)
        {
           return await _context.LogsEntrie.Where(log => (log.Date >= startDate) &&  (log.Date <= endDate)).Include(_ => _.Shop).Include(_ => _.PersonWhoPaid).ToListAsync();
        }
    }
}
