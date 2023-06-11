using System;

public class Breathing : Activity
{

    public void run()
    {
        Welcome();
        Start();
        while (timeUp() == false)
        {
            Breathe();
        }
        End();
    }
    public void Breathe()
    {
        Console.Write("\n\nBreathe in....");
        int i = 4;
        while (i >= 1)
        {
            Console.Write($"\b \b{i}");
            i--;
            Thread.Sleep(1000);
        }
        Console.Write($"\b \b");
        Console.Write("\n\nNow breathe out....");
        i = 6;
        while (i >= 1)
        {
            Console.Write($"\b \b{i}");
            i--;
            Thread.Sleep(1000);
        }
        Console.Write($"\b \b");
        Console.WriteLine();

    }

    public Breathing(string description, string activityName) : base(description, activityName)
    {

    }

}