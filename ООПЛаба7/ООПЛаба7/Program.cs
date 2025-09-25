using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // 1. Загружаем исходные данные
            var (intSet, doubleSet, rectSet) = ConfigLoader.LoadFromConfig("config.txt");

            // 2. Выводим на экран
            Console.WriteLine("=== Исходные данные ===");
            Console.Write("int: "); intSet.Print();
            Console.Write("double: "); doubleSet.Print();
            Console.Write("Rectangle: "); rectSet.Print();

            // 3. Создаём копии для обработки (через ToList + SetFromList)
            var intAfter = new CSet<int>();
            intAfter.SetFromList(intSet.ToList());

            var doubleAfter = new CSet<double>();
            doubleAfter.SetFromList(doubleSet.ToList());

            var rectAfter = new CSet<Rectangle>();
            rectAfter.SetFromList(rectSet.ToList());

            // 4. Обрабатываем
            Utils.RemoveEverySecond(intAfter);
            Utils.RemoveEverySecond(doubleAfter);
            Utils.RemoveEverySecond(rectAfter);

            // 5. Выводим результат
            Console.WriteLine("\n=== После удаления каждого второго ===");
            Console.Write("int: "); intAfter.Print();
            Console.Write("double: "); doubleAfter.Print();
            Console.Write("Rectangle: "); rectAfter.Print();

            // 6. Сохраняем ВСЁ в output.txt
            using (var writer = new StreamWriter("output.txt"))
            {
                writer.WriteLine("=== Исходные данные ===");
                writer.Write("int: "); intSet.SaveToWriter(writer);
                writer.Write("double: "); doubleSet.SaveToWriter(writer);
                writer.Write("Rectangle: "); rectSet.SaveToWriter(writer);

                writer.WriteLine("\n=== После удаления каждого второго элемента ===");
                writer.Write("int: "); intAfter.SaveToWriter(writer);
                writer.Write("double: "); doubleAfter.SaveToWriter(writer);
                writer.Write("Rectangle: "); rectAfter.SaveToWriter(writer);
            }

            Console.WriteLine("\n✅ Результат записан в output.txt");
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"❌ Ошибка: {ex.Message}");
            Console.ResetColor();
        }

        Console.WriteLine("\nНажмите любую клавишу...");
        Console.ReadKey();
    }
}