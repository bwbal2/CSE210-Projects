using System;

public abstract class CelestialObject
{
    private string _name;
    private string _type;
    private double _mass;
    private string _saveString;
    public virtual double Mass()
    {
        return _mass;
    }
    public void ReName(string name)
    {
        _name = name;
    }
    public string Name()
    {
        return _name;
    }
    public string Type()
    {
        return _type;
    }
    public abstract void Summary();
    public CelestialObject(string name, double mass, string type)
    {
        _name = name;
        _mass = mass;
        _type = type;
    }
    public CelestialObject(string name, string type)
    {
        _name = name;
        _type = type;
    }
    public CelestialObject(string name, double mass)
    {
        _name = name;
        _mass = mass;
    }
    public string SaveString()
    {
        return _saveString;
    }
    public virtual List<Stellar> Stellars()
    {
        return new List<Stellar>{};
    }
    public CelestialObject()
    {

    }
    public void MakeSaveString(string theString)
    {
        _saveString = theString;
    }

}