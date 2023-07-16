using System;

public class Binary : CelestialObject
{
    private Stellar _stellar1;
    private Stellar _stellar2;

    public Binary(string _name, string _type, Stellar stellar1, Stellar stellar2) : base(_name, _type)
    {
        _stellar1 = stellar1;
        _stellar2 = stellar2;
    }
    public override void Summary()
    {
        _stellar1.Summary();
        _stellar2.Summary();
    }
    public override double Mass()
    {
        return _stellar1.Mass() + _stellar2.Mass();
    }
    public override List<Stellar> Stellars()
    {
        return new List<Stellar>{_stellar1,_stellar2};
    }

}