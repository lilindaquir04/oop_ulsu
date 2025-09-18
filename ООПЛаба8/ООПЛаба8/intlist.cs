using System;
using System.Collections.Generic;
using System.Linq;

public static class IntListProcessor
{
    public static List<Int> CreateList()
    {
        return new List<Int>
        {
            new Int(10),
            new Int(20),
            new Int(30),
            new Int(40),
            new Int(50),
            new Int(60),
            new Int(70)
        };
    }

    public static void ModifyList(List<Int> list)
    {
        list.RemoveAll(x => x.GetValue() % 20 == 0); // удалить кратные 20
        for (int i = 0; i < list.Count; i++)
            if (list[i].GetValue() == 30)
                list[i] = new Int(35); // заменить 30 на 35
    }

    public static void RemoveAfterIndex(List<Int> list, int index, int n)
    {
        if (index + n < list.Count)
            list.RemoveRange(index + 1, n);
    }

    public static void SortDescending(List<Int> list)
    {
        list.Sort((a, b) => b.CompareTo(a));
    }

    public static void PrintList(List<Int> list, string message)
    {
        Console.WriteLine(message);
        foreach (var item in list)
            Console.Write(item + " ");
        Console.WriteLine("\n");
    }

    public static Int? FindElement(List<Int> list, Int element)
    {
        return list.Find(x => x.Equals(element));
    }
}
