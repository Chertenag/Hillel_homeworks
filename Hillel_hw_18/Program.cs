namespace Hillel_hw_18
{
    internal class Program
    {
        static void Main(string[] _)
        {
            //Среднее значение массива десятичных чисел.
            double[] decimals = new double[10] { 12.7, 0.8, 10, 22.00009, 13.666, 777, 03.03, 17.01, 19, 09.2 };
            var rez1 = decimals.AsParallel().Average();
            Console.WriteLine($"Average: {rez1}");
            Console.WriteLine();


            //Поиск всех строк, содержащих "apple".
            string[] strings = new string[5] 
            {
                "I'm craving something sweet and juicy, maybe an apple or a pear.",
                "A girl gave me an orange in exchange for a piece of cake.",
                "Apple pie is a classic dessert that always brings back fond memories of my childhood.",
                "After swimming, a glass of orange juice really fills the bill.",
                "Have you ever tried making homemade applesauce? It's surprisingly easy and tastes so much better than store-bought."
            };
            var rez2 = strings.AsParallel().Where(x => x.Contains("apple")).ToArray();
            Console.WriteLine($"Contains \"apple\": {rez2.Count()} string(s).");
            Console.WriteLine();

            //Вычисление суммы всех простых чисел в массиве.
            int[] ints = new int[10] { 1, 4, 7, 12, 13, 14, 19, 20, 22, 27 };
            var rez3 = ints.AsParallel().Where(i => PrimeChecker.Check(i) == true).Sum();
            Console.WriteLine($"Sum: {rez3}");
            Console.WriteLine();

            var cts = new CancellationTokenSource();
            var token = cts.Token;
            int[] ints2 = new int[20] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

            //Так как методот ForAll нет возомжности совместить с AsOrdered, в консоль будем выводить уже последовательно, а не паралельно.
            Task.Run(() =>
            {
                try
                {
                    ints2.AsParallel().AsOrdered().WithCancellation(token).Where(i => i % 2 == 0).ToList().ForEach(Console.WriteLine);
                }
                catch (OperationCanceledException)
                {
                    Console.WriteLine("Canceled.");
                }
            });
            cts.CancelAfter(100);

            Console.ReadLine();
        }
    }

    public static class PrimeChecker
    {
        /// <summary>
        /// Проверка на простые числа. 
        /// https://en.wikipedia.org/wiki/Primality_test
        /// </summary>
        /// <param name="value">Число для проверки.</param>
        /// <returns>true если число простое.</returns>
        public static bool Check(double value)
        {
            //Проверка на целочисельное
            if (value != (int)value)
                return false;

            if (value == 2 || value == 3)
            {
                return true;
            }

            if (value <= 1 || value % 2 == 0 || value % 3 == 0)
                return false;

            for (int i = 5; i * i <= value; i += 6)
            {
                if (value % i == 0 || value % (i + 2) == 0)
                    return false;
            }
            {
                return true;
            }
        }
    }
}