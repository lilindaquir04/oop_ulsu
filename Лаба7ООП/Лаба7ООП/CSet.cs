// CSet.cs
using System;
using System.Collections.Generic;
using System.Linq;

public class CSet<T>
{
    private HashSet<T> elements;
    private const int MaxSize = 10_000; // защита от огромных данных

    public CSet()
    {
        elements = new HashSet<T>();
    }

    public CSet(IEnumerable<T> values)
    {
        if (values == null)
            throw new ArgumentNullException(nameof(values));

        var list = values.ToList();

        // 🔥 Исключение №2: слишком много элементов
        if (list.Count > MaxSize)
            throw new MemoryAllocationException(
                $"Cannot create set with more than {MaxSize} elements.");

        elements = new HashSet<T>(list);
    }

    public CSet(CSet<T> other)
    {
        elements = new HashSet<T>(other.elements);
    }

    public void Add(T value) => elements.Add(value);

    public List<T> ToList() => elements.ToList();

    public void SetFromList(List<T> list)
    {
        elements = new HashSet<T>(list);
    }

    // Вывод в любой TextWriter (консоль или файл)
    public void PrintTo(System.IO.TextWriter writer)
    {
        writer.WriteLine("{" + string.Join(", ", elements) + "}");
    }

    public void Print() => PrintTo(Console.Out);

    // Операторы и прочее — без изменений
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

    public static explicit operator int(CSet<T> set) => set.elements.Count;

    public override bool Equals(object obj) => obj is CSet<T> other && this == other;
    public override int GetHashCode() => elements.GetHashCode();
}