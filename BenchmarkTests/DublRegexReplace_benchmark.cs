using BenchmarkDotNet.Attributes;

namespace BenchmarkTests
{
    public class DublRegexReplace_benchmark
    {
        private const string inputText = "Это тестовый текст текст. Он он используется для для проведения тестов тестов. Надо надо больше слов слов.";

        [Benchmark]
        public void GeneretedReplace()
        {
            DublRegexReplace.RemoveDubl_generated(inputText);
        }

        [Benchmark]
        public void CompiledReplace()
        {
            DublRegexReplace.RemoveDubl_compiled(inputText);
        }

        [Benchmark]
        public void DefaultReplace()
        {
            DublRegexReplace.RemoveDubl_default(inputText);
        }

        [Benchmark]
        public void GeneretedReplace2()
        {
            DublRegexReplace2.RemoveDubl_generated(inputText);
        }

        [Benchmark]
        public void CompiledReplace2()
        {
            DublRegexReplace2.RemoveDubl_compiled(inputText);
        }

        [Benchmark]
        public void DefaultReplace2()
        {
            DublRegexReplace2.RemoveDubl_default(inputText);
        }

    }
}