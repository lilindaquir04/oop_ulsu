using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Работа с long
        var longList = LongListProcessor.CreateList();
        LongListProcessor.PrintList(longList, "Начальный список long:");

        LongListProcessor.ModifyList(longList);
        LongListProcessor.PrintList(longList, "После удаления кратных 20 и замены 30 на 35:");

        Console.WriteLine("Просмотр с итераторами long:");
        foreach (var item in longList)
            Console.Write(item + " ");
        Console.WriteLine();

        LongListProcessor.RemoveAfterIndex(longList, 2, 2);
        LongListProcessor.PrintList(longList, "После удаления 2 элементов после индекса 2:");

        LongListProcessor.SortDescending(longList);
        LongListProcessor.PrintList(longList, "Отсортированный список long по убыванию:");

        // Работа с Int
        var intList = IntListProcessor.CreateList();
        IntListProcessor.PrintList(intList, "Начальный список Int:");

        IntListProcessor.ModifyList(intList);
        IntListProcessor.PrintList(intList, "После удаления кратных 20 и замены 30 на 35:");

        Console.WriteLine("Просмотр с итераторами Int:");
        foreach (var item in intList)
            Console.Write(item + " ");
        Console.WriteLine();

        IntListProcessor.RemoveAfterIndex(intList, 2, 2);
        IntListProcessor.PrintList(intList, "После удаления 2 элементов после индекса 2:");

        IntListProcessor.SortDescending(intList);
        IntListProcessor.PrintList(intList, "Отсортированный список Int по убыванию:");

        // Поиск элемента Int(35)
        var searchElement = new Int(35);
        var found = IntListProcessor.FindElement(intList, searchElement);
        if (found != null)
            Console.WriteLine($"Найден элемент: {found}");
        else
            Console.WriteLine("Элемент не найден");

        // Подсчёт элементов > 30
        int countLong = longList.FindAll(x => x > 30).Count;
        Console.WriteLine($"Количество элементов > 30 в longList: {countLong}");

        int countInt = intList.FindAll(x => x.GetValue() > 30).Count;
        Console.WriteLine($"Количество элементов с value > 30 в intList: {countInt}");
    }
}
