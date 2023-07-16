using System;

public class Planet : CelestialObject
{
    private string _type;
    private double _gasComp;
    private double _silicaComp;
    private double _metalComp;
    private double _waterComp;
    private double _orbDistance;
    private double _rotatePeriod;
    private bool _rings;
    private CelestialObject _parent;
    private List<Moon> _moons = new List<Moon>();
    public List<Moon> Moons()
    {
        return _moons;
    }

    
    public bool orbitValid()
    {
        return true;
    }
    public Planet(string _name, double _mass, double gasComp, double silicaComp, double waterComp, double metalComp, double orbDistance, double rotatePeriod, bool rings, CelestialObject parent) : base(_name, _mass)
    {
        _gasComp = gasComp;
        _silicaComp = silicaComp;
        _waterComp = waterComp;
        _metalComp = metalComp;
        _orbDistance = orbDistance;
        _rotatePeriod = rotatePeriod; 
        _rings = rings;
        _parent = parent;
        MakeSaveString($"Planet,{_name},{_mass},{_gasComp},{_silicaComp},{_waterComp},{_metalComp},{_orbDistance},{_rotatePeriod},{_rings}");
    }
    public string PlanetType()
    {
        string type = "";
        if (_gasComp > 51)
        {
            type = "Gaseous Planet";
        }
        else if (_waterComp > 20)
        {
            type = "Water Planet";
        }
        else
        {
            type = "Terrestrial Planet";
        }
        return type;
    }
    public override void Summary()
    {
        Console.WriteLine($"Name: {Name()}\nMass: {Mass()} Earth Masses \nOrbital Period: {OrbitalPeriod} days \nType: {PlanetType()}\nMoons: {_moons.Count()}\n% Gas: {_gasComp}%\n% Silicates: {_silicaComp}%\n% Water: {_waterComp}%\n% Metal: {_metalComp}%\nOrbital Distance: {_orbDistance} AU\nRotation Period: {_rotatePeriod} days\nRings: {_rings}");
        foreach (Moon moon in _moons)
        {
            moon.Summary();
        }
    }
    public void AddMoon(Moon moon)
    {
        _moons.Add(moon);
    }

    public double OrbitalPeriod()
    {
        return (Math.Sqrt(Math.Pow(_orbDistance*1.496*Math.Pow(10,11),3)*Math.Pow(3.1415926,2)*4/(6.67*Math.Pow(10,-11)*_parent.Mass()*1.998*Math.Pow(10,30))))/(60*60*24);
    }

}