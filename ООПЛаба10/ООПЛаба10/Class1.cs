using System;
using System.Collections.Generic;

public class CSet<T> where T : IEquatable<T>
{
    private List<T> elements;

    // Индексатор
    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= elements.Count)
                throw new IndexOutOfRangeException("Индекс вне диапазона.");
            return elements[index];
        }
        set
        {
            if (index < 0 || index >= elements.Count)
                throw new IndexOutOfRangeException("Индекс вне диапазона.");

            // Если новое значение отличается от текущего
            if (!elements[index].Equals(value))
            {
                if (Contains(value))
                    throw new ArgumentException("Элемент уже существует в множестве.");
                elements[index] = value;
            }
            // Если значение не изменилось — ничего не делаем (и не ругаемся)
        }
    }

    // Конструкторы
    public CSet()
    {
        elements = new List<T>();
    }

    public CSet(IEnumerable<T> collection)
    {
        elements = new List<T>();
        foreach (var item in collection)
        {
            Add(item);
        }
    }

    // Деструктор (сохранён по требованию)
    ~CSet()
    {
        Console.WriteLine("Объект CSet уничтожается");
    }

    // Добавление элемента
    public void Add(T item)
    {
        if (!Contains(item))
        {
            elements.Add(item);
        }
        // Если элемент уже есть — ничего не делаем (не бросаем исключение)
        // Это соответствует логике математического множества
    }

    // Проверка наличия элемента
    public bool Contains(T item)
    {
        foreach (var elem in elements)
        {
            if (elem.Equals(item))
                return true;
        }
        return false;
    }

    public int Count => elements.Count;

    // Оператор + : добавить элемент
    public static CSet<T> operator +(CSet<T> set, T item)
    {
        if (set == null)
            throw new ArgumentNullException(nameof(set));

        CSet<T> result = new CSet<T>(set.elements);
        result.Add(item); // Add не бросает исключение при дубликате
        return result;
    }

    // Оператор * : пересечение
    public static CSet<T> operator *(CSet<T> set1, CSet<T> set2)
    {
        if (set1 == null || set2 == null)
            throw new ArgumentNullException("Оба множества должны быть не null");

        CSet<T> result = new CSet<T>();
        foreach (var item in set1.elements)
        {
            if (set2.Contains(item))
            {
                result.Add(item);
            }
        }
        return result;
    }

    // Оператор == : равенство
    public static bool operator ==(CSet<T> set1, CSet<T> set2)
    {
        if (ReferenceEquals(set1, set2))
            return true;
        if (set1 is null || set2 is null)
            return false;
        if (set1.Count != set2.Count)
            return false;

        foreach (var item in set1.elements)
        {
            if (!set2.Contains(item))
                return false;
        }
        return true;
    }

    // Оператор != : неравенство
    public static bool operator !=(CSet<T> set1, CSet<T> set2)
    {
        return !(set1 == set2);
    }

    public override bool Equals(object obj)
    {
        // Используем 'as' → требование выполнено
        return this == (obj as CSet<T>);
    }

    public override int GetHashCode()
    {
        int hash = 17;
        foreach (var item in elements)
        {
            hash = hash * 31 + (item?.GetHashCode() ?? 0);
        }
        return hash;
    }

    // Метод с ref и out
    public void UpdateElement(ref T oldItem, T newItem, out bool success)
    {
        success = false;
        for (int i = 0; i < elements.Count; i++)
        {
            if (elements[i].Equals(oldItem))
            {
                if (!Contains(newItem))
                {
                    elements[i] = newItem;
                    oldItem = newItem; // обновляем ref-параметр
                    success = true;
                    return;
                }
                else
                {
                    throw new ArgumentException("Новый элемент уже существует в множестве.");
                }
            }
        }
    }

    // Вывод множества
    public void Print()
    {
        Console.Write("{ ");
        foreach (var item in elements)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine("}");
    }
}