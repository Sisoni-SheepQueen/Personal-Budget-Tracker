using System;
using System.Collections.Generic;
using System.Linq;

namespace BudgetTracker
{
    public class ExpenseManager
    {
        public List<Expense> Expenses { get; private set; } = new List<Expense>();

        public void AddExpense(Expense expense)
        {
            Expenses.Add(expense);
        }

        public void RemoveExpense(int index)
        {
            if (index >= 0 && index < Expenses.Count)
                Expenses.RemoveAt(index);
        }

        public decimal GetTotal()
        {
            return Expenses.Sum(e => e.Amount);
        }

        public decimal GetAverage()
        {
            return Expenses.Count == 0 ? 0 : Expenses.Average(e => e.Amount);
        }

        public Expense GetMaxExpense()
        {
            return Expenses.OrderByDescending(e => e.Amount).FirstOrDefault();
        }

        public Dictionary<string, decimal> GetByCategory()
        {
            return Expenses
                .GroupBy(e => e.Category)
                .ToDictionary(g => g.Key, g => g.Sum(e => e.Amount));
        }
    }
}
