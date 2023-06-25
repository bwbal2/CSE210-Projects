using System;

public class Runner
{

    private List<Simple> _oldSimpleGoals = new List<Simple>();
    private List<Checklist> _oldChecklistGoals = new List<Checklist>();
    private List<Eternal> _oldEternalGoals = new List<Eternal>();
    private List<Simple> _newSimpleGoals = new List<Simple>();
    private List<Checklist> _newChecklistGoals = new List<Checklist>();
    private List<Eternal> _newEternalGoals = new List<Eternal>();
    private List<Goal> _allOldGoals = new List<Goal>();

    private int _points = 0;
    private bool _quit = false;



    public bool Menu()
    {
        Console.WriteLine($"\nYou have {_points} points.");
        Console.Write("\nMenu Options:\n1. Create Goal\n2. List Goals\n3. Save Goals\n4. Load Goals\n5. Record Event\n6. Quit\nSelect a choice from the menu: ");
        string input = Console.ReadLine();
        switch(input)
        {
            case "1":
            CreateGoal();
            break;
            case "2":
            DisplayGoals();
            break;
            case "3":
            SaveGoals();
            break;
            case "4":
            LoadGoals();
            break;
            case "5":
            Record();
            break;
            case "6":
            _quit = true;
            break;
            default:
            Console.Clear();
            Console.WriteLine("Invalid input, please try again.\n");
            break;
        }

        return _quit;
    }


    public void CreateGoal()
    {
        Console.Write("\nThe types of Goals are:\n1. Simple Goal\n2. Checklist Goal\n3. Eternal Goal\nWhich type of goal would you like to create?: ");
        string goalType = Console.ReadLine();
        switch(goalType)
        {
            case "1":
            CreateSimple();
            break;
            case "2":
            CreateChecklist();
            break;
            case "3":
            CreateEternal();
            break;
            default:
            Console.Clear();
            Console.WriteLine("Invalid input. Try again.");
            break;
        }
    }

    public void CreateSimple()
    {
        Console.Write("\n\nWhat is the name of your goal?: ");
        string name = Console.ReadLine();
        Console.Write("\nWhat is a short description of it?: ");
        string description = Console.ReadLine();
        Console.Write("\nWhat is the amount of points associated with this goal?: ");
        int score = int.Parse(Console.ReadLine());
        _newSimpleGoals.Add(new Simple(name,description,score,"Simple",$"{name} ({description}),",false));
    }

    public void CreateChecklist()
    {
        Console.Write("\n\nWhat is the name of your goal?: ");
        string name = Console.ReadLine();
        Console.Write("\nWhat is a short description of it?: ");
        string description = Console.ReadLine();
        Console.Write("\nWhat is the amount of points associated with this goal?: ");
        int score = int.Parse(Console.ReadLine());
        Console.Write("\nHow many times does this goal need to be accomplished for a bonus?: ");
        int max = int.Parse(Console.ReadLine());
        Console.Write("\nWhat is the bonus for accomplishing it that many times?: ");
        int bonus = int.Parse(Console.ReadLine());
        _newChecklistGoals.Add(new Checklist(name,description,score,max,bonus,false,"Checklist",$"{name} ({description})", 0));

    }

