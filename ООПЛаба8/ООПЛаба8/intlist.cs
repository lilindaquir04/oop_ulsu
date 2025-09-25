using System;
using System.Collections.Generic;
using System.Linq;

public static class IntListProcessor
{
    public static LinkedList<Int> CreateList()
    {
        var list = new LinkedList<Int>();
        foreach (var x in new int[] { 10, 20, 30, 40, 50, 60, 70 })
            list.AddLast(new Int(x));
        return list;
    }

    public static void ModifyList(LinkedList<Int> list)
    {
        // Удалить кратные 20
        var node = list.First;
        while (node != null)
        {
            var next = node.Next;
            if (node.Value.GetValue() % 20 == 0)
                list.Remove(node);
            node = next;
        }

        // Заменить 30 на 35
        node = list.First;
        while (node != null)
        {
            if (node.Value.GetValue() == 30)
                node.Value = new Int(35);
            node = node.Next;
        }
    }

    public static void RemoveAfterIndex(LinkedList<Int> list, int index, int n)
    {
        var node = list.First;
        for (int i = 0; i < index && node != null; i++)
            node = node.Next;

        if (node == null) return;

        for (int i = 0; i < n && node.Next != null;)
        {
            var toRemove = node.Next;
            list.Remove(toRemove);
            i++;
        }
    }

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

    public static Int? FindElement(LinkedList<Int> list, Int element)
    {
        return list.FirstOrDefault(x => x.Equals(element));
    }
}