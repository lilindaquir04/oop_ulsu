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
    }
}
