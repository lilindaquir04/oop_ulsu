using System;
public class Worker : Employee
{
    public string Specialty {  get; set; }
    public string Workshop { get; set; }

    public Worker(string name, string specialty, string workshop)
        : base(name)
    {
        Specialty = specialty;
        Workshop = workshop;
        Console.WriteLine($"[Worker] Рабочий: {Name}, Специальность: {Specialty}, Цех: {Workshop}");
    }

    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine($"Специальность: {Specialty}, Цех: {Workshop}");
    }
}

