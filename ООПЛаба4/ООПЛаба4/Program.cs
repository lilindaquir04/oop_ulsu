using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Создаём сотрудников...");

        new Worker("Сергей Маляр", "Фрезировщик", "Цех н.1");
        new Engineer("Алексей Губанов", "Ведущий инженер", "Отдел технического контроля");
        new Administration("Олег Бочаров", "Директор");

        Console.WriteLine("\nВыводим всех сотрудников через статический метод:");

        Personnel.ViewList();
        Console.WriteLine("\nРабочие из 'Цех н.1':");
        foreach (var name in Worker.GetWorkersFromWorkshop("Цех н.1"))
        {
            Console.WriteLine(name);
        }

        Console.WriteLine("\nИнженеров в 'Отделe технического контроля': " +
            Engineer.CountEngineersInDepartment("Отдел технического контроля"));
    }
}

