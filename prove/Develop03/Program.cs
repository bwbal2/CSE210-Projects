using System;

class Program
{
    static void Main(string[] args)
    {
        bool done = false;
        Console.Clear();
        Scripture scripture = initialize();
        Console.Clear();
        scripture.display();
        string input = Console.ReadLine();
        if (input == "quit")
        {
            done = true;
        }

        while (done == false)
        {
            done = scripture.iterate();
        }
    }

    static Scripture initialize()
    {
        Random random = new Random();


        string daReferences = "references.csv";
        string[] lines = System.IO.File.ReadAllLines(daReferences);
        int r = random.Next(lines.Length);
        string[] parts = lines[r].Split(",");
        int i = 1;


        List<string> verses = new List<string>();
        Reference reference;

        if (parts.Length > 4)
        {
            i = 0;
            foreach (string thing in parts)
            {
                if (i > 2)
                {
                    verses.Add(thing);
                }
                i++;
            }
            reference = new Reference(parts[0],parts[1],verses);
        }
        else
        {
            reference = new Reference(parts[0],parts[1],parts[2]);
        }
         

        string daBook = "book.csv";
        string[] lines2 = System.IO.File.ReadAllLines(daBook);
        List<Word> wordList = new List<Word>();


        string[] parts2 = lines2[r].Split("|");
        foreach (string word in parts2)
        {
            wordList.Add(new Word(word));
        }
        Console.Write("What difficulty would you like to try? (1-5): ");

        string input = Console.ReadLine();
        while (input != "1" && input != "2" && input != "3" && input != "4" && input != "5" )
        {
        Console.Write("Invalid answer, please try again.\nWhat difficulty would you like to try? (1-5): ");
        input = Console.ReadLine();
        }
        int difficulty = int.Parse(input);



        
        Scripture scripture = new Scripture(reference, wordList, difficulty);
        return scripture;
    }
}