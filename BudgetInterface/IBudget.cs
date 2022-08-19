using BudgetWeb.Models;
public interface IBudget
{
    Task<List<LogEntryView>> GetAllLogs();
    void AddNewLog(LogEntryView logEntry);
}
