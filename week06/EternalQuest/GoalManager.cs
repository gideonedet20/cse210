using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public int Score => _score;

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void DisplayGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You have no goals yet.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void RecordGoalEvent()
    {
        DisplayGoals();

        if (_goals.Count == 0)
            return;

        Console.Write("Enter the goal number to record: ");

        if (!int.TryParse(Console.ReadLine(), out int number) ||
            number < 1 || number > _goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            return;
        }

        Goal goal = _goals[number - 1];

        if (goal is SimpleGoal && goal.IsComplete())
        {
            Console.WriteLine("This goal is already complete.");
            return;
        }

        if (goal is ChecklistGoal && goal.IsComplete())
        {
            Console.WriteLine("This checklist goal is already complete.");
            return;
        }

        goal.RecordEvent();
        _score += goal.Points;

        if (goal is ChecklistGoal checklist && checklist.IsComplete())
        {
            int bonus = checklist.GetBonusIfCompleted();
            _score += bonus;
            Console.WriteLine($"Congratulations! You earned a {bonus}-point bonus!");
        }

        Console.WriteLine($"You earned {goal.Points} points!");
        Console.WriteLine($"Your total score is {_score}.");
    }

    public void CreateGoal()
    {
        Console.WriteLine("\nChoose a goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        Console.Write("Choice: ");
        string choice = Console.ReadLine() ?? "";

        Console.Write("Goal name: ");
        string name = Console.ReadLine() ?? "";

        Console.Write("Goal description: ");
        string description = Console.ReadLine() ?? "";

        int points = ReadInt("Points for each event: ", 0);

        Goal goal;

        switch (choice)
        {
            case "1":
                goal = new SimpleGoal(name, description, points);
                break;

            case "2":
                goal = new EternalGoal(name, description, points);
                break;

            case "3":
                int target = ReadInt("How many times to complete it? ", 1);
                int bonus = ReadInt("Bonus points on completion: ", 0);

                goal = new ChecklistGoal(
                    name, description, points, target, bonus);
                break;

            default:
                Console.WriteLine("Invalid goal type.");
                return;
        }

        AddGoal(goal);
        Console.WriteLine("Goal created successfully!");
    }

    private int ReadInt(string prompt, int minimum)
    {
        while (true)
        {
            Console.Write(prompt);

            if (int.TryParse(Console.ReadLine(), out int value) &&
                value >= minimum)
            {
                return value;
            }

            Console.WriteLine($"Please enter a number of at least {minimum}.");
        }
    }

    public void SaveGoals(string filename)
    {
        using StreamWriter writer = new StreamWriter(filename);

        writer.WriteLine(_score);

        foreach (Goal goal in _goals)
        {
            writer.WriteLine(goal.GetStringRepresentation());
        }

        Console.WriteLine("Goals and score saved successfully!");
    }

    public void LoadGoals(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("Save file not found.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);

        if (lines.Length == 0 ||
            !int.TryParse(lines[0], out int savedScore))
        {
            Console.WriteLine("The save file is invalid.");
            return;
        }

        List<Goal> loadedGoals = new List<Goal>();

        try
        {
            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split("~|~");

                switch (parts[0])
                {
                    case "Simple":
                        loadedGoals.Add(new SimpleGoal(
                            parts[1],
                            parts[2],
                            int.Parse(parts[3]),
                            bool.Parse(parts[4])));
                        break;

                    case "Eternal":
                        loadedGoals.Add(new EternalGoal(
                            parts[1],
                            parts[2],
                            int.Parse(parts[3])));
                        break;

                    case "Checklist":
                        loadedGoals.Add(new ChecklistGoal(
                            parts[1],
                            parts[2],
                            int.Parse(parts[3]),
                            int.Parse(parts[4]),
                            int.Parse(parts[5]),
                            int.Parse(parts[6])));
                        break;

                    default:
                        throw new FormatException("Unknown goal type.");
                }
            }
        }
        catch (Exception ex) when (
            ex is FormatException ||
            ex is IndexOutOfRangeException ||
            ex is OverflowException)
        {
            Console.WriteLine("The save file contains invalid goal data.");
            return;
        }

        _goals = loadedGoals;
        _score = savedScore;

        Console.WriteLine("Goals and score loaded successfully!");
    }
}