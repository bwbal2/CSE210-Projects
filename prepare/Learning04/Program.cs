using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment = new Assignment("Schmurt","Lorentz Transformations");
        MathAssignment mAssignment = new MathAssignment("Schnorp","Differential Equations","4","4-7, 9, 12");
        WritingAssignment wAssignment = new WritingAssignment("Schmingle","Infamous Writings of History","The Industrial Revolution and its Failures");

        Console.WriteLine(assignment.GetSummary());
        Console.WriteLine($"\n{mAssignment.GetSummary()}\n{mAssignment.GetHomeworkList()}");
        Console.WriteLine($"\n{wAssignment.GetSummary()}\n{wAssignment.GetWritingInfo()}");
    }
}