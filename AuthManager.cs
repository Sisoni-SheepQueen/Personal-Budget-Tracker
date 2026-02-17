using System;

public static class AuthManager
{
    public static string CurrentUser { get; private set; }

    public static void Login()
    {
        Console.Clear();
        Console.WriteLine("==== LOGIN ====");
        Console.Write("Enter username: ");

        string username = Console.ReadLine()?.Trim();

        while (string.IsNullOrWhiteSpace(username))
        {
            Console.Write("Username cannot be empty. Enter again: ");
            username = Console.ReadLine()?.Trim();
        }

        CurrentUser = username;
        Console.WriteLine($"Welcome, {CurrentUser}!");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}