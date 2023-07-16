using System;

public class MainSequence : Stellar
{
    private double _hComp;
    private double _heComp;
    private double _feH;
    public MainSequence(string _name, double _mass, string _type, double feH, double hComp, double heComp) : base(_name, _mass, _type)
    {
        _feH = feH;
        _hComp = hComp;
        _heComp = heComp;
        MakeSaveString($"{_type},{_name},{_mass},{_type},{_feH},{_hComp},{_heComp}");

    }

    public override void Summary()
    {
        Console.WriteLine($"Name: {Name()}\nMass: {Mass()} Solar Masses\nMetallicity Index: {_feH} Fe/H\n% H: {_hComp}%\n% He: {_heComp}% ");
    }
}