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
        static int sum = 0;
        static int[] array;
        static void Method1()
        {
            Console.WriteLine("Method1 начал работу");
            
            for (int i = 0; i < n; i++)
            {
                sum += array[i];
                Thread.Sleep(500);
                
            }
            //return sum;
            Console.WriteLine($"Sum: {sum}");
            Console.WriteLine("Method1 окончил работу");
            
        }
        static void Method2(Task task, object a)
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
            Console.Write("Введите число для создания массива: ");
            int n = Convert.ToInt32(Console.ReadLine());

            int[] array = new int[n];
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                array[i] = random.Next(-10, 10);
                Console.Write("{0} ", array[i]);
            }
            Console.WriteLine();

            Func<int> func=new Func<int>(Method1);                    
            Task<int> task1 = new Task<int>(() => sum(n));


            Task task2 = task1.ContinueWith(sum => Method1(sum.Result));
            //Action<Task, object> actionTask = new Action<Task, object>(Method2);
            //Task task2 = task1.ContinueWith(actionTask, n);

            task1.Start();
            

            //Task<int> task1 = new Task<int>(() => sum(n));

            // задача продолжения
            //Task task2 = task1.ContinueWith(sum => Method1(sum.Result));

            //task1.Start();

            // ждем окончания второй задачи
            //task2.Wait();
            //Console.WriteLine("End of Main");

            //Action<int> action = new Action<int>(Method1);
            //Task<int> task = new Task<int>(action);

            //Action<Task, object> actionTask = new Action<Task, object>(Method1);
            //Task task2 = task.ContinueWith(actionTask, 100);
            //task.Start();
            //Console.WriteLine(task.Result);
            task1.Wait();
            Console.WriteLine("Main окончил работу");
            Console.ReadKey();
        }
    }
}