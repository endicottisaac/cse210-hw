using System;
using System.ComponentModel;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        do
        {
            Console.Write("Add a number to the list (typing '0' will stop the program): ");
            int userInput = int.Parse(Console.ReadLine());
            if (userInput != 0)
            {
                numbers.Add(userInput);
            }
            else
            {
                break;
            }
        } while (true);
        
        int numberListSum = 0; 
        int largestNumber = numbers[0];
        int smallestPositive = 999999999;
        foreach (int number in numbers)
        {
            numberListSum += number;
            if (number > largestNumber)
            {
                largestNumber = number;
            }

            if (number > 0 && number < smallestPositive)
            {
                smallestPositive = number;
            }
        }

        //use the double data type to be able to have decimals allowing for a more precise average
        double numberListAverage = (double)numberListSum / numbers.Count;
        
        Console.WriteLine($"The sum is: {numberListSum}");
        Console.WriteLine($"The average is: {numberListAverage:F3}");
        Console.WriteLine($"The largest number is: {largestNumber}");
        Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        //sort the list then print it one by one
        numbers.Sort();
        Console.WriteLine("The sorted list is: ");
        foreach (int number in numbers)
        {            Console.WriteLine(number);
        }       
    }
}