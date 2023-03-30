using System.Collections.Concurrent;

namespace Hillel_hw_16
{
    internal class Program
    {
        private static BlockingCollection<int> collection = new();

        static void Main(string[] _)
        {
            ParallePrimeCheck(100);
            collection.ToList().ForEach(Console.WriteLine);
        }

        private static void ParallePrimeCheck(int n)
        {
            collection = new();
            Parallel.For(0, n, AddToCollectionIfPrime);
        }

        private static void AddToCollectionIfPrime(int i)
        {
            if (PrimeChecker.Check(i))
            {
                collection.Add(i);
            }
        }
    }

}