    public void CreateEternal()
    {
        Console.Write("\n\nWhat is the name of your goal?: ");
        string name = Console.ReadLine();
        Console.Write("\nWhat is a short description of it?: ");
        string description = Console.ReadLine();
        Console.Write("\nWhat is the amount of points associated with this goal?: ");
        int score = int.Parse(Console.ReadLine());
        _newEternalGoals.Add(new Eternal(name,description,score,"Eternal",$"{name} ({description})",false));
        
    }
    public void SaveGoals()
    {

        Console.Write("\nWhat is the filename for the goal file?: ");
        string filename = Console.ReadLine();
        foreach(Simple goal in _newSimpleGoals)
        {
            _oldSimpleGoals.Add(goal);
        }
        _newSimpleGoals = new List<Simple>();
        foreach(Checklist goal in _newChecklistGoals)
        {
            _oldChecklistGoals.Add(goal);
        }
        _newChecklistGoals = new List<Checklist>();
        foreach(Eternal goal in _newEternalGoals)
        {
            _oldEternalGoals.Add(goal);
        }
        _newEternalGoals = new List<Eternal>();


        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_points);
            foreach (Simple goal in _oldSimpleGoals)
            {
                    outputFile.WriteLine($"{goal.GoalInfoBase()}");
            }
            foreach (Checklist goal in _oldChecklistGoals)
            {
                    outputFile.WriteLine($"{goal.GoalInfoBase()}, {goal.ChecklistParts()}");
            }
            foreach (Eternal goal in _oldEternalGoals)
            {
                    outputFile.WriteLine($"{goal.GoalInfoBase()}");
            }
        }
    }


    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file?: ");
        string filename = Console.ReadLine();
        string[] lines = System.IO.File.ReadAllLines(filename);
        _points += int.Parse(lines[0]);
        foreach (string line in lines)
        {

        string[] parts = line.Split(",");
        if (parts[0] == "Simple")
        {
            _oldSimpleGoals.Add(new Simple(parts[1],parts[2],int.Parse(parts[3]),parts[0],$"{parts[1]} ({parts[2]})",Boolean.Parse(parts[4])));
        }
        else if (parts[0] == "Eternal")
        {
            _oldEternalGoals.Add(new Eternal(parts[1],parts[2],int.Parse(parts[3]),parts[0],$"{parts[1]} ({parts[2]})",false));
        }
        else if (parts [0] == "Checklist")
        {
            _oldChecklistGoals.Add(new Checklist(parts[1],parts[2],int.Parse(parts[3]), int.Parse(parts[6]) , int.Parse(parts[7]),Boolean.Parse(parts[4]),parts[0],$"{parts[1]} ({parts[2]})", int.Parse(parts[5])));
        }

        }
        foreach (Goal goal in _oldSimpleGoals)
        {
            _allOldGoals.Add(goal);
        }
        foreach (Goal goal in _oldChecklistGoals)
        {
            _allOldGoals.Add(goal);
        }
        foreach (Goal goal in _oldEternalGoals)
        {
            _allOldGoals.Add(goal);
        }

    }//tally, max, bonus

    //max, bonus, last is tally



    public void DisplayGoals()
    {
        Console.WriteLine("The goals are:");
        int i = 1;
        foreach (Goal goal in _oldSimpleGoals)
        {

            Console.Write($"{i}.  ");
            goal.Display();
            i++;
        }
        foreach (Goal goal in _oldChecklistGoals)
        {

            Console.Write($"{i}.  ");
            goal.Display();
            i++;
        }
        foreach (Goal goal in _oldEternalGoals)
        {

            Console.Write($"{i}.  ");
            goal.Display();
            i++;
        }
    }
    public void Record()
    {
        DisplayGoals();
        Console.WriteLine("Which goal did you accomplish?: ");
        int inputGoal = int.Parse(Console.ReadLine());
        Goal daGoal = _allOldGoals[inputGoal-1];
        if (daGoal.Type() == "Simple")
        {
        foreach (Goal goal in _oldSimpleGoals)
        {
            if (goal.GoalName() == daGoal.GoalName())
        {
            _points += goal.RecordEvent();
        }

        }
        }
        else if (daGoal.Type() == "Checklist")
        {
        foreach (Goal goal in _oldSimpleGoals)
        {
        if (goal.GoalName() == daGoal.GoalName())
        {
            _points += goal.RecordEvent();
        }
        }
        }
        else if (daGoal.Type() == "Eternal")
        {
        foreach (Goal goal in _oldSimpleGoals)
        {

            if (goal.GoalName() == daGoal.GoalName())
            {
            _points += goal.RecordEvent();
            }
        }
        }

    }


}