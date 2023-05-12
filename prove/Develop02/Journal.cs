using System;


public class Journal
{

    public List<Entry> _oldEntries = new List<Entry>();
    public List<Entry> _newEntries = new List<Entry>();

    public List<string> _promptList = new List<string>();
    public List<string> _promptListNew = new List<string>();

//Entry Functions
    public void newEntry()
    {
         string prompt = choosePrompt();
        _newEntries.Add(new Entry());
        _newEntries.Last().writeEntry(prompt);

    }

    public void displayNew()
    {
      foreach (Entry e in _newEntries)
         {
            e.displayEntry();
         }  

    }

    public void displayOld()
    {
        string journalFile = "JournalSave.csv";

         string[] lines = System.IO.File.ReadAllLines(journalFile);

         foreach (string line in lines)
         {
            string[] parts = line.Split(",");
            Console.Write($"{parts[0]}    ");
            Console.Write($"Prompt:{parts[1]}    ");
            Console.Write($"Response:{parts[2]}    ");
            Console.Write($"Image:{parts[3]}\n");

         }
    }
////////////////////////////////////
//Prompt Functions
    public void writePrompt()
    {
        Console.Write("Enter your new prompt: ");
        string promptNew = Console.ReadLine();
        _promptListNew.Add(promptNew);
    }


    public void savePrompts()
    {

      string journalFile = "Prompts.csv";

      using (StreamWriter outputFile = new StreamWriter(journalFile))
      {
         foreach (string p in _promptList)
         {
            outputFile.WriteLine($"{p},");
         }
         foreach (string p in _promptListNew)
         {
            outputFile.WriteLine($"{p},");
            _promptList.Add(p);
         }
      }
    }

    public void loadPrompts()
    {
      string promptFile = "Prompts.csv";
         string[] lines = System.IO.File.ReadAllLines(promptFile);

         foreach (string line in lines)
         {
            string[] parts = line.Split(",");
            _promptList.Add(parts[0]);
         }
        

    }


   public void load()
   {
      loadPrompts();
      loadJournal();
   }



    public void loadJournal()
    {
        string journalFile = "JournalSave.csv";

         string[] lines = System.IO.File.ReadAllLines(journalFile);

         foreach (string line in lines)
         {
            string[] parts = line.Split(",");
            _oldEntries.Add(new Entry());
            _oldEntries.Last()._dateTime = parts[0];
            _oldEntries.Last()._prompt = parts[1];
            _oldEntries.Last()._answer = parts[2];
            _oldEntries.Last()._image = parts[3];

         }
        }


    public string choosePrompt()
    {
        var random = new Random();
        int index = random.Next(_promptList.Count);
        return _promptList[index];
    }
    ////////////////////////////////////////////////////////
    //Journal Functions
    //Saves all entries to the list of old entries, writes to csv
    public void saveJournal()
    {
      string journalFile = "JournalSave.csv";

      using (StreamWriter outputFile = new StreamWriter(journalFile))
      {
         foreach (Entry e in _oldEntries)
         {
         // You can add text to the file with the WriteLine method
         outputFile.WriteLine($"{e._dateTime}, {e._prompt}, {e._answer}, {e._image},");

         }
         foreach (Entry e in _newEntries)
         { 
         // You can add text to the file with the WriteLine method
         outputFile.WriteLine($"{e._dateTime}, {e._prompt}, {e._answer}, {e._image},");
         _oldEntries.Add(e);

         }

         _newEntries.Clear();
      }
    }
}