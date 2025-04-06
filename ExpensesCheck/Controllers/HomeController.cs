using ExpensesCheck.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ExpensesCheck.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ExpensesCheck_DBContext _context;

        // the context will be injected via dependency injection, that's already in ASP .Net under the hood
        public HomeController(ILogger<HomeController> logger, ExpensesCheck_DBContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Expenses()
        {
            // for showing sum of all expenses we can use ViewBag, but I use sum at the view
            //ViewBag.Expenses = _context.Expenses.Sum();
            return View(_context.Expenses.ToList());
        }

        public IActionResult CreateEditExpense(int? id)
        {
            if (id != null)
            {
                // get an object from the db for editing
                var expenseObject = _context.Expenses.FirstOrDefault(expense => expense.Id == id);
                return View(expenseObject);
            }

            return View();
        }

        public IActionResult DeleteExpense(int id)
        {
            var expenseInDb = _context.Expenses.FirstOrDefault(expense => expense.Id == id);
            if (expenseInDb != null)
            {
                _context.Expenses.Remove(expenseInDb);
                _context.SaveChanges();
            }

            return RedirectToAction("Expenses");
        }

        public IActionResult CreateEditExpenseForm(Expense model)
        {
            if (model.Id == 0)
            {
                // Create
                _context.Expenses.Add(model);
            }
            else
            {
                // Edit
                _context.Expenses.Update(model);
            }

            _context.SaveChanges();

            return RedirectToAction("Expenses");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
