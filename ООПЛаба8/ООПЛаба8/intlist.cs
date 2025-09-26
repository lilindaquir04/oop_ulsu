// IntListProcessor.cs
using System;
using System.Collections.Generic;
using System.Linq;

public static class IntListProcessor
{
    // е.а. Создать и заполнить
    public static LinkedList<Int> CreateList()
    {
        var list = new LinkedList<Int>();
        foreach (var x in new int[] { 10, 20, 30, 40, 50, 60, 70 })
            list.AddLast(new Int(x));
        return list;
    }

    // е.б. Удалить одни, заменить другие
    public static void ModifyList(LinkedList<Int> list)
    {
        // Удалим Int(20) и Int(60)
        var toRemove20 = list.FirstOrDefault(x => x.GetValue() == 20);
        var toRemove60 = list.FirstOrDefault(x => x.GetValue() == 60);
        if (toRemove20 != null) list.Remove(toRemove20);
        if (toRemove60 != null) list.Remove(toRemove60);

        // Заменим 30 на 35
        var node = list.First;
        while (node != null)
        {
            if (node.Value.GetValue() == 30)
            {
                node.Value = new Int(35);
                break;
            }
            node = node.Next;
        }
    }

    // е.г. Удалить n элементов после заданного ЗНАЧЕНИЯ
    public static void RemoveAfterValue(LinkedList<Int> list, Int value, int n)
    {
        var node = list.First;
        while (node != null && !node.Value.Equals(value))
            node = node.Next;

        if (node == null) return;

        for (int i = 0; i < n && node.Next != null;)
        {
            var toRemove = node.Next;
            list.Remove(toRemove);
            i++;
        }
    }

    // е.д. Сортировка по убыванию
    public static void SortDescending(LinkedList<Int> list)
    {
        var sorted = list.OrderByDescending(x => x.GetValue()).ToList();
        list.Clear();
        foreach (var item in sorted)
            list.AddLast(item);
    }

    public static void PrintList(LinkedList<Int> list, string message)
    {
        Console.WriteLine(message);
        foreach (var item in list)
            Console.Write(item + " ");
        Console.WriteLine("\n");
    }

    // ж. Поиск элемента
    public static Int? FindElement(LinkedList<Int> list, Int element)
    {
        return list.FirstOrDefault(x => x.Equals(element));
    }
}