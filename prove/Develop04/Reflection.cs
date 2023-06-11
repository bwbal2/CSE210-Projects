using System;

public class Reflection : Activity
{

    private List<string> _prompts = new List<string>{"Think of a time when you stood up for someone else.","Think of a time when you did something really difficult.","Think of a time when you helped someone in need.","Think of a time when you did something truly selfless."};
    private List<string> _questions = new List<string>{"Why was this experience meaningful to you?","Have you ever done anything like this before?","How did you get started?","How did you feel when it was complete?","What made this time different than other times when you were not as successful?","What is your favorite thing about this experience?","What could you learn from this experience that applies to other situations?","What did you learn about yourself through this experience?","How can you keep this experience in mind in the future?"};


    public void run()
    {
        Welcome();
        Start();
        GivePrompt();
        while (timeUp() == false)
        {
            AskQuestion();
        }
        End();
    }

    public Reflection(string description, string activityName) : base(description, activityName)
    {

    }

    public void GivePrompt()
    {
        Console.WriteLine("\nConsider the following prompt:");
        Console.WriteLine($"\n--- {_prompts[random.Next(_prompts.Count)]} ---");
        Console.WriteLine("\nWhen you have something in mind, press enter to continue.");
        Console.ReadLine();
        Console.WriteLine("\nNow ponder each of the following questions as they related to this experience.");
        Console.Write("\n\nYou may begin in 5");
        int i = 4;
        while (i >= 1)
        {
            Console.Write($"\b \b{i}");
            i--;
            Thread.Sleep(1000);
        }
        Console.Clear();
    }
    public void AskQuestion()
    {
        Console.WriteLine($"\n{_questions[random.Next(_questions.Count)]}  ");
        inspinnerate(8);
    }

}