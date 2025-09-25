using System;
using System.Collections.Generic;
using System.Linq;

public static class LongListProcessor
{
    public static LinkedList<long> CreateList()
    {
        var list = new LinkedList<long>();
        foreach (var x in new long[] { 10, 20, 30, 40, 50, 60, 70 })
            list.AddLast(x);
        return list;
    }

    public static void ModifyList(LinkedList<long> list)
    {
        // Удалить все элементы, кратные 20
        var node = list.First;
        while (node != null)
        {
            var next = node.Next;
            if (node.Value % 20 == 0)
                list.Remove(node);
            node = next;
        }

        // Заменить 30 на 35
        node = list.First;
        while (node != null)
        {
            if (node.Value == 30)
                node.Value = 35;
            node = node.Next;
        }
    }

    public static void RemoveAfterIndex(LinkedList<long> list, int index, int n)
    {
        var node = list.First;
        for (int i = 0; i < index && node != null; i++)
            node = node.Next;

        if (node == null) return;

        for (int i = 0; i < n && node.Next != null;)
        {
            var toRemove = node.Next;
            list.Remove(toRemove);
            // node не меняется, так как удаляется следующий
            i++;
        }
    }

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