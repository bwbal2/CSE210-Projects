using System;

public class Word
{


    private string _word;
    private bool _visible = true;
    List<char> _symbols = new List<char>{' ','-',':',';','!',',','?','(',')','\'','\"'};


    public void hideWord()
    {
        string blank = "";
        foreach (char l in _word)
        {
            if (!_symbols.Contains(l))
            {
                blank += "_";
            }
            else
            {
                blank += l;
            }
        }
        _word = blank;
        _visible = false;
    }

    public bool checkVisible()
    {
        return _visible;
    }

    public void printWord()
    {
        Console.Write(_word);
    }

    public Word(string text)
    {
        _word = text;
    }

}