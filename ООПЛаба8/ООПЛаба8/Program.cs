// Program.cs
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        try
        {
            // ============ Часть 1: long (встроенный тип) ============
            Console.WriteLine("=== Часть 1: long (встроенный тип) ===");

            // а. Создать и заполнить
            var longList = LongListProcessor.CreateList();
            LongListProcessor.PrintList(longList, "а. Исходный список long:");

            // б. Изменить: удалить 20,60; заменить 30→35
            LongListProcessor.ModifyList(longList);
            LongListProcessor.PrintList(longList, "б. После удаления 20,60 и замены 30→35:");

            // в. Просмотр через итерации
            Console.Write("в. Через итерации (foreach): ");
            foreach (var item in longList)
                Console.Write(item + " ");
            Console.WriteLine("\n");

            // г. Удалить 2 элемента после значения 40
            LongListProcessor.RemoveAfterValue(longList, 40, 2);
            LongListProcessor.PrintList(longList, "г. После удаления 2 элементов после значения 40:");

            // д. Сортировка по убыванию
            LongListProcessor.SortDescending(longList);
            LongListProcessor.PrintList(longList, "д. Отсортирован по убыванию:");

            // ============ Часть 2: Int (пользовательский тип) ============
            Console.WriteLine("\n=== Часть 2: Int (пользовательский тип) ===");

            // е.а. Создать и заполнить
            var intList = IntListProcessor.CreateList();
            IntListProcessor.PrintList(intList, "е.а. Исходный список Int:");

            // е.б. Изменить
            IntListProcessor.ModifyList(intList);
            IntListProcessor.PrintList(intList, "е.б. После удаления 20,60 и замены 30→35:");

            // е.в. Итерации
            Console.Write("е.в. Через итерации (foreach): ");
            foreach (var item in intList)
                Console.Write(item + " ");
            Console.WriteLine("\n");

            // е.г. Удалить 2 элемента после значения 40
            IntListProcessor.RemoveAfterValue(intList, new Int(40), 2);
            IntListProcessor.PrintList(intList, "е.г. После удаления 2 элементов после значения 40:");

            // е.д. Сортировка
            IntListProcessor.SortDescending(intList);
            IntListProcessor.PrintList(intList, "е.д. Отсортирован по убыванию:");

            // ж. Поиск элемента
            var searchElement = new Int(35);
            var found = IntListProcessor.FindElement(intList, searchElement);
            if (found != null)
                Console.WriteLine($"ж. Найден элемент: {found}");
            else
                Console.WriteLine("ж. Элемент не найден");

            // з. Подсчёт элементов, удовлетворяющих условию
            int countLong = longList.Count(x => x > 30);
            int countInt = intList.Count(x => x.GetValue() > 30);
            Console.WriteLine($"\nз. Количество элементов со значением > 30:");
            Console.WriteLine($"   - В longList: {countLong}");
            Console.WriteLine($"   - В intList: {countInt}");
            Console.WriteLine($"   - Всего: {countLong + countInt}");

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}