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
            set1.Print(); // { 1 2 3 }

            var set2 = new CSet<int>(new int[] { 2, 3, 4, 5 });
            set2.Print(); // { 2 3 4 5 }

            var intersection = set1 * set2;
            intersection.Print(); // { 2 3 }

            bool isEqual = (set1 == set2);
            Console.WriteLine("Равны множества? " + isEqual); // False

            int oldVal = 3;
            set1.UpdateElement(ref oldVal, 10, out bool success);
            Console.WriteLine("Обновление элемента успешно? " + success); // True
            Console.WriteLine("Новое значение oldVal: " + oldVal); // 10
            set1.Print(); // { 1 2 10 }

            // Проверка: повторное добавление не ломает
            set1 = set1 + 10; // дубликат — игнорируется
            set1.Print(); // { 1 2 10 }

            // Проверка индексатора
            Console.WriteLine("Элемент [0]: " + set1[0]); // 1
            set1[0] = 100;
            set1.Print(); // { 100 2 10 }

            // Попытка присвоить дубликат через индексатор → ошибка
            try
            {
                set1[1] = 100; // 100 уже есть → исключение
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Ожидалось исключение: " + ex.Message);
            }
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