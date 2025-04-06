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

        public IActionResult Expenses() => View();

        public IActionResult CreateEditExpense() => View();

        public IActionResult CreateEditExpenseForm(Expense model)
        {
            _context.Expenses.Add(model);
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
