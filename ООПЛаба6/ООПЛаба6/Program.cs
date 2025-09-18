using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Тест с int:");
        var intSet = new CSet<int>(new[] { 1, 2, 3, 4, 5, 6 });
        intSet.Print();
        Utils.RemoveEverySecond(intSet);
        Console.WriteLine("После удаления каждого второго:");
        intSet.Print();

        Console.WriteLine("\nТест с double:");
        var doubleSet = new CSet<double>(new[] { 1.1, 2.2, 3.3, 4.4 });
        doubleSet.Print();
        Utils.RemoveEverySecond(doubleSet);
        doubleSet.Print();

        Console.WriteLine("\nТест с Rectangle:");
        var rectSet = new CSet<Rectangle>(new[]
        {
            new Rectangle(1,2),
            new Rectangle(3,4),
            new Rectangle(5,6),
            new Rectangle(7,8)
        });
        rectSet.Print();
        Utils.RemoveEverySecond(rectSet);
        rectSet.Print();
    }
}