using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // === а–д: работа с long (встроенный тип) ===
        var longList = LongListProcessor.CreateList();
        LongListProcessor.PrintList(longList, "а. Начальный список long:");

        LongListProcessor.ModifyList(longList);
        LongListProcessor.PrintList(longList, "б. После удаления кратных 20 и замены 30 на 35:");

        Console.WriteLine("в. Просмотр с итераторами long:");
        foreach (var item in longList)
            Console.Write(item + " ");
        Console.WriteLine("\n");

        LongListProcessor.RemoveAfterIndex(longList, 2, 2);
        LongListProcessor.PrintList(longList, "г. После удаления 2 элементов после индекса 2:");

        LongListProcessor.SortDescending(longList);
        LongListProcessor.PrintList(longList, "д. Отсортированный список long по убыванию:");

        // === е–ж: работа с Int (пользовательский тип) ===
        var intList = IntListProcessor.CreateList();
        IntListProcessor.PrintList(intList, "е. Начальный список Int:");

        IntListProcessor.ModifyList(intList);
        IntListProcessor.PrintList(intList, "   После удаления кратных 20 и замены 30 на 35:");

        Console.WriteLine("   Просмотр с итераторами Int:");
        foreach (var item in intList)
            Console.Write(item + " ");
        Console.WriteLine("\n");

        IntListProcessor.RemoveAfterIndex(intList, 2, 2);
        IntListProcessor.PrintList(intList, "   После удаления 2 элементов после индекса 2:");

        IntListProcessor.SortDescending(intList);
        IntListProcessor.PrintList(intList, "   Отсортированный список Int по убыванию:");

        // ж. Поиск элемента
        var searchElement = new Int(35);
        var found = IntListProcessor.FindElement(intList, searchElement);
        if (found != null)
            Console.WriteLine($"ж. Найден элемент: {found}");
        else
            Console.WriteLine("ж. Элемент не найден");

        // з. Подсчёт элементов > 30
        int countLong = longList.Count(x => x > 30);
        Console.WriteLine($"з. Количество элементов > 30 в longList: {countLong}");

        int countInt = intList.Count(x => x.GetValue() > 30);
        Console.WriteLine($"   Количество элементов с value > 30 в intList: {countInt}");
    }
}