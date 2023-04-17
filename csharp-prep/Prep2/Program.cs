using System;

class Program
{
    static void Main(string[] args)
    {
        string letter = "A";

        Console.Write("Enter your grade: ");
        string gradeStr = Console.ReadLine();
        float gradeNum = float.Parse(gradeStr);
        char last = gradeStr[1];
        int lastNum = last - '0';

        if (gradeNum > 90) //These check for each grade interval
        {
            letter = "A";

        }
        else if (gradeNum < 90 && gradeNum > 80)
        {
            letter = "B";
        }
        else if (gradeNum < 80 && gradeNum >= 70)
        {
            letter = "C";
        }
        else if (gradeNum < 70 && gradeNum >= 60)
        {
            letter = "D";
        }
        else if (gradeNum < 60)
        {
            letter = "F";
        }



        if (lastNum < 3 && letter != "F") //This block checks for a + or -, excepting A and F in certain circumstances.
        {
            letter += "-";
        }
        else if (lastNum >= 7 && letter != "A" && letter != "F")
        {
            letter += "+";
        }



        Console.WriteLine($"Your grade is: {letter}"); //Prints final letter grade.



        
        if (gradeNum >= 70) //This block prints whether you passed
        {
            Console.WriteLine("You passed!");
        }
        else
        {
            Console.WriteLine("Better luck next time!");
        }
    }
}