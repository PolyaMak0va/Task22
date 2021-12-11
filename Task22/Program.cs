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
        static int n;
        static int sum;
        static int[] array;
        static void Method1()
        {
            Console.Write("Введите число для создания массива: ");
            int n = Convert.ToInt32(Console.ReadLine());

            int[] array = new int[n];
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                array[i] = random.Next(-10, 10);
                Console.Write("{0} ", array[i]);
                Thread.Sleep(300);
            }
            Console.WriteLine();
        }

        static void Method2()
        {
            Console.WriteLine("Method1 начал работу");

            for (int i = 0; i < n; i++)
            {
                sum += array[i];
                Thread.Sleep(500);
                Console.WriteLine($"Sum: {sum}");
            }
            Console.WriteLine("Method1 окончил работу");
        }

        static void Method3(Task task, object a)
        {
            n = (int)a;
            int max = array[0];
            foreach (int b in array)
            {
                if (b > max)
                    max = b;
                Thread.Sleep(1000);
                Console.WriteLine(max);
            }
            Console.WriteLine("Method2 окончил работу");
        }

        static void Main(string[] args)
        {
            Method1();

            Action action2 = new Action(Method2);
            Task task2 = Task.Factory.StartNew(action2);

            //Task task = new Task(() => Console.WriteLine(sum));
            //task.Wait();
            Console.WriteLine("Main окончил работу");
            Console.ReadKey();
        }
    }
}