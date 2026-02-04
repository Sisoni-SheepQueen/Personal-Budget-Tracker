using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
    
namespace BudgetTracker
{
    public static class FileManager
    {
        private const string FileName = "expenses.txt";

        public static List<Expense> Load()
        {
            var list = new List<Expense>();

            if (!File.Exists(FileName))
                return list;

            foreach (var line in File.ReadAllLines(FileName))
            {
                var parts = line.Split(';');
                if (parts.Length == 3)
                {
                    decimal amount = decimal.Parse(parts[0], CultureInfo.InvariantCulture);
                    string category = parts[1];
                    DateTime date = DateTime.Parse(parts[2]);

                    list.Add(new Expense(amount, category, date));
                }
            }
            return list;
        }

        public static void Save(List<Expense> expenses)
        {
            var lines = new List<string>();
            foreach (var e in expenses)
            {
                lines.Add($"{e.Amount};{e.Category};{e.Date}");
            }
            File.WriteAllLines(FileName, lines);
        }
    }
}
