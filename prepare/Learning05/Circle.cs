using System;

public class Circle : Shape
{
    private double _radius;

    public override double GetArea()
    {
        return _radius*_radius*3.1415926;
    }
    public Circle(string _color, double radius) : base(_color)
    {
        _radius = radius;
    }
}