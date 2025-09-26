// Program.cs
using System;
using System.IO;

class Program
{
    static void Main()
    {
        const string InputFile = "input.txt";
        const string OutputFile = "output.txt";

        try
        {
            
            var sets = DataLoader.LoadSetsFromFile(InputFile);

            
            using (var writer = new StreamWriter(OutputFile))
            {
                foreach (var set in sets)
                {
                    // Вывод исходного состояния
                    WriteSet(set, Console.Out);
                    WriteSet(set, writer);

                    // Применяем RemoveEverySecond
                    if (set is CSet<int> intSet)
                    {
                        Utils.RemoveEverySecond(intSet);
                        Console.WriteLine("После удаления каждого второго (int):");
                        writer.WriteLine("После удаления каждого второго (int):");
                        WriteSet(intSet, Console.Out);
                        WriteSet(intSet, writer);
                    }
                    else if (set is CSet<double> doubleSet)
                    {
                        Utils.RemoveEverySecond(doubleSet);
                        Console.WriteLine("После удаления каждого второго (double):");
                        writer.WriteLine("После удаления каждого второго (double):");
                        WriteSet(doubleSet, Console.Out);
                        WriteSet(doubleSet, writer);
                    }
                    else if (set is CSet<Rectangle> rectSet)
                    {
                        Utils.RemoveEverySecond(rectSet);
                        Console.WriteLine("После удаления каждого второго (Rectangle):");
                        writer.WriteLine("После удаления каждого второго (Rectangle):");
                        WriteSet(rectSet, Console.Out);
                        WriteSet(rectSet, writer);
                    }

                    Console.WriteLine();
                    writer.WriteLine();
                }
            }

            Console.WriteLine($" Результат сохранен в {OutputFile}");
        }
        //  ОБРАБОТКА ИСКЛЮЧЕНИЙ
        catch (SetException ex)
        {
            Console.WriteLine($" Ошибка: {ex.Message}");
            File.WriteAllText("error.log", ex.ToString());
        }
        catch (Exception ex)
        {
            Console.WriteLine($" Неожиданная ошибка: {ex.Message}");
            File.WriteAllText("crash.log", ex.ToString());
        }
    }

    // Вспомогательный метод для вывода любого CSet<T>
    static void WriteSet(object set, TextWriter writer)
    {
        switch (set)
        {
            case CSet<int> s: s.PrintTo(writer); break;
            case CSet<double> s: s.PrintTo(writer); break;
            case CSet<Rectangle> s: s.PrintTo(writer); break;
        }
    }
}