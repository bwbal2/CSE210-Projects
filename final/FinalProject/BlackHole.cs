using System;

public class BlackHole : Stellar
{
    public BlackHole(string _name, double _mass, string _type) : base(_name, _mass, _type)
    {
        MakeSaveString($"{_type},{_name},{_mass},{_type}");

        
    }

    public override void Summary()
    {
        Console.WriteLine($"Name: {Name()}\nMass: {Mass()} Solar Masses\nSwarzchild Radius: {(2*6.67*Math.Pow(10,-11)*Mass()*1.998*Math.Pow(10,30)/(Math.Pow(3*Math.Pow(10,8),2)))/1000} km");
    }
}