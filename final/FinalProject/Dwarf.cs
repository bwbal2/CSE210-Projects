using System;

public class Dwarf : Stellar
{

    public Dwarf(string _name, double _mass, string _type) : base(_name, _mass, _type)
    {
        MakeSaveString($"{_type},{_name},{_mass},{_type}");
    }

    public override void Summary()
    {
        Console.WriteLine($"Name: {Name()}\nMass: {Mass()} Solar Masses");
    }

}