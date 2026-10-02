using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base(
            "Breathing Activity",
            "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        int elapsedTime = 0;

        while (elapsedTime < GetDuration())
        {
            Console.Write("Breathe in...   ");
            ShowCountdown(4);
            Console.WriteLine();

            elapsedTime += 4;

            if (elapsedTime >= GetDuration())
            {
                break;
            }

            Console.Write("Breathe out...  ");
            ShowCountdown(4);
            Console.WriteLine();

            elapsedTime += 4;
        }

        DisplayEndingMessage();
    }
}