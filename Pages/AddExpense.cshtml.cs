using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

namespace MeuProjetoASPNetCore.Pages
{
    public class AddExpenseModel : PageModel
    {
        [BindProperty]
        public decimal Value { get; set; }

        [BindProperty]
        public string Description { get; set; }

        // Lista estática para armazenar despesas (dados temporários)
        public static List<IndexModel.Expense> Expenses = new();
        private static int _nextId = 1;

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            // Adicionar a despesa na lista
            var newExpense = new IndexModel.Expense
            {
                Id = _nextId++,
                Value = Value,
                Description = Description
            };

            Expenses.Add(newExpense);

            return RedirectToPage("/Index");
        }
    }
}
