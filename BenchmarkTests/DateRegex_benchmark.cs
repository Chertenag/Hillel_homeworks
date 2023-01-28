using BenchmarkDotNet.Attributes;

namespace BenchmarkTests
{
    public class DateRegex_benchmark
    {
        private const string inputText = "Привіт 12/12/2202 привіт";

        [Benchmark]
        public void GeneretedMatch()
        {
            DateRegex.GenMatch(inputText);
        }

        [Benchmark]
        public void CompiledMatch()
        {
            DateRegex.CompilMatch(inputText);
        }

        [Benchmark]
        public void DefaultMatch()
        {
            DateRegex.DefMatch(inputText);
        }
    }
}