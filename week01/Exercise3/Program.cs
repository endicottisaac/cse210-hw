using System;

class Program
{
    static void Main(string[] args)
    {   
        Console.WriteLine("Welcome to the Number Guessing Game!");
        Console.Write("Would you like to play? (yes/no) ");
        string playGame = Console.ReadLine();
        while (playGame == "yes")
        { 
            Random random = new Random();
            int randomNumber = random.Next(1, 101);
            int userGuess = 0;
            int numberOfGuesses = 0;
            Console.WriteLine("Please guess a number between 1 and 100.");
            while (userGuess != randomNumber)
            {
                Console.Write("Enter your guess: ");
                userGuess = int.Parse(Console.ReadLine());
                numberOfGuesses++;

                if (userGuess < randomNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (userGuess > randomNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine($"You guessed it in {numberOfGuesses} guesses!");
                }
            }
            Console.Write("Would you like to play again? (yes/no) ");
            playGame = Console.ReadLine(); 
        }
    }
}