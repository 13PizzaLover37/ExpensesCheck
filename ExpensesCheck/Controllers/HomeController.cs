using System.Diagnostics;
using ExpensesCheck.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesCheck.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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

        public IActionResult CreateEditExpenseForm(Expense model) => RedirectToAction("Expenses");

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
