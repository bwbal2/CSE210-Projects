using System;

class Program
{
    static void Main(string[] args)
    {
        bool quit = false;
        Console.Clear();
        Console.WriteLine("Welcome to the Galaxy!");
        Galaxy galaxy = new Galaxy();
        galaxy.Initialize();
        while (quit == false)
        {
            quit = galaxy.MainMenu();
        }
    }
}