using System;

public class Engineer : Personnel
{
    public int ExperienceYears { get; set; }

    public Engineer() : base()
    {
        ExperienceYears = 0;
    }

    public Engineer(string name, int age, int experience) : base(name, age)
    {
        ExperienceYears = experience;
    }

    public override void ShowInfo()
    {
        Console.WriteLine($"[Engineer #{ObjectNumber}] {Name}, {Age} лет, стаж: {ExperienceYears} лет");
    }

    public override void UpdateAge(ref int age)
    {
        base.UpdateAge(ref age);
        Console.WriteLine($"Возраст инженера обновлен на {age}");
    }
}
