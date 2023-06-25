using System;

public class Eternal : Goal
{

    public Eternal(string goalName, string description, int score, string _type, string _goalString, bool _completed): base(goalName, description, score, _type, _goalString, _completed)
    {
    }

    public override int RecordEvent()
    {
        return ReturnScore();
    }

}