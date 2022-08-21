using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BudgetWeb.Models;
using BudgetInterface.Models;

namespace BudgetWeb.Controllers
{
    public class LogsController : Controller
    {
        private readonly IBudget? _budget;
        public LogsController(IBudget? budget)
        {
            _budget = budget;
        }

        [HttpGet]
        public ActionResult Logs()
        {
            var dateInterval = new DateInterval();
            var logsBll = _budget.GetLogsByDate(dateInterval.StartDate, dateInterval.EndDate).Result;
            var logsView = new List<LogEntryView>();

            foreach (var log in logsBll)
            {
                logsView.Add(new LogEntryView()
                {
                    Date = log.Date,
                    Shop = log.Shop.Name,
                    Description = log.Description,
                    Bill = log.Bill,
                    PersonWhoPaid = log.PersonWhoPaid.Name,
                    IsPaid = log.IsPaid
                });
            }

            return View(logsView);
        }

        [HttpGet]
        public ActionResult AllLogs()
        {
            var logsBll = _budget.GetAllLogs().Result;
            var logsView = new List<LogEntryView>();

            foreach (var log in logsBll)
            {
                logsView.Add(new LogEntryView()
                {
                    Date = log.Date,
                    Shop = log.Shop.Name,
                    Description = log.Description,
                    Bill = log.Bill,
                    PersonWhoPaid = log.PersonWhoPaid.Name,
                    IsPaid = log.IsPaid
                });
            }

            return View(logsView);
        }

        [HttpPost]
        public ActionResult Logs(LogEntryView logEntryView)
        {
            if (!ModelState.IsValid)
            {
                return View(logEntryView);
            }

            var logEntryBll = new LogEntry()
            {
                Date = logEntryView.Date,
                Shop = new Shop() { Name = logEntryView.Shop },
                Description = logEntryView.Description,
                PersonWhoPaid = new PersonWhoPaid() { Name = logEntryView.PersonWhoPaid },
                IsPaid = logEntryView.IsPaid
            };
            _budget.AddNewLog(logEntryBll);

            return View();
        }

        //// GET: LogsController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: LogsController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: LogsController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: LogsController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: LogsController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: LogsController/Delete/5
        //[HttpDelete]
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: LogsController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
