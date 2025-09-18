using System;
using System.Collections.Generic;
using System.Linq;

public class CSet
{
    private HashSet<int> elements;

    public CSet()
    {
        elements = new HashSet<int>();
        Console.WriteLine("Конструктор по умолчанию вызван");
    }

    public CSet(IEnumerable<int> values)
    {
        elements = new HashSet<int>(values);
        Console.WriteLine("Конструктор с параметрами вызван");
    }

    public CSet(CSet other)
    {
        elements = new HashSet<int>(other.elements);
        Console.WriteLine("Конструктор копирования вызван");
    }

    ~CSet()
    {
        Console.WriteLine("Деструктор вызван");
    }

    public bool Contains(int value)
    {
        return elements.Contains(value);
    }

    public void Print()
    {
        Console.WriteLine("{" + string.Join(", ", elements) + "}");
    }

    public int Size()
    {
        return elements.Count;
    }

    public void Add(int value)
    {
        elements.Add(value);
    }


    public static CSet operator +(CSet set, int value)
    {
        var newSet = new CSet(set);
        newSet.Add(value);
        return newSet;
    }

    public static CSet operator +(CSet a, CSet b)
    {
        return new CSet(a.elements.Union(b.elements));
    }

    public static CSet operator *(CSet a, CSet b)
    {
        return new CSet(a.elements.Intersect(b.elements));
    }
    public static bool operator ==(CSet a, CSet b)
    {
        return a.elements.SetEquals(b.elements);
    }

    public static bool operator !=(CSet a, CSet b)
    {
        return !(a == b);
    }

    public static explicit operator int(CSet set)
    {
        return set.Size();
    }

    public override bool Equals(object obj)
    {
        return obj is CSet other && this == other;
    }

    public override int GetHashCode()
    {
        return elements.GetHashCode();
    }
}