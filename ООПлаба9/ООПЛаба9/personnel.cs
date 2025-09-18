using System;

public abstract class Personnel
{
    private static int countObjects = 0;
    private static int lastObjectNumber = 0;

    public int ObjectNumber { get; private set; }

    public string Name { get; set; }
    public int Age { get; set; }

    static Personnel()
    {
        Console.WriteLine("Статический конструктор Personnel вызван");
    }

    public Personnel()
    {
        ObjectNumber = ++lastObjectNumber;
        countObjects++;
        Name = "Неизвестно";
        Age = 0;
    }

    public Personnel(string name, int age)
    {
        ObjectNumber = ++lastObjectNumber;
        countObjects++;
        Name = name;
        Age = age;
    }

    public static int GetCountObjects()
    {
        return countObjects;
    }

    public abstract void ShowInfo();

    public virtual void UpdateAge(ref int age)
    {
        if (age < 0 || age > 150)
            throw new ArgumentOutOfRangeException(nameof(age), "Возраст должен быть от 0 до 150");
        Age = age;
    }

    public virtual void GetName(out string name)
    {
        name = Name;
    }
}
