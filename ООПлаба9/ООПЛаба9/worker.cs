using System;

public class Worker : Personnel
{
    public string Profession { get; set; }

    public Worker() : base()
    {
        Profession = "Рабочий";
    }

    public Worker(string name, int age, string profession) : base(name, age)
    {
        Profession = profession;
    }

    public override void ShowInfo()
    {
        Console.WriteLine($"[Worker #{ObjectNumber}] {Name}, {Age} лет, профессия: {Profession}");
    }

    public override void UpdateAge(ref int age)
    {
        base.UpdateAge(ref age);
        Console.WriteLine($"Возраст рабочего обновлен на {age}");
    }
}
