namespace Hillel_hw_14
{
    /// <summary>
    /// Основной класс приложения.
    /// </summary>
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter number of FooBar`s to write:");
                string? value = Console.ReadLine();
                if (value != null)
                {
                    if (int.TryParse(value, out int count))
                    {
                        if (count < 0)
                        {
                            Console.WriteLine($"You can't count something negative number of times.");
                        }
                        else
                        {
                            await FooBar.Run(count);
                            Console.WriteLine();
                            Console.WriteLine($"End writing with {count} FooBar`s.");

                        }
                    }
                    else
                    {
                        Console.WriteLine($"{value} is not a number.");
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}