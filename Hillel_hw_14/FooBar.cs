namespace Hillel_hw_14
{
    public static class FooBar
    {
        private static readonly AutoResetEvent autoReset1 = new(true);
        private static readonly AutoResetEvent autoReset2 = new(false);

        public static async Task Run(int count)
        {
            await FooBarToConsole(count);
            Console.WriteLine();
            Console.WriteLine($"End writing with {count} FooBar`s.");
        }

        private static async Task FooBarToConsole(int count)
        {
            await Task.WhenAll(Task.Run(() => Foo(count)), Task.Run(() => Bar(count)));
        }

        private static void Foo(int n)
        {
            for (int i = 0; i < n; i++)
            {
                autoReset1.WaitOne();
                Console.Write("foo");
                autoReset2.Set();
            }
        }

        private static void Bar(int n)
        {
            for (int i = 0; i < n; i++)
            {
                autoReset2.WaitOne();
                Console.Write("bar");
                autoReset1.Set();
            }
        }
    }
}