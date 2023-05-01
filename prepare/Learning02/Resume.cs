using System;


public class Resume
{
    public string _name = "";
    public List<Job> _jobList = new List<Job>();

    public void DisplayJobs()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine($"Jobs:");

        foreach (Job j in _jobList)
        {
            j.Display();
        }

    }

}