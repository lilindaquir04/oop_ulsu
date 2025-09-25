using System;

public class Rectangle
{
    public int Width { get; }
    public int Height { get; }

    public Rectangle(int w, int h)
    {
        if (w <= 0 || h <= 0)
            throw new ConfigException($"Недопустимые размеры прямоугольника: {w}x{h}");
        Width = w;
        Height = h;
    }

    public override string ToString() => $"[{Width}x{Height}]";

    public override bool Equals(object obj)
    {
        return obj is Rectangle r && r.Width == Width && r.Height == Height;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Width, Height);
    }
}