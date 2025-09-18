using System;
using System.Collections.Generic;
using System.Linq;

public class CSet<T>
{
    private HashSet<T> elements;

    public CSet()
    {
        elements = new HashSet<T>();
        Console.WriteLine("Конструктор по умолчанию вызван");
    }

    public CSet(IEnumerable<T> values)
    {
        elements = new HashSet<T>(values);
        Console.WriteLine("Конструктор с параметрами вызван");
    }

    public CSet(CSet<T> other)
    {
        elements = new HashSet<T>(other.elements);
        Console.WriteLine("Конструктор копирования вызван");
    }

    ~CSet()
    {
        Console.WriteLine("Деструктор вызван");
    }

    public void Add(T value)
    {
        elements.Add(value);
    }

    public void Print()
    {
        Console.WriteLine("{" + string.Join(", ", elements) + "}");
    }

    public int Size()
    {
        return elements.Count;
    }

    public static CSet<T> operator +(CSet<T> set, T value)
    {
        var newSet = new CSet<T>(set);
        newSet.Add(value);
        return newSet;
    }

    public static CSet<T> operator +(CSet<T> a, CSet<T> b)
    {
        return new CSet<T>(a.elements.Union(b.elements));
    }

    public static CSet<T> operator *(CSet<T> a, CSet<T> b)
    {
        return new CSet<T>(a.elements.Intersect(b.elements));
    }

    public static bool operator ==(CSet<T> a, CSet<T> b)
    {
        return a.elements.SetEquals(b.elements);
    }

    public static bool operator !=(CSet<T> a, CSet<T> b)
    {
        return !(a == b);
    }

    public static explicit operator int(CSet<T> set)
    {
        return set.Size();
    }

    public override bool Equals(object obj)
    {
        return obj is CSet<T> other && this == other;
    }

    public override int GetHashCode()
    {
        return elements.GetHashCode();
    }

    public List<T> ToList() => elements.ToList();

    public void SetFromList(List<T> list)
    {
        elements = new HashSet<T>(list);
    }
}
