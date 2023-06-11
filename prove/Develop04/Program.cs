using System;

class Program
{
    static bool Menu()
    {
        bool quit = false;
        Console.Clear();
        Console.WriteLine("Menu Options:\n1. Start breathing activity\n2. Start reflection activity\n3. Start listing activity\n4. Quit");
        Console.Write("\nSelect a choice from the menu: ");
        string input = Console.ReadLine();
        List<string> options = new List<string>{"1","2","3","4","quit"};
        while (!options.Contains(input.ToLower()))
        {
            Console.Clear();
            Console.WriteLine("Invalid input, try again.\n\n1. Start breathing activity\n2. Start reflection activity\n3. Start listing activity\n4. Quit");
            Console.Write("\nSelect a choice from the menu: ");
            input = Console.ReadLine();
        }
        Console.Clear();
        switch(input.ToLower())
        {
            case "1":
                Breathing breathing = new Breathing("This activity will help you realx by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.","Breathing");
                breathing.run();
                break;
            case "2":
                Reflection reflection = new Reflection("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you to recognize the power you have and how you can use it in other aspects of your life.","Reflecting");
                reflection.run();
                break;
            case "3":
                Listing listing = new Listing("This activity will help you focus on good the things in your life by having you list as many things as you can in a certain area.","Listing");
                listing.run();
                break;
            case "4": case "quit":
                quit = true;
                break;
        }



        return quit;
    }
    static void Main(string[] args)
    {
        bool quit = false;
        while (quit == false)
        {
            quit = Menu();
        }
    }
}