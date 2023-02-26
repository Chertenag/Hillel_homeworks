namespace Hillel_hw_9
{
    internal class Program
    {
        static void Main(string[] _)
        {
            ThreadPool.GetAvailableThreads(out int wTAv, out int ioAv);
            ThreadPool.GetMinThreads(out int wTmin, out int ioMin);
            ThreadPool.GetMaxThreads(out int wTmax, out int ioMax);
            Console.WriteLine("----------------------------");
            Console.WriteLine($"ManagedThreadId:    {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"ThreadsCount:       {System.Diagnostics.Process.GetCurrentProcess().Threads.Count}");
            Console.WriteLine($"Worker threads ave: {wTAv}, I/O threads ave: {ioAv}");
            Console.WriteLine($"Worker threads min: {wTmin}, I/O threads min: {ioMin}");
            Console.WriteLine($"Worker threads max: {wTmax}, I/O threads max: {ioMax}");

            ThreadRecursion();

            //TreadPoolRecursion(true);
            //TreadPoolRecursion(false);

            //Thread thread = new(MultithreadRecursion);
            //thread.Start();
        }

        /// <summary>
        /// Бесконечный (при определённых условиях) рекурсивный метод, который выводит в консоль текущий ИД потока и кол-во потоков.
        /// </summary>
        static void ThreadRecursion()
        {
            Thread thread = new(ThreadRecursion);

            //Random random = new Random();
            //Thread.Sleep(random.Next(500, 1000));

            thread.IsBackground = true;
            thread.Start();
            Console.WriteLine("------------------------");
            Console.WriteLine($"ManagedThreadId:   {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"ThreadsCount:      {System.Diagnostics.Process.GetCurrentProcess().Threads.Count}");
            thread.Join();
        }

        /// <summary>
        /// Тестовый метод для сравнения.
        /// </summary>
        static void TreadPoolRecursion(Object? stateInfo)
        {
            ThreadPool.QueueUserWorkItem(TreadPoolRecursion, false);
            Console.WriteLine($"ManagedThreadId:   {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"ThreadsCount:      {System.Diagnostics.Process.GetCurrentProcess().Threads.Count}");
            if ((bool)stateInfo)
            {
                Thread.Sleep(500);
            }
        }
    }
}