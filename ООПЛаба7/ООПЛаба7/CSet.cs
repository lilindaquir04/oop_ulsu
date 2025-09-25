using System;
using System.Collections.Generic;
using System.IO;

public class CSet<T>
{
    private HashSet<T> elements = new HashSet<T>();

    public void Add(T item)
    {
        elements.Add(item);
    }

    public List<T> ToList()
    {
        return new List<T>(elements);
    }

    public void SetFromList(List<T> list)
    {
        elements = new HashSet<T>(list);
    }

    public void Print()
    {
        Console.Write("{");
        Console.Write(string.Join(", ", elements));
        Console.WriteLine("}");
    }

    public void SaveToWriter(StreamWriter writer)
    {
        writer.Write("{");
        writer.Write(string.Join(", ", elements));
        writer.WriteLine("}");
    }
}