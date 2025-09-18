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
        return $"[{Wight}x{Height}]";
    }

    public override bool Equals(object? obj)
    {
        return obj is Rectangle r && r.Wight == Wight && r.Height == Height;
    }

    public override int GetHashCode()
    {
        return Wight ^ Height;
    }


}