using System;
using BudgetTracker;

class Program
{
    static void Main()
    {

        AuthManager.Login();
        ExpenseManager manager = new ExpenseManager();
        manager.Expenses.AddRange(FileManager.Load());

        while (true)
        {
            UI.ShowMenu();
            Console.Write("Избор: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    decimal amount = UI.ReadDecimal("Сума: ");
                    Console.Write("Категория: ");
                    string category = Console.ReadLine();
                    DateTime date = UI.ReadDate("Дата: ");
                    manager.AddExpense(new Expense(amount, category, date));
                    break;

                case "2":
                    for (int i = 0; i < manager.Expenses.Count; i++)
                        UI.PrintExpense(manager.Expenses[i], i);
                    break;

                case "3":
                    Console.Write("Номер за изтриване: ");
                    int index = int.Parse(Console.ReadLine());
                    manager.RemoveExpense(index);
                    break;

                case "4":
                    Console.WriteLine($"Общо: {manager.GetTotal()} лв");
                    Console.WriteLine($"Средно: {manager.GetAverage()} лв");
                    var max = manager.GetMaxExpense();
                    if (max != null)
                        Console.WriteLine($"Най-голям: {max.Amount} лв");
                    break;

                case "5":
                    FileManager.Save(manager.Expenses);
                    return;
            }
        }
    }
}
