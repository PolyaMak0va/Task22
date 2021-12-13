using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task22
{
    class Program
    {
        // Сформировать массив случайных целых чисел (размер  задается пользователем). Вычислить сумму чисел массива и максимальное число в массиве.
        // Реализовать  решение  задачи  с  использованием  механизма  задач продолжения.
        static int sum;

        static void Method1(object arr)
        {
            Console.WriteLine("\n\nMethod1 начал работу\n");
            int[] array = (int[])arr;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
                Thread.Sleep(200);
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"\tСумма всех чисел массива равна: {sum}.\n");
            Console.ResetColor();
            Console.WriteLine("Method1 окончил работу\n");
        }

        static void Method2(Task task, object a)
        {
            Console.WriteLine("Method2 начал работу\n");
            int[] array = (int[])a;
            int max = array[0];
            foreach (int b in array)
            {
                if (b > max)
                    max = b;
                Thread.Sleep(500);
            }
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.WriteLine($"\tМаксимальное число в массиве - это число {max}.\n");
            Console.ResetColor();
            Console.WriteLine("Method2 окончил работу\n");
        }
        static void Method3(Task task, object a)
        {
            Console.WriteLine("Method3 начал работу\n");
            int[] array = (int[])a;
            int min = array[0];
            foreach (int b in array)
            {
                if (b < min)
                    min = b;
                Thread.Sleep(500);
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"\tМинимальное число в массиве - это число {min}.\n");
            Console.ResetColor();
            Console.WriteLine("Method3 окончил работу\n");
        }
        static void Main(string[] args)
        {
            Console.Write("Введите число для создания массива: ");

            try
            {
                int n = Convert.ToInt32(Console.ReadLine());
                int[] array = new int[n];
                Random random = new Random();

                for (int i = 0; i < n; i++)
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    array[i] = random.Next(-10, 10);
                    Console.Write("\t{0} ", array[i]);                   
                }               
                Console.ResetColor();

                Action<object> action1 = new Action<object>(Method1);
                Task task1 = Task.Factory.StartNew(action1, array);
                task1.Wait();

                Action<Task, object> actionTask1 = new Action<Task, object>(Method2);
                Task task2 = task1.ContinueWith(actionTask1, array);
                task2.Wait();

                Action<Task, object> actionTask2 = new Action<Task, object>(Method3);
                Task task3 = task1.ContinueWith(actionTask2, array);
                task3.Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка! {ex.Message}");
            }

            Console.WriteLine("Main окончил работу...");
            Console.ReadKey();
        }
    }
}