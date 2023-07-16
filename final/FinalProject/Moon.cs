using System;

public class Moon : CelestialObject
{
    private Planet _parent;
    public void OrbitalPeriod()
    {
        
    }
    public Moon(string _name, double _mass, string _type, Planet parent) : base(_name, _mass, _type)
    {
        _parent = parent;
        MakeSaveString($"{_type},{_name},{_mass},{_type}");
    }

    public override void Summary()
    {
        Console.WriteLine($"Name: {Name()}\nMass: {Mass()} Earth Masses");
    }
}