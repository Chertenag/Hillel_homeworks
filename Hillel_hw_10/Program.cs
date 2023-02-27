using System.Security.Cryptography;

namespace Hillel_hw_10
{
    internal class Program
    {
        static void Main(string[] _)
        {
            Console.ReadLine();
            ForCycleThreadPooolTest(1000, 100, 1000);
            Console.ReadLine();
        }

        /// <summary>
        /// Запускает цикл for на cycles итераций, в каждой из которых создает в пуле потоков новый поток,
        /// и в нём выводит в консоль номер итерации и текущее количество потоков в пуле потоков.
        /// </summary>
        /// <param name="cycles">Количество итераций.</param>
        /// <param name="minPoolThreads">Минимум потоков в пуле потоков.</param>
        /// <param name="maxPoolThreads">Максимум потоков в пуле потоков.</param>
        private static void ForCycleThreadPooolTest(int cycles, int minPoolThreads, int maxPoolThreads)
        {
            ThreadPool.SetMinThreads(minPoolThreads, 1);
            ThreadPool.SetMaxThreads(maxPoolThreads, 1000);
            for (int i = 0; i < cycles; i++)
            {
                ThreadPool.QueueUserWorkItem(ToConsole, i);
            }
        }

        private static void ToConsole(object? iteration)
        {
            Console.WriteLine($"Cycle iteration:    {iteration}");
            Console.WriteLine($"Treadpool th count: {ThreadPool.ThreadCount}");
            Console.WriteLine($"In Threadpool: {Thread.CurrentThread.IsThreadPoolThread}");
            Thread.Sleep(TimeSpan.FromSeconds(10));
        }
    }
}