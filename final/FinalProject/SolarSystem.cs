using System;

public class SolarSystem
{
    private string _name;
    private CelestialObject _parentObject;
    private List<Planet> _planetList = new List<Planet>();
    public Planet CreatePlanet()
    {
        Console.Write("Enter the name of this planet: ");
        string name = Console.ReadLine();
        bool valid = false;
        double mass = 0;
        while (valid == false)
        {
            Console.Write("\nEnter the mass of this planet in Earth masses [0.1-20000]: ");
            string input = Console.ReadLine();
            valid = CheckValue(0.1,20000,input);
            if (valid == true)
            {
                mass = Double.Parse(input);
            }
        }



        double percent = 100;
        double gasComp = 0;
        while (valid == false)
        {
            Console.Write("\nEnter the percentage of mass that is made of gas, (H, He, O, etc.) [100% remaining]: ");
            string input = Console.ReadLine();
            valid = CheckValue(0,percent,input);
            if (valid == true)
            {
                gasComp = Double.Parse(input);
            }

        }
        valid = false;
        percent = 100 - gasComp;


        double silicaComp = 0;
        while (valid == false)
        {
            Console.Write($"\nEnter the percentage of mass that is made of silicates (dirt, rocks, etc.) [{percent}% remaining]: ");
            string input = Console.ReadLine();
            valid = CheckValue(0,percent,input);
            if (valid == true)
            {
                silicaComp = Double.Parse(input);
            }
        }
        valid = false;
        percent -= silicaComp;
        double waterComp = 0;
        while (valid == false)
        {
            Console.Write($"\nEnter the percentage of mass that is made of water/ice [{percent}% remaining]: ");
            string input = Console.ReadLine();
            valid = CheckValue(0,percent,input);
            if (valid == true)
            {
                waterComp = Double.Parse(input);
            }
        }
        

        percent -= waterComp;
        valid = false;

        Console.WriteLine($"\nThe remaining percentage will be made of metal. You can edit this later.");
        double metalComp = percent;



        double orbDistance = 0;
        while (valid == false)
        {
        Console.Write("\nEnter the distance between this planet and the gravitational center \nof its solar system (in AU [0.1-100], 1 AU is the distance between Earth and the Sun): ");
            string input = Console.ReadLine();
            valid = CheckValue(0.1,100,input);
            if (valid == true)
            {
                orbDistance = Double.Parse(input);
            }
        }

        valid = false;
        double rotatePeriod = 0;

        while (valid == false)
        {
            Console.Write("\nHow long [in hours] does it take for this planet to rotate on its axis?: ");            
            string input = Console.ReadLine();
            valid = CheckValue(0.1,100,input);
            if (valid == true)
            {
                rotatePeriod = Double.Parse(input);
            }
        }



        bool rings = false;
        List<string> ans = new List<string>{"y","yes","n","no"};
        string ringAns = "";
        while (!ans.Contains(ringAns.ToLower()))
        {
        Console.Write("\nFinally, does this planet have rings? [Y/N]: ");
        ringAns = Console.ReadLine();
        switch(ringAns.ToLower())
        {
            case "y":
            case "yes":
            rings = true;
            break;
            case "n":
            case "no":
            rings = false;
            break;
            default:
            Console.WriteLine("Invalid response. Please try again: ");
            break;
        }
        }

        Planet planet = new Planet(name, mass, gasComp, silicaComp, waterComp, metalComp, orbDistance, rotatePeriod, rings, _parentObject);
        _planetList.Add(planet);
        return planet;
    }

    public Moon CreateMoon(Planet planet)
    {
        Console.Write("Enter the name of this moon: ");
        string name = Console.ReadLine();
        bool valid = false;
        double mass = 0;
        while (valid == false)
        {
            Console.Write("\nEnter the mass of this planet in Earth masses [0.1-1]: ");
            string input = Console.ReadLine();
            valid = CheckValue(0.1,1,input);
            if (valid == true)
            {
                mass = Double.Parse(input);
            }
        }
        return new Moon(name, mass, "Moon",planet);
    }



