using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        int[] array = new int[18];
        Random rand = new Random();

        Console.WriteLine("Сгенерированный исходный массив:");
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = rand.Next(1, 90);
            Console.Write(array[i] + " ");
        }
        Console.WriteLine("\n--------------------------------------------------\n");

        Thread threadT0 = new Thread(() =>
        {
            Console.WriteLine("[Поток T0] Квадраты всех элементов массива:");
            foreach (var item in array)
            {
                Thread.Sleep(50);
                Console.WriteLine($"Элемент: {item} -> Квадрат: {item * item}");
            }
            Console.WriteLine("[Поток T0] Завершил работу.\n");
        });

        Thread threadT1 = new Thread(() =>
        {
            Console.WriteLine("[Поток T1] Числа меньше 50:");
            foreach (var item in array)
            {
                Thread.Sleep(50);
                if (item < 50)
                {
                    Console.WriteLine($"Найдено число < 50: {item}");
                }
            }
            Console.WriteLine("[Поток T1] Завершил работу.\n");
        });

        threadT0.Start();
        threadT1.Start();

        threadT0.Join();
        threadT1.Join();

        Console.WriteLine("Работа всех потоков завершена. Нажмите любую клавишу для выхода.");
        Console.ReadKey();
    }
}