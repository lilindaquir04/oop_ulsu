using System;

public class Administration : Employee
{
    public string Position { get; set; }

    public Administration(string name,string position)
        : base(name)
    {
        Position = position;
        Console.WriteLine($"[Admin] Администрация: {Name}, Должность: {Position}");
    }

    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine($"Должность: {Position}");
    }
}