using System;

class Program
{


    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");

    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());
        return number;
    }

    static int SquareNumber(int number)
    {
        int square = number * number;
        return square;
    }

    static void DisplayResult(int square, string name)
    {
        Console.Write($"{name}, the square of your number is {square}");

    }




    static void Main(string[] args)
    {
        // DisplayWelcome - Displays the message, "Welcome to the Program!"
        // PromptUserName - Asks for and returns the user's name (as a string)
        // PromptUserNumber - Asks for and returns the user's favorite number (as an integer)
        // SquareNumber - Accepts an integer as a parameter and returns that number squared (as an integer)
        // DisplayResult - Accepts the user's name and the squared number and displays them.
        DisplayWelcome();
        string name = PromptUserName();
        int number = PromptUserNumber();
        int square = SquareNumber(number);
        DisplayResult(square,name);


        // Welcome to the program!
        // Please enter your name: Brother Burton
        // Please enter your favorite number: 42
        // Brother Burton, the square of your number is 1764


    }
}