using System;

public class Checklist : Goal
{
    private int _max;
    private int _bonus;
    private int _tally;

    public Checklist(string _goalName, string _description, int _score, int max, int bonus, bool _completed, string _type, string _goalString,  int tally): base(_goalName, _description, _score, _type, _goalString, _completed)
    {
        _max = max;
        _bonus = bonus;
        _tally = tally;
    }
    public override void Display()
    {
        DisplayGoal();
        Console.WriteLine($" -- Currently completed: {_tally}/{_max}");
    }
    public string ChecklistParts()
    {
        return $"{_tally}, {_max}, {_bonus}";
    }

    public override int ReturnScore()
    {
        if (_tally % _max == 0)
        {
            return (GetScore() + _bonus);
        }
        else
        {
            return GetScore();
        }
    }
    public override int RecordEvent()
    {
        _tally += 1;
        if (_tally >= _max)
        {
            Complete();
        }
        return ReturnScore();
    }
}