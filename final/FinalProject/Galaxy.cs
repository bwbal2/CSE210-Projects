using System;

public class Galaxy
{
    private bool _quit = false;
    private List<SolarSystem> _systems = new List<SolarSystem>();
    private List<SolarSystem> _oldSystems = new List<SolarSystem>();
    public bool MainMenu()
    {
        Console.Write("1. Create New System\n2. Display Galaxy\n3. Edit Solar System(s)\n4. Remove System(s)\n5. Save\n6. Quit \nPlease select an option [1-6]: ");
        string input = Console.ReadLine();
        switch(input)
        {
            case "1":
            Console.Clear();
            _systems.Add(CreateSolarSystem());
            break;
            case "2":
            DisplaySystems();
            break;
            case "3":
            EditSystem(_systems[SelectSystem()]);
            break;
            case "4":
            _systems.RemoveAt(SelectSystem());
            Console.WriteLine("System removed.\n");
            break;
            case "5":
            Save();
            break;
            case "6":
            _quit = true;
            break;
            default:
            Console.Clear();
            Console.WriteLine("Invalid input, please try again.\n");
            break;
        }
        return _quit;
    }

    public SolarSystem CreateSolarSystem()
    {
        SolarSystem solarSystem = new SolarSystem();
        solarSystem.Initialize();
        return solarSystem;
    }

    public int SelectSystem()
    {
        Console.Write("Which system would you like to select?: ");
        DisplaySystems();
        string input = Console.ReadLine();
        int index = int.Parse(input) - 1;
        return index;
    }
    public void EditSystem(SolarSystem system)
    {
        Console.Write("1. Create New Planet\n2. Remove Planet\n3. Edit Star\n4. Edit Planet\n5. Display System\n6. Back\nPlease select an option [1-6]: ");
        string input = Console.ReadLine();
        switch(input)
        {
            case "1":
            system.CreatePlanet();
            break;
            case "2":
            system.RemovePlanet(system.PlanetToggle()-1);
            break;
            case "3":
            system.ChangeStar();
            break;
            case "4":
            system.ChangePlanet(system.PlanetToggle()-1);
            break;
            case "5":
            system.DisplaySystem();
            break;
            case "6":
            break;
            default:
            Console.Clear();
            Console.WriteLine("Invalid input, please try again.\n");
            break;
        }

    }
 

    public void Initialize()
    {    
        string filename = "Galaxy.txt";
        string[] lines = System.IO.File.ReadAllLines(filename);
        int binaryCount = 0;
        SolarSystem system = new SolarSystem();
        Stellar stellar = new Stellar();
        Planet planet = new Planet("null",0,0,0,0,0,0,0,false,stellar);
        Binary binary = new Binary("null","null",stellar, stellar);
        foreach (string line in lines)
        {
        
        string[] parts = line.Split(",");
        switch(parts[0])
        {
            case "Binary":
                if (binaryCount == 0)
                {
                    switch(parts[1])
                    {
                        case "Main Sequence":
                        stellar = new MainSequence(parts[1],Double.Parse(parts[2]),parts[3],Double.Parse(parts[4]),Double.Parse(parts[5]),Double.Parse(parts[6]));
                        break;
                        case "White Dwarf":
                        stellar = new Dwarf(parts[1],Double.Parse(parts[2]),parts[3]);
                        break;
                        case "Neutron Star":
                        stellar = new Neutron(parts[2],Double.Parse(parts[3]),parts[4]);
                        break;
                        case "Black Hole":
                        stellar = new BlackHole(parts[2],Double.Parse(parts[3]),parts[4]);
                        break;
                    }

                }
                else 
                {
                    switch(parts[1])
                    {
                        case "Main Sequence":
                        _systems.Add(new SolarSystem(new Binary((stellar.Name()).Remove((stellar.Name()).Length-4),"Binary System",stellar,new MainSequence(parts[1],Double.Parse(parts[2]),parts[3],Double.Parse(parts[4]),Double.Parse(parts[5]),Double.Parse(parts[6])))));
                        system = _systems.Last();
                        break;
                        case "White Dwarf":
                        _systems.Add(new SolarSystem(new Binary((stellar.Name()).Remove((stellar.Name()).Length-4),"Binary System",stellar,new Dwarf(parts[1],Double.Parse(parts[2]),parts[3]))));
                        system = _systems.Last();
                        break;
                        case "Neutron Star":
                        _systems.Add(new SolarSystem(new Binary((stellar.Name()).Remove((stellar.Name()).Length-4),"Binary System",stellar,new Neutron(parts[2],Double.Parse(parts[3]),parts[4]))));
                        system = _systems.Last();
                        break;
                        case "Black Hole":
                        _systems.Add(new SolarSystem(new Binary((stellar.Name()).Remove((stellar.Name()).Length-4),"Binary System",stellar,new BlackHole(parts[2],Double.Parse(parts[3]),parts[4]))));
                        system = _systems.Last();
                        break;
                    }
                }

            break;
            case "Main Sequence":
            _systems.Add(new SolarSystem(new MainSequence(parts[1],Double.Parse(parts[2]),parts[3],Double.Parse(parts[4]),Double.Parse(parts[5]),Double.Parse(parts[6]))));
            system = _systems.Last();
            break;
            case "White Dwarf":
            _systems.Add(new SolarSystem(new Dwarf(parts[1],Double.Parse(parts[2]),parts[3])));
            system = _systems.Last();
            break;
            case "Neutron Star":
            _systems.Add(new SolarSystem(new Neutron(parts[2],Double.Parse(parts[3]),parts[4])));
            system = _systems.Last();
            break;
            case "Black Hole":
            _systems.Add(new SolarSystem(new BlackHole(parts[2],Double.Parse(parts[3]),parts[4])));
            system = _systems.Last();
            break;
            case "Planet":
            planet = system.AddPlanet(new Planet(parts[1],Double.Parse(parts[2]),Double.Parse(parts[3]),Double.Parse(parts[4]),Double.Parse(parts[5]),Double.Parse(parts[6]),Double.Parse(parts[7]), Double.Parse(parts[8]), bool.Parse(parts[9]),system.Parent()));
            
            break;
            case "Moon":
            planet.AddMoon(new Moon(parts[1],Double.Parse(parts[2]),parts[3],planet));
            break;

        }

        }
    }
    public void Save()
    {

        string filename = "Galaxy.txt";
        _oldSystems = _systems;
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (SolarSystem system in _oldSystems)
            {
                foreach (string saveString in system.SaveStrings())
                {
                    outputFile.WriteLine(saveString);
                }
                outputFile.WriteLine("");
            }
        }


    }


    public void DisplaySystems()
    {
        int i = 1;
        Console.WriteLine("Solar Systems:");
        foreach (SolarSystem system in _systems)
        {
            Console.Write($"\n{i}. {system.Name()} - {system.Type()}\n");
            i++;
        }
        Console.WriteLine("");
    }

}