using System.Collections.Generic;

public static class Utils
{
    public static void RemoveEverySecond<T>(CSet<T> set)
    {
        var list = set.ToList();
        List<T> result = new List<T>();

        for (int i = 0; i < list.Count; i++)
        {
            if (i % 2 == 0)
                result.Add(list[i]);
        }

        set.SetFromList(result);
    }
}
