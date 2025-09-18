using System;
using System.Collections;

class Program
{
    static void Main()
    {
        ArrayList personnelList = new ArrayList();

        try
        {
            HR hr1 = new HR("Анна Иванова", 30, "Отдел кадров");
            Worker worker1 = new Worker("Пётр Сидоров", 40, "Сварщик");
            Engineer engineer1 = new Engineer("Иван Петров", 35, 10);
            Administration admin1 = new Administration("Елена Смирнова", 45, "Менеджер");
            DeputyGeneralDirector deputy1 = new DeputyGeneralDirector("Алексей Кузнецов", 50, "Финансы");

            personnelList.Add(hr1);
            personnelList.Add(worker1);
            personnelList.Add(engineer1);
            personnelList.Add(admin1);
            personnelList.Add(deputy1);

            Console.WriteLine($"Всего объектов Personnel: {Personnel.GetCountObjects()}\n");

            // Вывод информации
            foreach (Personnel p in personnelList)
            {
                p.ShowInfo();
            }

            Console.WriteLine("\nОбновление возраста с ref и out:");

            int newAge = 62;
            hr1.UpdateAge(ref newAge);

            worker1.UpdateAge(ref newAge);

            engineer1.UpdateAge(ref newAge);

            admin1.UpdateAge(ref newAge);

            deputy1.UpdateAge(ref newAge);

            // Демонстрация out-параметра
            foreach (Personnel p in personnelList)
            {
                p.GetName(out string name);
                Console.WriteLine($"Имя сотрудника: {name}");
            }
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Общая ошибка: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("\nЗавершение программы.");
        }
    }
}