    public bool CheckValue(double lower,double upper, string input)
    {
        bool valid = false;
            switch(DoubleParseCheck(input))
            {
                case true:
                valid = true;
                break;
                default:
                Console.WriteLine("Invalid input. please try again by writing a number.");
                valid = false;
                return valid;
            }
            double doubleInput = Double.Parse(input);
            switch(CheckValidDouble(lower,upper,doubleInput))
            {
                case true:
                valid = true;
                break;
                case false:
                Console.WriteLine("Number out of range, please try again.");
                valid = false;
                return valid;
            }
            return valid;

    }
    public bool CheckValidDouble(double lower, double upper, double input)
    {
        if (input >= lower && input <= upper)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool DoubleParseCheck(string input)
    {
        double a;
        
        return Double.TryParse(input, out a);
    }






    public void ChangePlanet(int index)
    {
        Console.WriteLine("Would you like to REMAKE the planet, or add a MOON? (answer with REMAKE or MOON): ");
        string input = Console.ReadLine();
        switch(input.ToLower())
        {
            case "remake":
            Console.WriteLine("Let's edit this planet's properties.");
            RemovePlanet(index);
            CreatePlanet();
            break;
            case "moon":
            Console.WriteLine("Let's create a moon.");
            CreateMoon(_planetList[index]);
            break;
            default:
            Console.WriteLine("Invalid answer. Please try again.");
            break;
        }

    }
    public void CreateSystem()
    {
        Console.Write("\nWhat would you like to name this system?: ");
        _name = Console.ReadLine();
        CreateStar();
    }
    public void CreateStar()
    {
        Console.Write("What would you like this system to be named?: ");
        _name = Console.ReadLine();
        Console.Write("\n1. Main Sequence\n2. White Dwarf\n3. Neutron Star\n4. Black Hole, \n5. Binary System\n\nWhat kind of star would you like to make?: ");
        string star = Console.ReadLine();
        List<string> stars = new List<string>{"1","2","3","4","5","binary system","main sequence","black hole","neutron star","white dwarf"};
        while (!stars.Contains(star.ToLower()))
        {
            Console.WriteLine("Invalid input, please try again.\n");
            Console.Write("\n1. Main Sequence\n2. White Dwarf\n3. Neutron Star\n4. Black Hole, \n5. Binary System\n\nWhat kind of star would you like to make?: ");
            star = Console.ReadLine();
        }
        switch(star.ToLower())
        {
            case "1":
            case "main sequence":
            _parentObject = CreateMain(_name);
            break;
            case "2":
            case "white dwarf":
            _parentObject = CreateDwarf(_name);
            break;
            case "3":
            case "neutron star":
            _parentObject = CreateNeutron(_name);
            break;
            case "4":
            case "black hole":
            _parentObject = CreateBlackHole(_name);
            break;
            case "5":
            case "binary system":
            _parentObject = CreateBinary(_name);
            break;
        }
        Console.WriteLine("\nYour new solar system has been created. You can view it with the \"Display Galaxy\" option \nand add to it using the \"Edit Solar Systems\" option.\n ");
    }

    public string Name()
    {
        return _name;
    }
    public string Type()
    {
        return _parentObject.Type();
    }
    public MainSequence CreateMain(string name)
    {


        bool valid = false;
        double mass = 0;
        while (valid == false)
        {
            Console.Write("What would you like the mass of this star to be, in solar masses? [0.1-150]: ");
            string input = Console.ReadLine();
            valid = CheckValue(0.1,150,input);
            if (valid == true)
            {
                mass = Double.Parse(input);
            }

        }

        valid = false;
        double metalComp = 0;

        while (valid == false)
        {
        Console.Write("What percentage of this star is metal? [0-4%]: ");
        string input = Console.ReadLine();
        valid = CheckValue(0,4,input);
        if (valid == true)
            {
                metalComp = Double.Parse(input);
            }
        }
        valid = false;
        double percent = 100 - metalComp;

        double heComp = 0;

        while (valid == false)
        {
        Console.Write($"What percentage of this star is Helium? [0-28%]: ");
        string input = Console.ReadLine();
        valid = CheckValue(0,28,input);
        if (valid == true)
            {
                heComp = Double.Parse(input);
            }
        }
        Console.WriteLine("The remaining mass will be composed of Hydrogen.");
        double hComp = percent - heComp;
        return new MainSequence(name, mass, "Main Sequence", Math.Log10(metalComp/hComp), hComp, heComp);


    }
    public Dwarf CreateDwarf(string name)
    {
        bool valid = false;
        double mass = 0;
        while (valid == false)
        {
            Console.Write("What would you like the mass of this White Dwarf to be, in solar masses? [0.3-1.4]: ");
            string input = Console.ReadLine();
            valid = CheckValue(0.3,1.4,input);
            if (valid == true)
            {
                mass = Double.Parse(input);
            }
        }
        return new Dwarf(name, mass, "White Dwarf");
    }
    public Neutron CreateNeutron(string name)
    {
        bool valid = false;
        double mass = 0;
        while (valid == false)
        {
            Console.Write("What would you like the mass of this Neutron Star to be, in solar masses? [1.1-2.5]: ");
            string input = Console.ReadLine();
            valid = CheckValue(1.1,2.5,input);
            if (valid == true)
            {
                mass = Double.Parse(input);
            }
        }
        return new Neutron(name, mass, "Neutron Star");

    }
    public BlackHole CreateBlackHole(string name)
    {
        bool valid = false;
        double mass = 0;
        while (valid == false)
        {
            Console.Write("What would you like the mass of this Black Hole to be, in solar masses? [minimum 2.5]: ");
            string input = Console.ReadLine();
            valid = CheckValue(2.5,999999999999999999,input);
            if (valid == true)
            {
                mass = Double.Parse(input);
            }
        }
        return new BlackHole(name, mass, "Black Hole");
    }
    public Stellar CreateStarForBinary()
    {
        Console.Write("What kind of star would you like to make?: ");
        string star = Console.ReadLine();
        List<string> stars = new List<string>{"1","2","3","4","main sequence","black hole","neutron star","white dwarf"};
        while (!stars.Contains(star.ToLower()))
        {
            Console.WriteLine("Invalid input, please try again.");
        }
        Stellar stellar = new Stellar("null",0,"null");
        switch(star.ToLower())
        {
            case "1":
            case "main sequence":
            stellar = CreateMain(_name);
            break;
            case "2":
            case "white dwarf":
            stellar = CreateDwarf(_name);
            break;
            case "3":
            case "neutron star":
            stellar = CreateNeutron(_name);
            break;
            case "4":
            case "black hole":
            stellar = CreateBlackHole(_name);
            break;

        }
        return stellar;
    }
    public Binary CreateBinary(string name)
    {
        Console.WriteLine("A binary system requires 2 stellar objects. For the first object: ");
        Stellar star1 = CreateStarForBinary();
        Stellar star2 = CreateStarForBinary();
        if (star1.Mass() > star2.Mass())
        {
            star1.ReName($"{name} A");
            star2.ReName($"{name} B");
        }
        else
        {
            star1.ReName($"{name} B");
            star2.ReName($"{name} A");
        }
        return new Binary(name,"Binary System", star1, star2);
    }


    public void ChangeStar()
    {
        Console.WriteLine("Alright, let's change this star system.");
        CreateStar();
    }
    public void RemovePlanet(int index)
    {
        _planetList.RemoveAt(index);
    }
    public int PlanetToggle()
    {
        int i = 0;
        foreach (Planet planet in _planetList)
        {
            Console.WriteLine($"{i}. {planet.Name()}");
        }
        Console.Write("Select a planet: ");
        int index = int.Parse(Console.ReadLine());
        return index;
    }
    public void ListPlanets()
    {
        int i = 1;
        foreach (Planet planet in _planetList)
        {
            Console.Write("\nPlanets: \n");
            Console.Write($"\n{i}. ");
            planet.Summary();
            i++;
        }
        if (_planetList.Count() == 0)
        {
            Console.WriteLine("heck");
        }
    }
    public void DisplaySystem()
    {
        Console.WriteLine("Stellar Object(s):\n");
        _parentObject.Summary();
        ListPlanets();
    }

    public CelestialObject Parent()
    {
        return _parentObject;
    }
    public void Initialize()
    {
        Console.WriteLine("Welcome to your new Solar System!");
        CreateStar();
    }
    public List<string> SaveStrings()
    {
        List<string> strings = new List<string>();
        if (_parentObject.Type() == "Binary System")
        {
            foreach(Stellar stellar in _parentObject.Stellars())
            {
                strings.Add($"Binary, {stellar.SaveString()}");               
            }
        }
        else
        {
        strings.Add(_parentObject.SaveString());
        }
        foreach (Planet planet in _planetList)
        {
            strings.Add(planet.SaveString());
            foreach (Moon moon in planet.Moons())
            {
                strings.Add(moon.SaveString());
            }
        }
        return strings;
    }
    public SolarSystem(CelestialObject parent)
    {
        _parentObject = parent;
        _name = parent.Name();
    }
    public SolarSystem()
    {

    }
    public Planet AddPlanet(Planet planet)
    {
        _planetList.Add(planet);
        return planet;
    }
}