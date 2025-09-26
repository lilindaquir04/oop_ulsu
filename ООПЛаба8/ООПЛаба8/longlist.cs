// LongListProcessor.cs
using System;
using System.Collections.Generic;
using System.Linq;

public static class LongListProcessor
{
    // а. Создать и заполнить
    public static LinkedList<long> CreateList()
    {
        return new LinkedList<long>(new long[] { 10, 20, 30, 40, 50, 60, 70 });
    }

    // б. Удалить одни элементы, заменить другие
    public static void ModifyList(LinkedList<long> list)
    {
        // Удалим 20 и 60
        list.Remove(20);
        list.Remove(60);

        // Заменим 30 на 35
        var node = list.First;
        while (node != null)
        {
            if (node.Value == 30)
            {
                node.Value = 35;
                break;
            }
            node = node.Next;
        }
    }

    // в. Просмотр через итерации — делается в Program.cs через foreach

    // г. Удалить n элементов после заданного ЗНАЧЕНИЯ (не индекса!)
    public static void RemoveAfterValue(LinkedList<long> list, long value, int n)
    {
        var node = list.Find(value);
        if (node == null) return;

        for (int i = 0; i < n && node.Next != null;)
        {
            var toRemove = node.Next;
            list.Remove(toRemove);
            i++;
        }
    }

    // д. Сортировка по убыванию
    public static void SortDescending(LinkedList<long> list)
    {
        var sorted = list.OrderByDescending(x => x).ToList();
        list.Clear();
        foreach (var item in sorted)
            list.AddLast(item);
    }

    public static void PrintList(LinkedList<long> list, string message)
    {
        Console.WriteLine(message);
        foreach (var item in list)
            Console.Write(item + " ");
        Console.WriteLine("\n");
    }
}