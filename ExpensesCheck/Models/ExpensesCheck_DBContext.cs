using Microsoft.EntityFrameworkCore;

namespace ExpensesCheck.Models
{
    public class ExpensesCheck_DBContext : DbContext
    {
        public DbSet<Expense> Expenses { get; set; }
        public ExpensesCheck_DBContext(DbContextOptions<ExpensesCheck_DBContext> options)
            : base(options) { }

    }
}
