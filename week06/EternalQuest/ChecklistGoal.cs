namespace EternalQuest;

public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _completedCount;
    private int _bonus;

    public ChecklistGoal(
        string name,
        string description,
        int points,
        int targetCount,
        int bonus,
        int completedCount = 0)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _bonus = bonus;
        _completedCount = completedCount;
    }

    public override void RecordEvent()
    {
        if (_completedCount < _targetCount)
        {
            _completedCount++;
        }
    }

    public override bool IsComplete()
    {
        return _completedCount >= _targetCount;
    }

    public override string GetDetailsString()
    {
        string status = IsComplete() ? "[X]" : "[ ]";

        return $"{status} {Name} ({Description}) " +
               $"Completed {_completedCount}/{_targetCount} times";
    }

    public int GetBonusIfCompleted()
    {
        return _completedCount == _targetCount ? _bonus : 0;
    }

    public override string GetStringRepresentation()
    {
        return $"Checklist~|~{Name}~|~{Description}~|~{Points}" +
               $"~|~{_targetCount}~|~{_bonus}~|~{_completedCount}";
    }
}