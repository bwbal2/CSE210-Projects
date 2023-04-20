using System;

class Program
{
    static void Main(string[] args)
    {

        bool play = true;
        while (play == true)
        {
            int magicNumber = 0;
            int guessCount = 0;
            Console.Write("What is the magic number? ");
            magicNumber = int.Parse(Console.ReadLine());
            int guess = 999;

            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                if (guess > magicNumber)
                {

                    Console.WriteLine("Lower");

                }
                else if (guess < magicNumber)
                {

                    Console.WriteLine("Higher");

                }
                guessCount++;
            }
            string answer = "aowiefnoawinef";
            Console.WriteLine("You guessed it!");
            Console.Write("Play again? (yes/no): ");
            answer = Console.ReadLine();
            while (answer != "yes" && answer!= "no" && answer!= "Yes" && answer!= "No" && answer!= "N" && answer!= "Y" && answer!= "y" && answer!= "n")
            {
                Console.WriteLine("Invalid response. Please try again.");
                Console.Write("Play again? (yes/no): ");
                answer = Console.ReadLine();
            }
            if (answer == "yes" || answer == "Yes" || answer == "y" || answer == "Y")
            {
                play = true;
            }
            else
            {
                play = false;
            }
        }
    {


    }
    }

}