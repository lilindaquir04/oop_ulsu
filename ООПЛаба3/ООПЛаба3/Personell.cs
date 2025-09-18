using System;

public abstract class Personnel
{
    public string Name { get; set; }


    public Personnel Next;
    private static Personnel head = null; 

    // Конструктор
    public Personnel(string name)
    {
        Name = name;
        AddToList();
    }

    // Абстрактный метод (чисто виртуальный)
    public abstract void PrintInfo();


    private void AddToList()
    {
        this.Next = head;
        head = this;
    }

    // Статический метод просмотра списка
    public static void ViewList()
    {
        Console.WriteLine("=== Список всех сотрудников ===");
        Personnel current = head;
        while (current != null)
        {
            current.PrintInfo();
            Console.WriteLine("-------------------");
            current = current.Next;
        }
    }
}
