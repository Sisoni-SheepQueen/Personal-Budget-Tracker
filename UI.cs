using System;

namespace BudgetTracker
{
    public static class UI
    {
        public static void ShowMenu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n1. Добави разход");
            Console.WriteLine("2. Покажи всички разходи");
            Console.WriteLine("3. Изтрий разход");
            Console.WriteLine("4. Статистика");
            Console.WriteLine("5. Изход");
            Console.ResetColor();
        }

        public static void PrintExpense(Expense e, int index)
        {
            if (e.Amount > 100)
                Console.ForegroundColor = ConsoleColor.Red;
            else if (e.Amount < 20)
                Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine($"{index}. {e.Amount} лв | {e.Category} | {e.Date:d}");
            Console.ResetColor();
        }

        public static decimal ReadDecimal(string message)
        {
            decimal value;
            do
            {
                Console.Write(message);
            } while (!decimal.TryParse(Console.ReadLine(), out value));

            return value;
        }

        public static DateTime ReadDate(string message)
        {
            DateTime date;
            do
            {
                Console.Write(message);
            } while (!DateTime.TryParse(Console.ReadLine(), out date));

            return date;
        }
    }
}
