using System;

public class MathAssignment : Assignment
{

    private string _textbookSection;
    private string _problems;

    public string GetHomeworkList()
    {
        string hwList = $"Section {_textbookSection} Problems {_problems}";
        return hwList;
    }

    public MathAssignment(string name, string topic, string section, string problems) : base(name, topic)
    {
        _textbookSection = section;
        _problems = problems;
    }
}