// Rectangle.cs
using System;

public class Rectangle
{
    public int Width { get; set; }
    public int Height { get; set; }

    public Rectangle(int w, int h)
    {
        // 🔥 Исключение №1: недопустимые данные
        if (w <= 0 || h <= 0)
            throw new InvalidObjectDataException(
                $"Rectangle dimensions must be positive. Got: {w}x{h}");

        Width = w;
        Height = h;
    }

    public int Area => Width * Height;

    public override string ToString() => $"[{Width}x{Height}]";

    public override bool Equals(object? obj) =>
        obj is Rectangle r && r.Width == Width && r.Height == Height;

    public override int GetHashCode() => HashCode.Combine(Width, Height);
}