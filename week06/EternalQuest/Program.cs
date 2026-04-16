using System;

class Program
{
    static void Main(string[] args)
    {
        // Creativity Portion:
        // added a simple level system based on the player's score
        // the current level is shown with the player's score in the menu
        // also added encouraging achievement messages when the player reaches a new level

        GoalManager goalManager = new GoalManager();
        goalManager.Start();
    }
}
