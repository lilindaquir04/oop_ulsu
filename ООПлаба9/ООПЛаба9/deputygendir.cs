using System;

public sealed class DeputyGeneralDirector : Personnel
{
    public string AreaOfResponsibility { get; set; }

    public DeputyGeneralDirector() : base()
    {
        AreaOfResponsibility = "Область ответственности";
    }

    public DeputyGeneralDirector(string name, int age, string area) : base(name, age)
    {
        AreaOfResponsibility = area;
    }

    public override void ShowInfo()
    {
        Console.WriteLine($"[DeputyGeneralDirector #{ObjectNumber}] {Name}, {Age} лет, зона ответственности: {AreaOfResponsibility}");
    }

    // Здесь override UpdateAge, если нужно
    public override void UpdateAge(ref int age)
    {
        base.UpdateAge(ref age);
        Console.WriteLine($"Возраст зам. ген. директора обновлен на {age}");
    }
}
