using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        try
        {
            Console.WriteLine("Загрузка множеств из файла:");

            var sets = Loader.LoadSetsFromFile("input.txt");

            Console.WriteLine("Прочитанные множества:");
            foreach (var set in sets)
            {
                set.Print();
            }

            // Сохраняем все множества в один файл output.txt
            using (var writer = new System.IO.StreamWriter("output.txt"))
            {
                int i = 1;
                foreach (var set in sets)
                {
                    writer.WriteLine($"Множество #{i}:");
                    foreach (var elem in set.GetElements())
                    {
                        writer.WriteLine(elem);
                    }
                    writer.WriteLine(); // пустая строка между множествами
                    i++;
                }
            }

            Console.WriteLine("Все множества сохранены в output.txt");
        }
        catch (InvalidElementException ex)
        {
            Console.WriteLine($"Ошибка: неверный элемент — {ex.Message}");
        }
        catch (DuplicateElementException ex)
        {
            Console.WriteLine($"Ошибка: дубликат — {ex.Message}");
        }
        catch (FileReadException ex)
        {
            Console.WriteLine($"Ошибка чтения: {ex.Message}");
        }
        catch (FileOpenException ex)
        {
            Console.WriteLine($"Ошибка открытия файла: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Непредвиденная ошибка: {ex.Message}");
        }

        Console.WriteLine("Программа завершена.");
    }
}
