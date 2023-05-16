using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction frac1 = new Fraction();
        Fraction frac2 = new Fraction(2);
        Fraction frac3 = new Fraction(3,4);
        Fraction frac4 = new Fraction(5,6);
        List<Fraction> fractions = new List<Fraction>{frac1,frac2,frac3,frac4};
        foreach (Fraction f in fractions)
        {
            f.printFraction();
            f.printDecimal();
        }

    }
}