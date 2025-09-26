// DataLoader.cs
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

public static class DataLoader
{
    public static List<object> LoadSetsFromFile(string filePath)
    {
        if (!File.Exists(filePath))
            throw new FileProcessingException($"Файл не найден: {filePath}");

        try
        {
            string[] lines = File.ReadAllLines(filePath);
            var results = new List<object>();
            int i = 0;

            while (i < lines.Length)
            {
                string typeLine = lines[i].Trim();
                if (string.IsNullOrEmpty(typeLine)) { i++; continue; }

                // Проверяем тип
                if (!TryParseType(typeLine, out Type dataType))
                    throw new UnsupportedTypeException($"Неподдерживаемый тип данных: {typeLine}");

                i++;
                if (i >= lines.Length)
                    throw new InvalidFileFormatException("Пропущенный счетчик после ввода.");

                if (!int.TryParse(lines[i], out int count) || count < 0)
                    throw new InvalidFileFormatException("Неверный элемент счетчика.");

                i++;

                if (dataType == typeof(int))
                {
                    var values = ParseIntegers(lines, ref i, count);
                    results.Add(new CSet<int>(values));
                }
                else if (dataType == typeof(double))
                {
                    var values = ParseDoubles(lines, ref i, count);
                    results.Add(new CSet<double>(values));
                }
                else if (dataType == typeof(Rectangle))
                {
                    var rects = ParseRectangles(lines, ref i, count);
                    results.Add(new CSet<Rectangle>(rects));
                }
                else
                {
                    throw new UnsupportedTypeException($"Неожиданный тип: {dataType}");
                }
            }

            return results;
        }
        catch (IOException ex)
        {
            throw new FileProcessingException($"IO error: {ex.Message}", ex);
        }
        catch (OutOfMemoryException ex)
        {
            throw new MemoryAllocationException("Not enough memory.", ex);
        }
    }

    private static bool TryParseType(string typeName, out Type type)
    {
        type = null; // Гарантируем присваивание

        switch (typeName)
        {
            case "int":
                type = typeof(int);
                return true;
            case "double":
                type = typeof(double);
                return true;
            case "Rectangle":
                type = typeof(Rectangle);
                return true;
            default:
                return false;
        }
    }

    private static List<int> ParseIntegers(string[] lines, ref int index, int count)
    {
        var list = new List<int>();
        if (index >= lines.Length)
            throw new InvalidFileFormatException("Unexpected end of file (int).");

        string line = lines[index++].Trim();
        string[] parts = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

        if (parts.Length != count)
            throw new InvalidFileFormatException($"Expected {count} integers, got {parts.Length}: '{line}'");

        for (int j = 0; j < parts.Length; j++)
        {
            if (!int.TryParse(parts[j], out int val))
                throw new InvalidFileFormatException($"Invalid integer at position {j + 1}: '{parts[j]}'");
            list.Add(val);
        }

        return list;
    }

    private static List<double> ParseDoubles(string[] lines, ref int index, int count)
    {
        var list = new List<double>();
        if (index >= lines.Length)
            throw new InvalidFileFormatException("Unexpected end of file (double).");

        string line = lines[index++].Trim();
        string[] parts = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

        if (parts.Length != count)
            throw new InvalidFileFormatException($"Expected {count} doubles, got {parts.Length}: '{line}'");

        for (int j = 0; j < parts.Length; j++)
        {
            if (!double.TryParse(parts[j], NumberStyles.Float, CultureInfo.InvariantCulture, out double val))
                throw new InvalidFileFormatException($"Invalid double at position {j + 1}: '{parts[j]}'");
            list.Add(val);
        }

        return list;
    }

    private static List<Rectangle> ParseRectangles(string[] lines, ref int index, int count)
    {
        var list = new List<Rectangle>();
        for (int j = 0; j < count; j++)
        {
            if (index >= lines.Length)
                throw new InvalidFileFormatException("Unexpected end of file (Rectangle).");
            string[] parts = lines[index++].Trim()
                .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 2)
                throw new InvalidFileFormatException($"Rectangle needs 2 numbers, got: '{string.Join(" ", parts)}'");
            if (!int.TryParse(parts[0], out int w) || !int.TryParse(parts[1], out int h))
                throw new InvalidFileFormatException($"Invalid rectangle: '{lines[index - 1]}'");

            list.Add(new Rectangle(w, h)); // Может выбросить InvalidObjectDataException
        }
        return list;
    }
}