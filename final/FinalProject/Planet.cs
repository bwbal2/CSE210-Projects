using System;

public class Planet : CelestialObject
{
    private string _type;
    private double _gasComp;
    private double _silicaComp;
    private double _metalComp;
    private double _waterComp;
    private double _orbDistance;
    private double _surfaceTemp;
    private double _rotatePeriod;
    private double _orbitPeriod;
    private bool _rings;
    private string _lifeType;

    
    public virtual void OrbitalPeriod()
    {

    }
    public bool orbitValid()
    {
        return true;
    }
    public string LifeTypes()
    {
        return "lifetypes";
    }


}