public abstract class Personnel
{
    public string Name { get; set; }

    protected static Personnel head = null; // доступен потомкам
    internal Personnel Next; // односвязный список

    public Personnel(string name)
    {
        Name = name;
        AddToList();
    }

    private void AddToList()
    {
        this.Next = head;
        head = this;
    }

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

    public abstract void PrintInfo();
}

