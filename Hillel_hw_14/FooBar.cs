namespace Hillel_hw_14
{
    /// <summary>
    /// Позволяет выводить в консоль FooBar указанное число раз с использованием AutoResetEvent.
    /// </summary>
    public static class FooBar
    {
        private static readonly AutoResetEvent AutoReset1 = new(true);
        private static readonly AutoResetEvent AutoReset2 = new(false);

        /// <summary>
        /// Запуск основного метода вывода FooBar в консоль.
        /// </summary>
        /// <param name="count">Количество выводов FooBar в консоль.</param>
        /// <returns>Вовзврат Task, представляющий из себя выолнение текущей задачи.</returns>
        public static async Task Run(int count)
        {
            await Task.WhenAll(Task.Run(() => Foo(count)), Task.Run(() => Bar(count)));
        }

        private static void Foo(int n)
        {
            for (int i = 0; i < n; i++)
            {
                AutoReset1.WaitOne();
                Console.Write("foo");
                AutoReset2.Set();
            }
        }

        private static void Bar(int n)
        {
            for (int i = 0; i < n; i++)
            {
                AutoReset2.WaitOne();
                Console.Write("bar");
                AutoReset1.Set();
            }
        }
    }
}