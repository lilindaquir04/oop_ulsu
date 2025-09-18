using System;

public class Engineer : Personnel
{
    public string Qualification { get; set; }
    public string Department { get; set; }

    public Engineer(string name, string qualification, string department)
        : base(name)
    {
        Qualification = qualification;
        Department = department;
    }

    public override void PrintInfo()
    {
        Console.WriteLine($"[Инженер] Имя: {Name}");
        Console.WriteLine($"Квалификация: {Qualification}");
        Console.WriteLine($"Подразделение: {Department}");
    }

    // МЕТОД: подсчёт инженеров из заданного подразделения
    public static int CountEngineersInDepartment(string targetDepartment)
    {
        int count = 0;
        Personnel current = head;
        while (current != null)
        {
            if (current is Engineer eng && eng.Department == targetDepartment)
                count++;
            current = current.Next;
        }
        return count;
    }
}

