using System;
public class Worker : Personnel
{
    public string Specialty {  get; set; }
    public string Workshop { get; set; }

    public Worker(string name, string specialty, string workshop)
        : base(name)
    {
        Specialty = specialty;
        Workshop = workshop;
    }

    public override void PrintInfo()
    {
        Console.WriteLine($"[Рабочий] Имя: {Name}");
        Console.WriteLine($"Специальность: {Specialty}");
        Console.WriteLine($"Цех: {Workshop}");
    }
}

