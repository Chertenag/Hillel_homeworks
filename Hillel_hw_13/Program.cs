using System;

namespace Hillel_hw_13
{
    internal class Program
    {
        private static Mutex mutex = new Mutex();

        static async Task Main(string[] args)
        {

            //Почему так вообще не работает.?..
            //Task odd = OddNumbersAsync();
            //Task even = EvenNumbersAsync();
            //await Task.WhenAll(odd, even);

            //Так работает, но раз через раз. Иногда счёт начинается с парных чисел.
            //Task odd = Task.Run(() => OddNumbers());
            //Task even = Task.Run(() => EvenNumbers());

            Task odd = Task.Run(OddNumbersAsync);
            Task even = Task.Run(EvenNumbersAsync);

            //Task.Factory.StartNew(() => OddNumbers());
            //Task.Factory.StartNew(() => EvenNumbers());


            Console.ReadLine();
        }

        private static async Task OddNumbersAsync()
        {
            for (int i = 1; i <= 100; i += 2)
            {
                NumbToConsole(i);
            }
        }

        private static async Task EvenNumbersAsync()
        {
            for (int i = 2; i <= 100; i += 2)
            {
                NumbToConsole(i);
            }
        }
        private static void OddNumbers()
        {
            for (int i = 1; i <= 100; i += 2)
            {
                NumbToConsole(i);
            }
        }

        private static void EvenNumbers()
        {
            for (int i = 2; i <= 100; i += 2)
            {
                NumbToConsole(i);
            }
        }

        private static void NumbToConsole(int i)
        {
            try
            {
                mutex.WaitOne();
                Console.WriteLine(i);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                mutex.ReleaseMutex();
            }
        }
    }
}

