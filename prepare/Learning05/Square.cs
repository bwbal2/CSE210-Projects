using System;

public class Square : Shape
{
    private double _side;

    public override double GetArea()
    {
        return _side*_side;
    }

    public Square(string _color, double side) : base(_color)
    {
        _side = side;
    }
}