using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>{new Rectangle("Blue",20,30), new Square("Red",20), new Circle("Green", 20)};
        int i = 0;
        foreach (Shape shape in shapes)
        {
            i++;
            Console.WriteLine($"Shape {i} is the color {shape.GetColor()} and has an area of {shape.GetArea()}.");
        }
    }
}