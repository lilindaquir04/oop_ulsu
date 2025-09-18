using System;

class Program
{
    static void Main()
    {
        try
        {
            var set1 = new CSet<int>();
            set1 = set1 + 1;
            set1 = set1 + 2;
            set1 = set1 + 3;
            set1.Print();

            var set2 = new CSet<int>(new int[] { 2, 3, 4, 5 });
            set2.Print();

            var intersection = set1 * set2;
            intersection.Print();

            bool isEqual = (set1 == set2);
            Console.WriteLine("Равны множества? " + isEqual);

            int oldVal = 3;
            set1.UpdateElement(ref oldVal, 10, out bool success);
            Console.WriteLine("Обновление элемента успешно? " + success);
            set1.Print();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
        finally
        {
            Console.WriteLine("Завершение программы");
        }
    }
}
