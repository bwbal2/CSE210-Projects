using System;

public class WritingAssignment : Assignment
{

    private string _title;

    public string GetWritingInfo()
    {
        string title = $"{_title} by {GetName()}";
        return title;
    }

    public WritingAssignment(string name, string topic, string title) : base(name, topic)
    {
        _title = title;
    }
}