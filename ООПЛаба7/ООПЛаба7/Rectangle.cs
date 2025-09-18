using System;

public class Rectangle
{
    public int Wight { get; set; }
    public int Height { get; set; }

    public Rectangle(int w, int h)
    {
        Wight = w; Height = h;
    }

    public int Area => Wight * Height;

    public override string ToString()
    {
        return $"[{Wight},{Height}]";
    }

    public override bool Equals(object? obj)
    {
        return obj is Rectangle r && r.Wight == Wight && r.Height == Height;
    }

    public override int GetHashCode()
    {
        return Wight ^ Height;
    }

    public static Rectangle Parse(string line)
    {
        var parts = line.Split(',');
        if (parts.Length != 2)
            throw new InvalidElementException($"Неверный формат Rectangle: '{line}'");

        if (!int.TryParse(parts[0], out int w) || !int.TryParse(parts[1], out int h))
            throw new InvalidElementException($"Неверный формат числа в Rectangle: '{line}'");

        return new Rectangle(w, h);
    }
}
