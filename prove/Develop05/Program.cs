using System;

class Program
{
    static void Main(string[] args)
    {
        bool quit = false;
        Runner runner = new Runner();
        while (quit == false)
        {
            quit = runner.Menu();
        }
    }
}