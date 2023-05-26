using System;

public class Scripture
{

    static Random random = new Random();
    private Reference _reference;
    private List<Word> _words;
    private int _wordsLen;
    private bool _done = false;
    private int _difficulty;
    private string _input;


    public void display()
    {
        _reference.printRef();
        foreach (Word word in _words)
        {
            word.printWord();

        }
        Console.Write("\n\nPress enter to continue, or type 'quit' to finish: ");
    }


    public void hideWords()
    {
        int i = 0;
        
        while (i < _difficulty && _wordsLen >= _difficulty)
        {
            int r = random.Next(_words.Count);
            if (_words[r].checkVisible() == true)
            {
                _words[r].hideWord();
                _wordsLen--;
                i++;
            }
        }
        if (_wordsLen < _difficulty)
        {
            foreach (Word word in _words)
            {
                if (word.checkVisible() == true)
                {
                    word.hideWord();
                }
            _done = true;
            }
        }
    }


    public bool iterate()
    {
        Console.Clear();
        hideWords();
        display();
        _input = Console.ReadLine();
        if (_input == "quit")
        {
            _done = true;
        }
        return _done;
    }



    public Scripture(Reference reference, List<Word> words, int difficulty)
    {
        _reference = reference;
        _words = words;
        _wordsLen = _words.Count;
        _difficulty = difficulty;
    }

}