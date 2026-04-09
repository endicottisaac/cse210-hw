using System;

class Program
{
    static void Main(string[] args)
    {
        // assignment base class
        Homework.Assignment assignment = new Homework.Assignment("Samuel Bennett", "Multiplication");
        Console.WriteLine(assignment.GetSummary());

        // math assignment derived class
        Homework.MathAssignment mathAssignment = new Homework.MathAssignment(
            "Roberto Rodriguez", "Fractions", "7.3", "8-19");
        Console.WriteLine(mathAssignment.GetSummary());
        Console.WriteLine(mathAssignment.GetHomeworkList());

        // writing assignment derived class
        Homework.WritingAssignment writingAssignment = new Homework.WritingAssignment(
            "Mary Waters", "European History", "The Causes of World War II");
        Console.WriteLine(writingAssignment.GetSummary());
        Console.WriteLine(writingAssignment.GetWritingInformation());
    }
}