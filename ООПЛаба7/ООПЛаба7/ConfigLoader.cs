using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

public static class ConfigLoader
{
    public static (CSet<int> intSet, CSet<double> doubleSet, CSet<Rectangle> rectSet) LoadFromConfig(string path)
    {
        var intSet = new CSet<int>();
        var doubleSet = new CSet<double>();
        var rectSet = new CSet<Rectangle>();

        string[] lines = File.ReadAllLines(path);
        foreach (string rawLine in lines)
        {
            string line = rawLine.Trim();
            if (string.IsNullOrEmpty(line) || line.StartsWith("#")) continue;

            // Разделяем ТОЛЬКО по первым двум точкам с запятой
            int first = line.IndexOf(';');
            int second = line.IndexOf(';', first + 1);

            if (first == -1 || second == -1)
                throw new ConfigException($"Неверный формат строки: {line}");

            string type = line.Substring(0, first).Trim();
            string countStr = line.Substring(first + 1, second - first - 1).Trim();
            string values = line.Substring(second + 1); // всё остальное

            if (!int.TryParse(countStr, out int count) || count < 0)
                throw new ConfigException($"Неверное количество: {countStr}");

            switch (type)
            {
                case "int":
                    string[] intVals = values.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    if (intVals.Length != count)
                        throw new ConfigException($"Ожидалось {count} int, получено {intVals.Length}");

                    foreach (string s in intVals)
                    {
                        if (int.TryParse(s.Trim(), out int v))
                            intSet.Add(v);
                        else
                            throw new ConfigException($"Неверное int: '{s}'");
                    }
                    break;

                case "double":
                    string[] dblVals = values.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    if (dblVals.Length != count)
                        throw new ConfigException($"Ожидалось {count} double, получено {dblVals.Length}");

                    foreach (string s in dblVals)
                    {
                        if (double.TryParse(s.Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out double v))
                            doubleSet.Add(v);
                        else
                            throw new ConfigException($"Неверное double: '{s}'");
                    }
                    break;

                case "Rectangle":
                    string[] rectPairs = values.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    if (rectPairs.Length != count)
                        throw new ConfigException($"Ожидалось {count} пар Rectangle, получено {rectPairs.Length}");

                    foreach (string pair in rectPairs)
                    {
                        string[] wh = pair.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        if (wh.Length != 2)
                            throw new ConfigException($"Пара должна содержать 2 числа: '{pair}'");

                        if (!int.TryParse(wh[0].Trim(), out int w) || !int.TryParse(wh[1].Trim(), out int h))
                            throw new ConfigException($"Неверные параметры: '{wh[0]}', '{wh[1]}'");

                        rectSet.Add(new Rectangle(w, h));
                    }
                    break;

                default:
                    throw new ConfigException($"Неизвестный тип: {type}");
            }
        }

        return (intSet, doubleSet, rectSet);
    }
}