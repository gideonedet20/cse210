namespace EternalQuest;

public class EternalGoal : Goal
{
    public EternalGoal(
        string name,
        string description,
        int points)
        : base(name, description, points)
    {
    }

    public override void RecordEvent()
    {
        // Eternal goals can be recorded repeatedly.
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetStringRepresentation()
    {
        return $"Eternal~|~{Name}~|~{Description}~|~{Points}";
    }
}