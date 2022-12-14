using BudgetInterface.Models;
using BudgetWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

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
                if (log != null)
                {
                    logsView.Add(new LogEntryView()
                    {
                        Id = log.LogEntryId,
                        Date = log.Date,
                        Shop = log.Shop.Name,
                        Description = log.Description,
                        Bill = log.Bill,
                        PersonWhoPaid = log.PersonWhoPaid.Name,
                        IsPaid = log.IsPaid
                    });
                }
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
                if (log != null)
                {
                    logsView.Add(new LogEntryView()
                    {
                        Id = log.LogEntryId,
                        Date = log.Date,
                        Shop = log.Shop.Name,
                        Description = log.Description,
                        Bill = log.Bill,
                        PersonWhoPaid = log.PersonWhoPaid.Name,
                        IsPaid = log.IsPaid
                    });
                }
            }

            return View(logsView);
        }

        [HttpGet]
        public ActionResult LogForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateLog(LogEntryView logEntryView)
        {
            if (!ModelState.IsValid)
            {
                return View(logEntryView);
            }

            var logEntryBll = new LogEntry()
            {
                Date = logEntryView.Date.ToUniversalTime(),
                Shop = new Shop() { Name = logEntryView.Shop },
                Description = logEntryView.Description,
                PersonWhoPaid = new PersonWhoPaid() { Name = logEntryView.PersonWhoPaid },
                Bill = logEntryView.Bill,
                IsPaid = logEntryView.IsPaid
            };
            _budget.AddNewLog(logEntryBll);

            return Redirect("~/Logs/Logs");
        }

        
        public ActionResult RemoveLog(int id)
        {
            _budget.RemoveById(id);
            return Redirect("~/Logs/Logs");
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
