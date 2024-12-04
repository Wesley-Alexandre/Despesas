using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace MeuProjetoASPNetCore.Pages
{
    public class IndexModel : PageModel
    {
        public class Expense
        {
            public int Id { get; set; }
            public decimal Value { get; set; }
            public string Description { get; set; }
        }

        public List<Expense> Expenses => AddExpenseModel.Expenses;

        public decimal TotalExpenses => Expenses.Sum(e => e.Value);

        public void OnGet()
        {
        }

        public IActionResult OnPost(int id)
        {
            var expenseToRemove = AddExpenseModel.Expenses.FirstOrDefault(e => e.Id == id);
            if (expenseToRemove != null)
            {
                AddExpenseModel.Expenses.Remove(expenseToRemove);
            }

            return RedirectToPage("/Index");
        }
    }
}
