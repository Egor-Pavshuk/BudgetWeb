using BudgetInterface.Models;
public interface IBudget
{
    Task<List<LogEntry>> GetAllLogs();
    void AddNewLog(LogEntry logEntry);
    Task<List<LogEntry>> GetLogsByDate(DateTime startDate, DateTime endDate);
}
