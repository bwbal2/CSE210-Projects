using System;

public class Stellar : CelestialObject
{
    private double _temp;
    private double _luminosity;
    private double _radius;
    private bool _life;
    public virtual bool Life()
    {
        return _life;
    }

}