using System;

public class Engineer : Employee
{
    public string Qualification {  get; set; }
    public string Department { get; set; }

    public Engineer(string name, string qualification, string department)
        : base(name)
    {
     Qualification = qualification;
     Department = department;
     Console.WriteLine($"[Engineer] Инженер: {Name}, Квалификация: {Qualification}, Подразделение: {Department}");
    }

    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine($"Квалификация: {Qualification}, Подразделение: {Department}");
    }
}
