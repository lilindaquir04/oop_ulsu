using System;

public class Administration : Personnel
{
    public string Position { get; set; }

    public Administration(string name,string position)
        : base(name)
    {
        Position = position;
      
    }

    public override void PrintInfo()
    {
        Console.WriteLine($"[Администрация] Имя: {Name}");
        Console.WriteLine($"Должность: {Position}");
    }
}