using System;

public class Listing : Activity
{

    private List<string> _prompts = new List<string>{"Who are people that you appreciate?","What are personal strengths of yours?","Who are people that you have helped this week?","When have you felt the Holy Ghost this month?","Who are some of your personal heroes?"};

    private string _answer = "";
    public void run()
    {

        Welcome();
        Start();
        Console.WriteLine("\nList as many responses as you can to the following prompt:");
        string daPrompt = givePrompt();
        Console.WriteLine($"--- {daPrompt} ---");
        _answer += $"{daPrompt}: ";
        Console.Write("\n\nYou may begin in: 5");
        int i = 4;
        while (i >= 1)
        {
            Console.Write($"\b \b{i}");
            i--;
            Thread.Sleep(1000);
        }
        Console.Write($"\b \b\n");
        int j = 0;
        string answerNew;
        while (timeUp() == false)
        {
            Console.Write("- ");
            answerNew = Console.ReadLine();
            _answer += $"{answerNew}, ";
            j++;
        }
        Console.WriteLine($"You listed {j} items!!");
        saveJournal();
        End();
    }


    public Listing(string description, string activityName) : base(description, activityName)
    {

    }
    public string givePrompt()
    {
        
        return _prompts[random.Next(_prompts.Count)];
    }
    public void saveJournal()
    {
      string journalFile = "listing.csv";

      using (StreamWriter outputFile = new StreamWriter(journalFile))
      {
         { 
         // You can add text to the file with the WriteLine method
         outputFile.WriteLine(_answer);

         }

      }
    }
    
}