using System;

public abstract class Goal
{

    private string _goalName;
    private string _description;
    bool _completed = false;
    private int _score;
    private string _goalString;
    private string _type;
    public string GoalName()
    {
        return _goalName;
    }

    public void DisplayGoal()
    {
        string checkBox = "[ ]";
        if (_completed == true)
        {
            checkBox = "[X]";
        }
        Console.Write($"{checkBox} {_goalString}");
    }
    public virtual void Display()
    {
        DisplayGoal();
        Console.WriteLine();
    }
    public string GoalInfoBase()
    {
        return $"{_type}, {_goalName}, {_description}, {_score}, {_completed}";
    }
    public string Type()
    {
        return _type;
    }


    public Goal(string goalName, string description, int score, string type, string goalString, bool _completed)
    {
        _goalName = goalName;
        _description = description;
        _type = type;
        _goalString = goalString;
        _score = score;

    }
    public virtual int RecordEvent()
    {
        _completed = true;
        return ReturnScore();
    }
    public virtual int ReturnScore()
    {
        return _score;
    }
    public int GetScore()
    {
        return _score;
    }
    public void Complete()
    {
        _completed = true;
    }
}