using System;

public class Neutron : Stellar
{
    private Random random = new Random();
    private double _magField;
    public double MagField()
    {
        return 1;
    }
    public Neutron(string _name, double _mass, string _type) : base(_name, _mass, _type)
    {
        MakeSaveString($"{_type},{_name},{_mass},{_type}");
        _magField = random.Next(100000000,1000000000);
    }
    public override void Summary()
    {
        Console.WriteLine($"Name: {Name()}\nMass: {Mass()} Solar Masses\nMagnetic Field: {_magField} G");
    }

}