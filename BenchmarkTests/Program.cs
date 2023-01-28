using BenchmarkDotNet.Running;

namespace BenchmarkTests
{
    internal class Program
    {
        static void Main(string[] _)
        {
            BenchmarkRunner.Run<DublRegexReplace_benchmark>();
            //BenchmarkRunner.Run<DateRegex_benchmark>();
        }
    }
}