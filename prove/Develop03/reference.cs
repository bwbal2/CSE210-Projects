using System;

public class Reference
{


    private string _bookName = "";
    private string _chapter = "";
    private string _verse = "";


    public void printRef() //Shows the entry
    {
        Console.Write($"{_bookName} {_chapter}:{_verse} ");
    }

    public Reference(string book, string chapter, string verse)
    {
        _bookName = book;
        _chapter = chapter;
        _verse = verse;
    }
    public Reference(string book, string chapter, List<string> verses)
    {
        _bookName = book;
        _chapter = chapter;
        _verse = $"{verses[0]}-{verses[-1]}";
    }


}