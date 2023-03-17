namespace Hillel_hw_13
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        private static class NumbersToConsole
        {
            private static Mutex mutexEven = new Mutex();
            private static Mutex mutexOdd = new Mutex();

            public static async Task Run ()
            {

            }

            private static async Task EvenNumbers ()
            {
                for (int i = 2; i <= 100; i += 2)
                {
                }
            }

            private static async Task OddNumbers()
            {
                for (int i = 1; i <= 100; i += 2)
                {
                }
            }

            private static async Task ToConsole (int index)
            {

            }
        }
    }
}

