using System;
using System.Collections.Generic;

public static class Utils
{
    public static void RemoveEverySecond<T>(CSet<T> set)
    {
        var list = set.ToList();
        var result = new List<T>();
        for (int i = 0; i < list.Count; i += 2)
        {
            result.Add(list[i]);
        }
        set.SetFromList(result);
    }
}