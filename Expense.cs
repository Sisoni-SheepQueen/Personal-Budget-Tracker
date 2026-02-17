using System;

namespace BudgetTracker
{
    public class Expense
    {
        public decimal Amount { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }

        public Expense(decimal amount, string category, DateTime date)
        {
            Amount = amount;
            Category = category;
            Date = date;
        }
    }
}
