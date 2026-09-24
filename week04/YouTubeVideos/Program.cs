using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create videos
        Video video1 = new Video("Introduction to C#", "Gideon Dev", 300);
        Video video2 = new Video("Learning Object-Oriented Programming", "Code Academy", 450);
        Video video3 = new Video("How to Build Your First Program", "Programming World", 600);
        Video video4 = new Video("Understanding C# Classes", "Tech Tutorials", 500);

        // Add comments to video 1
        video1.Comments.Add(new Comment("John", "Great introduction!"));
        video1.Comments.Add(new Comment("Mary", "This was very helpful."));
        video1.Comments.Add(new Comment("David", "I learned a lot from this video."));
        video1.Comments.Add(new Comment("Sarah", "Looking forward to the next lesson."));

        // Add comments to video 2
        video2.Comments.Add(new Comment("Michael", "Classes are easier to understand now."));
        video2.Comments.Add(new Comment("James", "Excellent explanation."));
        video2.Comments.Add(new Comment("Linda", "This helped me with my assignment."));
        video2.Comments.Add(new Comment("Paul", "Very useful tutorial."));

        // Add comments to video 3
        video3.Comments.Add(new Comment("Daniel", "I finally understand the basics."));
        video3.Comments.Add(new Comment("Grace", "Very clear explanation."));
        video3.Comments.Add(new Comment("Peter", "Thank you for this lesson."));
        video3.Comments.Add(new Comment("Esther", "This was easy to follow."));

        // Add comments to video 4
        video4.Comments.Add(new Comment("Andrew", "I understand classes better now."));
        video4.Comments.Add(new Comment("Rebecca", "Great video!"));
        video4.Comments.Add(new Comment("Samuel", "Very informative."));
        video4.Comments.Add(new Comment("Rachel", "Please make more tutorials."));

        // Put all videos into a list
        List<Video> videos = new List<Video>
        {
            video1,
            video2,
            video3,
            video4
        };

        // Display each video
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of comments: {video.GetNumberOfComments()}");

            Console.WriteLine("Comments:");

            foreach (Comment comment in video.Comments)
            {
                Console.WriteLine($"{comment.Name}: {comment.Text}");
            }

            Console.WriteLine();
        }
    }
}