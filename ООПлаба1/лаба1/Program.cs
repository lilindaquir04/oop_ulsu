using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Создание списка list...");
        DoublyLinkedList list = new DoublyLinkedList();

        list.Add(10);
        list.Add(20);
        list.Add(30);

        Console.WriteLine("Прямой вывод:");
        list.PrintForward();

        Console.WriteLine("Обратный вывод:");
        list.PrintBackward();

        Console.WriteLine("Поиск 20: " + (list.Find(20) ? "найден" : "не найден"));
        Console.WriteLine("Удаление 10...");
        list.Remove(10);

        Console.WriteLine("Список после удаления:");
        list.PrintForward();

        Console.WriteLine("Создание копии списка...");
        DoublyLinkedList copiedList = new DoublyLinkedList(list);

        Console.WriteLine("Вывод скопированного списка:");
        copiedList.PrintForward();

        Console.WriteLine("Конец программы. Объекты будут уничтожены сборщиком мусора.");
        GC.Collect();
        GC.WaitForPendingFinalizers();
    }
}

