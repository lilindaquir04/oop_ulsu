using System;
using System.Collections.Generic;

public class Worker : Personnel
{
    public string Specialty { get; set; }
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

    // ИТЕРАТОР: имена рабочих из заданного цеха
    public static IEnumerable<string> GetWorkersFromWorkshop(string targetWorkshop)
    {
        Personnel current = head;
        while (current != null)
        {
            if (current is Worker worker && worker.Workshop == targetWorkshop)
            {
                yield return worker.Name;
            }
            current = current.Next;
        }
    }
}


