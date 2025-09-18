using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Создание множества А");
        CSet A = new CSet(new[]{ 1, 2, 3, 4 } );

        Console.WriteLine("Создание множества В");
        CSet B = new CSet(new[] { 3, 4, 5, 6 });

        Console.Write("A= "); A.Print();
        Console.Write("B= "); B.Print();

        Console.WriteLine("\nДобавим элемент 10 в А:");
        CSet C = A + 10;
        Console.Write("C= "); C.Print();

        Console.WriteLine("\nОбъеденение A+B:");
        CSet Union = A + B;
        Union.Print();

        Console.WriteLine("\nПересечение A*B:");
        CSet Intersection = A * B;
        Intersection.Print();

        Console.WriteLine("\nПроверка А==В:");
        Console.WriteLine(A == B ? "А и В равны" : "А и В НЕ равны");

        Console.WriteLine("\nМощность множества А:");
        int size = (int)A;
        Console.WriteLine("Мощность А:" + size);
    }
}