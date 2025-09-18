using System;
using System.Collections.Generic;
using System.Linq;

public static class LongListProcessor
{
    public static List<long> CreateList()
    {
        return new List<long> { 10, 20, 30, 40, 50, 60, 70 };
    }

    public static void ModifyList(List<long> list)
    {
        list.RemoveAll(x => x % 20 == 0); // удалить кратные 20
        for (int i = 0; i < list.Count; i++)
            if (list[i] == 30)
                list[i] = 35; // заменить 30 на 35
    }

    public static void RemoveAfterIndex(List<long> list, int index, int n)
    {
        if (index + n < list.Count)
            list.RemoveRange(index + 1, n);
    }

    public static void SortDescending(List<long> list)
    {
        list.Sort((a, b) => b.CompareTo(a));
    }

    public static void PrintList(List<long> list, string message)
    {
        Console.WriteLine(message);
        foreach (var item in list)
            Console.Write(item + " ");
        Console.WriteLine("\n");
    }
}
