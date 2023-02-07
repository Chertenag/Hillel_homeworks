using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Hillel_hw_7
{
    internal class Program
    {
        static void Main(string[] _)
        {
            BenchmarkRunner.Run<StringBuilderVSString_benchmark_10_100_200>();
            BenchmarkRunner.Run<StringBuilderVSString_benchmark_10_2500_3000>();
            BenchmarkRunner.Run<StringBuilderVSString_benchmark_50_100_200>();
            BenchmarkRunner.Run<StringBuilderVSString_benchmark_50_2500_3000>();
            BenchmarkRunner.Run<StringBuilderVSString_benchmark_100_100_200>();
            BenchmarkRunner.Run<StringBuilderVSString_benchmark_100_2500_3000>();
            BenchmarkRunner.Run<StringBuilderVSString_benchmark_500_100_200>();
            BenchmarkRunner.Run<StringBuilderVSString_benchmark_500_2500_3000>();
        }
    }
}