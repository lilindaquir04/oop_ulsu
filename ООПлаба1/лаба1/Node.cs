using System;

public class Node
{
    public object Data;
    public Node Prev;
    public Node Next;

    public Node(object data)
    {
        Data = data;
        Prev = null;
        Next = null;
        Console.WriteLine("Вызван конструктор узла");
    }

    ~Node()
    {
        Console.WriteLine("Вызван деструктор узла");
    }
}

