using System;

public class HR : Personnel
{
    public string Department { get; set; }

    public HR() : base()
    {
        Department = "Отдел кадров";
    }

    public HR(string name, int age, string department) : base(name, age)
    {
        Department = department;
    }

    public override void ShowInfo()
    {
        Console.WriteLine($"[HR #{ObjectNumber}] {Name}, {Age} лет, отдел: {Department}");
    }

    public override void UpdateAge(ref int age)
    {
        base.UpdateAge(ref age);
        Console.WriteLine($"Возраст сотрудника HR обновлен на {age}");
    }
}
