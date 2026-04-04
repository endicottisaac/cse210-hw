using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("10 Tips for Better Code", "TechGuru123", 720);
        video1.AddComment(new Comment("xXCodeMasterXx", "Great tips! Really helpful for beginners."));
        video1.AddComment(new Comment("NoobMaster69", "I've been coding for years and still learned something new."));
        video1.AddComment(new Comment("MinecraftLover25", "Could you make a follow-up video on design patterns?"));
        videos.Add(video1);

        Video video2 = new Video("Product Review: New Laptop 2024", "GadgetReviewer", 540);
        video2.AddComment(new Comment("EpicGamer2024", "Thanks for the honest review!"));
        video2.AddComment(new Comment("DragonSlayer99", "I just ordered one based on your recommendation."));
        video2.AddComment(new Comment("TechNinja420", "How does it compare to last year's model?"));
        video2.AddComment(new Comment("GamerGirl101", "The battery life seems amazing!"));
        videos.Add(video2);

        Video video3 = new Video("Easy Weeknight Dinner Recipes", "CookingWithSarah", 900);
        video3.AddComment(new Comment("ChefBoss777", "Made the pasta dish tonight - delicious!"));
        video3.AddComment(new Comment("StarWarrior88", "Love your channel, keep up the great work!"));
        video3.AddComment(new Comment("VeggieKing22", "Can you do a vegetarian version of this?"));
        videos.Add(video3);

        Video video4 = new Video("Morning Yoga Routine - 15 Minutes", "YogaFlow", 900);
        video4.AddComment(new Comment("YogaMaster3000", "Perfect way to start my day!"));
        video4.AddComment(new Comment("ZenWarrior55", "Your voice is so calming and relaxing."));
        video4.AddComment(new Comment("FitQueen99", "I do this every morning now. Game changer!"));
        video4.AddComment(new Comment("SleepyGamer17", "Could you make a nighttime routine too?"));
        videos.Add(video4);

        foreach (Video video in videos)
        {
            video.DisplayInfo();
        }
    }
}