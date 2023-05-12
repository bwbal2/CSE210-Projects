using System;

public class Entry
{


    public string _prompt = "";
    public string _answer = "";
    public string _dateTime = "";
    public string _image = "";
    public string _entryText = "";

    public void displayEntry() //Shows the entry
    {
        Console.WriteLine($"{_entryText}");
    }

    public void writeEntry(string prompt)
    {
        _dateTime = (DateTime.Now).ToString();
        _prompt = prompt;
        Console.Write($"{prompt}: ");
        _answer = Console.ReadLine();
        requestImage();
        _entryText = $"{_dateTime}    Prompt: {_prompt}    Response: {_answer}    Image: {_image}";
        
    }


    public void requestImage()
    {
        Console.Write("Enter photo path, or type \"No\" to not add an image: ");
        _image = Console.ReadLine();
        if (_image == "No" || _image == "no")
        {
            _image = "N/A";
        }
        

    }


}