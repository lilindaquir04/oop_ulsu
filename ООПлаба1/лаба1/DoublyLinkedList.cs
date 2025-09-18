using System;

public class DoublyLinkedList
{
    private Node head;
    private Node tail;

    public DoublyLinkedList()
    {
        head = tail = null;
        Console.WriteLine("Создание двухсвязного списка");
    }

    public DoublyLinkedList(object initialData)
    {
        Node node = new Node(initialData);
        head = tail = node;
        Console.WriteLine("Создание двухсвязного списка с параметром");
    }

    public DoublyLinkedList(DoublyLinkedList other)
    {
        head = tail = null;
        Console.WriteLine("Копирование двухсвязного списка");
        Node current = other.head;
        while (current != null)
        {
            Add(current.Data);
            current = current.Next;
        }
    }

    ~DoublyLinkedList()
    {
        Console.WriteLine("Удаление двухсвязного списка");
    }

    public void Add(object data)
    {
        Node node = new Node(data);
        if (head == null)
        {
            head = tail = node;
        }
        else
        {
            node.Prev = tail;
            tail.Next = node;
            tail = node;
        }
    }

    public bool Remove(object target)
    {
        Node current = head;
        while (current != null)
        {
            if (Equals(current.Data, target))
            {
                if (current.Prev != null)
                    current.Prev.Next = current.Next;
                else
                    head = current.Next;

                if (current.Next != null)
                    current.Next.Prev = current.Prev;
                else
                    tail = current.Prev;

                Console.WriteLine($"Removed: {target}");
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    public bool Find(object target)
    {
        Node current = head;
        while (current != null)
        {
            if (Equals(current.Data, target))
                return true;
            current = current.Next;
        }
        return false;
    }

    public void PrintForward()
    {
        Node current = head;
        while (current != null)
        {
            Console.Write(current.Data + " ");
            current = current.Next;
        }
        Console.WriteLine();
    }

    public void PrintBackward()
    {
        Node current = tail;
        while (current != null)
        {
            Console.Write(current.Data + " ");
            current = current.Prev;
        }
        Console.WriteLine();
    }
}
