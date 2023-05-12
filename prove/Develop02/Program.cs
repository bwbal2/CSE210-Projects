using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal1 = initialize();
        bool runJournal = true;
        while (runJournal == true)
        {
            runJournal = loop(journal1);
            
        }

    }
    
    static Journal initialize()
    {
        Journal Journal1 = new Journal();
        Journal1.load();
        return Journal1;
    } 

    static bool loop(Journal Journal1)
    {
        List<string> inputs = new List<string>{"write","display","load","save","new prompt","quit","1","2","3","4","5","6"};
        Console.Write("1. Write \n2. New Prompt\n3. Display \n4. Load \n5. Save \n6. Quit \nWhat would you like to do? ");
        string input = (Console.ReadLine()).ToLower();

        if (input == "quit" || input == "6")
        {
            return false;
        }
        else
        {
            if (input == "write" || input == "1")
            {
                Journal1.newEntry();
                Console.WriteLine("Entry recorded.");
            }
            else if (input == "new prompt" || input == "2")
            {
                Journal1.writePrompt();
                Console.WriteLine("Prompt recorded.");
            }

            else if (input == "display" || input == "3")
            {
                Journal1.displayNew();

            }

            else if (input == "load" || input == "5")
            {
                Journal1.displayOld();
                
            }
            else if (input == "save" || input == "4")
            {
                Journal1.saveJournal();
                Journal1.savePrompts();
                Console.WriteLine("Journal saved.");
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
            return true;
        }

    }
}