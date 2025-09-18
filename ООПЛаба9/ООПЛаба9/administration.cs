using System;

public class Administration : Personnel
{
    public string Position { get; set; }

    public Administration() : base()
    {
        Position = "Администрация";
    }

    public Administration(string name, int age, string position) : base(name, age)
    {
        Position = position;
    }

    public override void ShowInfo()
    {
        Console.WriteLine($"[Administration #{ObjectNumber}] {Name}, {Age} лет, должность: {Position}");
    }

    public override void UpdateAge(ref int age)
    {
        base.UpdateAge(ref age);
        Console.WriteLine($"Возраст администратора обновлен на {age}");
    }
}
