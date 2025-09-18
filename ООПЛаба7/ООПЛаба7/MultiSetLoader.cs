using System;
using System.Collections.Generic;
using System.IO;

public class MultiSetLoader
{
    public List<IPrintableSet> LoadSetsFromFile(string path)
    {
        if (!File.Exists(path))
            throw new FileOpenException($"Файл '{path}' не найден");

        List<IPrintableSet> result = new List<IPrintableSet>();

        try
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string? line;
                int lineNumber = 0;

                while ((line = reader.ReadLine()) != null)
                {
                    lineNumber++;
                    var parts = line.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                    if (parts.Length < 2)
                        throw new InvalidElementException($"Строка {lineNumber} должна содержать тип и хотя бы один элемент.");

                    string typeName = parts[0].Trim().ToLower();

                    switch (typeName)
                    {
                        case "int":
                            var intSet = new CSet<int>();
                            for (int j = 1; j < parts.Length; j++)
                            {
                                if (!int.TryParse(parts[j], out int val))
                                    throw new InvalidElementException($"Неверный элемент int в строке {lineNumber}: '{parts[j]}'");
                                if (intSet.ToList().Contains(val))
                                    Console.WriteLine($"Пропущен дубликат {val} в строке {lineNumber}");
                                else
                                    intSet.Add(val);
                            }
                            result.Add(intSet);
                            break;

                        case "string":
                            var stringSet = new CSet<string>();
                            for (int j = 1; j < parts.Length; j++)
                            {
                                string val = parts[j];
                                if (stringSet.ToList().Contains(val))
                                    Console.WriteLine($"Пропущен дубликат '{val}' в строке {lineNumber}");
                                else
                                    stringSet.Add(val);
                            }
                            result.Add(stringSet);
                            break;

                        case "rectangle":
                            var rectSet = new CSet<Rectangle>();
                            for (int j = 1; j < parts.Length; j++)
                            {
                                Rectangle rect;
                                try
                                {
                                    rect = Rectangle.Parse(parts[j]);
                                }
                                catch (InvalidElementException ex)
                                {
                                    throw new InvalidElementException($"Ошибка в строке {lineNumber}: {ex.Message}");
                                }
                                if (rectSet.ToList().Contains(rect))
                                    Console.WriteLine($"Пропущен дубликат {rect} в строке {lineNumber}");
                                else
                                    rectSet.Add(rect);
                            }
                            result.Add(rectSet);
                            break;

                        default:
                            throw new InvalidElementException($"Неизвестный тип множества в строке {lineNumber}: '{typeName}'");
                    }
                }
            }
        }
        catch (IOException e)
        {
            throw new FileReadException($"Ошибка чтения файла: {e.Message}");
        }

        return result;
    }
}
