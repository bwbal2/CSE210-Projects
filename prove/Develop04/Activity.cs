using System;

public class Activity
{

    private int _duration;
    private string _description;
    private string _activityName;
    private DateTime _startTime;
    private DateTime _endTime;
    private int _i = 0;

    public static Random random = new Random();
    private List<string> _spinner = new List<string>{"|","/","-","\\"};

    public Activity(string description, string activityName)
    {
        _description = description;
        _activityName = activityName;
    }

    public void Start()
    {
        Console.WriteLine("Get ready...");
        inspinnerate(4);
        _startTime = DateTime.Now;
        _endTime = _startTime.AddSeconds(_duration);
    }
    public void inspinnerate(int count)
    {
        DateTime pauseTime = DateTime.Now.AddSeconds(count);
        while (DateTime.Now < pauseTime)
        {
            spin();
        }
        Console.Write($"\b \b");
    }
    public bool timeUp()
    {
        if (DateTime.Now < _endTime)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public void Welcome()
    {
        Console.WriteLine($"Welcome to the {_activityName} Activity.");
        Console.WriteLine($"\n{_description}");
        Console.Write("\n\nHow long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());
    }
    public void End()
    {
        Console.WriteLine("Well done!!!");
        Console.WriteLine($"\nYou have completed another {_duration} seconds of the {_activityName} Activity.\n");
        inspinnerate(5);
    }
    public void spin()
    {
        if (_i < _spinner.Count)
        {
            Console.Write($"\b \b{_spinner[_i]}");
            _i++;
            Thread.Sleep(160);
        }
        else
        {
            _i = 0;
        }
    }

}