using Microsoft.EntityFrameworkCore;
using BudgetBll.DbContextBll;
using BudgetInterface.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetBll
{
    internal class Program
    {
        static void Main() 
        {
            BudgetContext budgetContext = new();
            budgetContext.Database.CanConnect();

            Shop shop = new Shop() { Name = "Silpo", ShopId = 1 };
            PersonWhoPaid person = new PersonWhoPaid() { Name = "Egor", PersonWhoPaidId = 1 };
            LogEntry logEntry = new() { Date = DateTime.Now.ToUniversalTime().AddHours(3), ShopId = 1, PersonWhoPaidId = 1, LogEntryId = 1, Bill = 250, Description = "Null" };

            //Shop shop = new Shop() { Name = "Fora", ShopId = 2 };
            //PersonWhoPaid person = new PersonWhoPaid() { Name = "Mari", PersonWhoPaidId = 2 };
            //LogEntry logEntry = new() { Date = DateTime.Now.ToUniversalTime().AddHours(3), ShopId = 2, PersonWhoPaidId = 2, LogEntryId = 2, Bill = 300, Description = "Null" };

            logEntry.Shop = shop;
            logEntry.PersonWhoPaid = person;

            //budgetContext.Shops.Remove(shop);
            //budgetContext.SaveChanges();
            //budgetContext.Shops.Add(shop);
            ////budgetContext.Shops.Add(new Shop() { Name = "Fora", ShopId = 2 });
            //budgetContext.SaveChanges();

            //budgetContext.PeopleWhoPaid.Remove(person);
            //budgetContext.SaveChanges();
            //budgetContext.PeopleWhoPaid.Add(person);
            ////budgetContext.PeopleWhoPaid.Add(new PersonWhoPaid() { Name = "Mari", PersonWhoPaidId = 2 });
            //budgetContext.SaveChanges();

            //budgetContext.LogsEntrie.Remove(logEntry);
            //budgetContext.SaveChanges();
            //budgetContext.LogsEntrie.Add(logEntry);
            //budgetContext.SaveChanges();


            //var log = budgetContext.LogsEntrie.Include(l => l.PersonWhoPaid).Include(l => l.Shop).ToList()[0];
            //Console.WriteLine($"date = {log.Date}, shop = {log.Shop.Name}, person = {log.PersonWhoPaid.Name}, bill = {log.Bill}");
            //log = budgetContext.LogsEntrie.Include(l => l.PersonWhoPaid).Include(l => l.Shop).ToList()[1];
            //Console.WriteLine($"date = {log.Date}, shop = {log.Shop.Name}, person = {log.PersonWhoPaid.Name}, bill = {log.Bill}");

            Console.ReadKey();
            
        }
    }
        
}
