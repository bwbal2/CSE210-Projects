using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        //List<int> numbers = new List<int>();
        //List<string> words = new List<string>();

        // words.Add("phone");
        // words.Add("keyboard");
        // words.Add("mouse");

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        int input = 1;
        int count = 0;
        int sum = 0;
        float avg = 0;
        int largest = 0;
        int smallestP = 100000;
        List<int> numbers = new List<int>();
        while (input != 0)
        {
            Console.Write("Enter number: ");
            input = int.Parse(Console.ReadLine());
            numbers.Add(input);
            count++;
        }
        count -= 1;

        foreach (int num in numbers)
        {
            sum += num;
            if (num > largest)
            {
                largest = num;
            }
            if (num < smallestP && num > 0)
            {
                smallestP = num;
            }
        }

        float sumF = (float)sum;
        count = numbers.Count;
        float countF = (float)count;
        avg = sumF / countF;
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {avg}");
        Console.WriteLine($"The largest number is: {largest}");
        Console.WriteLine($"The smallest positive number is: {smallestP}");
        Console.WriteLine("The sorted list is:");
        numbers.Sort();
        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }

        
    }
}