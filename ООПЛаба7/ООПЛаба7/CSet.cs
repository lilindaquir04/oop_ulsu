using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// Интерфейс для работы с множествами без знания типа T
public interface ICSet
{
    void Print();
    void SaveToFile(string path);
    bool Contains(object item);
    void Add(object item);
    IEnumerable<object> GetElements();
}

public class CSet<T> : ICSet
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

    public void LoadFromFile(string path)
    {
        if (!File.Exists(path))
            throw new FileOpenException($"Файл '{path}' не найден");

        try
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                int lineNumber = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    lineNumber++;
                    line = line.Trim();
                    if (string.IsNullOrEmpty(line))
                        continue;

                    var parts = line.Split(new[] { ';', ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                    int index = 0;
                    foreach (var part in parts)
                    {
                        index++;
                        var trimmed = part.Trim();

                        if (string.IsNullOrEmpty(trimmed))
                            continue;

                        T item;
                        try
                        {
                            item = (T)Convert.ChangeType(trimmed, typeof(T));
                        }
                        catch (Exception ex)
                        {
                            throw new InvalidElementException($"Ошибка формата в элементе {index} строки {lineNumber}: {ex.Message}");
                        }

                        if (elements.Contains(item))
                        {
                            Console.WriteLine($"[{index}] Пропущен дубликат: {item}");
                            continue;
                        }

                        elements.Add(item);
                        Console.WriteLine($"[{index}] Добавлен: {item}");
                    }
                }
            }
        }
        catch (IOException e)
        {
            throw new FileReadException($"Ошибка чтения файла: {e.Message}");
        }
    }

    public void SaveToFile(string path)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                foreach (var elem in elements)
                {
                    writer.WriteLine(elem);
                }
            }
        }
        catch (IOException e)
        {
            throw new FileOpenException($"Ошибка записи в файл: {e.Message}");
        }
    }

    public void Add(T value)
    {
        Console.WriteLine($"Добавляем элемент: {value}");
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

    // Операторы
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
        if (ReferenceEquals(a, b)) return true;
        if (a is null || b is null) return false;
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

    public List<T> ToList()
    {
        return elements.ToList();
    }

    public void SetFromList(List<T> list)
    {
        elements = new HashSet<T>(list);
    }

    // Реализация интерфейсных методов (для работы с object)
    void ICSet.Add(object item)
    {
        if (item is T tItem)
            Add(tItem);
        else
            throw new InvalidElementException($"Неверный тип элемента: ожидается {typeof(T)}, получено {item.GetType()}");
    }

    bool ICSet.Contains(object item)
    {
        if (item is T tItem)
            return elements.Contains(tItem);
        return false;
    }

    void ICSet.Print()
    {
        Print();
    }

    void ICSet.SaveToFile(string path)
    {
        SaveToFile(path);
    }

    IEnumerable<object> ICSet.GetElements()
    {
        foreach (var elem in elements)
            yield return elem!;
    }
}
