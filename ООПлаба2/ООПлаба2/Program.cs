using System;

class Programm
{
    static void Main()
    {
        Console.WriteLine("Рабочие:");

        Worker w = new Worker("Сергей Маляр", "Фрезировщик", "Цех н.1");

        Console.WriteLine("Инженеры:");

        Engineer e = new Engineer("Алексей Губанов", "Ведущий инженер", "Отдел технического контроля");

        Console.WriteLine("Администрация:");

        Administration a = new Administration("Олег Бочаров", "Директор");

        Console.WriteLine("\nВывод информации о сотрудниках:\n");

        w.PrintInfo();
        Console.WriteLine();

        e.PrintInfo();
        Console.WriteLine();

        a.PrintInfo();
    }
}