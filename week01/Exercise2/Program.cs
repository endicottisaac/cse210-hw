using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        int gradePercentage = int.Parse(Console.ReadLine());
        int lastDigit = gradePercentage % 10;
        string letterGrade;

        //find overall letter grade
        if (gradePercentage >= 90)
        {
            letterGrade = "A";
        }
        else if (gradePercentage >= 80)
        {
            letterGrade = "B";
        }
        else if (gradePercentage >= 70)
        {
            letterGrade = "C";
        }
        else if (gradePercentage >= 60)
        {
            letterGrade = "D";
        }
        else
        {
            letterGrade = "F";
        }


        //find the plus or minus
        if (lastDigit >= 7 && letterGrade != "A" && letterGrade != "F")
        {
            letterGrade += "+";
        }
        else if (lastDigit <= 3 && letterGrade != "F")
        {
            letterGrade += "-";
        }


        Console.WriteLine($"Your letter grade is {letterGrade}.");

        if (gradePercentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed the class.");
        }
        else
        {
            Console.WriteLine("Sorry, you did not pass the class, with hard work and dedication you can do better next time.");
        }
    }
}