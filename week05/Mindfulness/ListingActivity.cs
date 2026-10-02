using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : Activity
{
    private List<string> _prompts;
    private Random _random;

    public ListingActivity()
        : base(
            "Listing Activity",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _random = new Random();

        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
    }

    public void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine();
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine();

        string prompt = _prompts[_random.Next(_prompts.Count)];

        Console.WriteLine($"--- {prompt} ---");

        Console.WriteLine();
        Console.WriteLine("You may begin in:");
        ShowCountdown(5);

        Console.WriteLine();
        Console.WriteLine();

        List<string> answers = new List<string>();

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string answer = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(answer))
            {
                answers.Add(answer);
            }

            if (DateTime.Now >= endTime)
            {
                break;
            }
        }

        Console.WriteLine();
        Console.WriteLine($"You listed {answers.Count} items!");

        ShowSpinner(3);

        DisplayEndingMessage();
    }
}