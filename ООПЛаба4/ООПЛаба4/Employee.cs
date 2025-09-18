using System;

public class Employee
{
    public string Name { get; set; }

    public Employee(string name)
    {
        Name = name;
        Console.WriteLine($"[Employee] Создан сотрудник: {Name}");
    }

    public virtual void PrintInfo()
    {
        Console.WriteLine($"Имя: {Name}");
    }
}