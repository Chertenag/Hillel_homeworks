using BenchmarkDotNet.Attributes;

namespace Hillel_hw_7
{
    public class StringBuilderVSString_benchmark_50_100_200
    {
        private List<string> _stringList = RandomStringRowsGenerator.Generate(50, 100, 200);

        [Benchmark]
        public void StringPlusStringPlus()
        {
            StringBuilderVSString.StringPlusStringPlus_50rows(_stringList);
        }

        [Benchmark]
        public void StringPlusInCycle()
        {
            StringBuilderVSString.StringPlusInCycle(_stringList);
        }

        [Benchmark]
        public void StringBuilderAppendInCycle()
        {
            StringBuilderVSString.StringBuilderAppendInCycle(_stringList);
        }

        [Benchmark]
        public void StringContactListToArray()
        {
            StringBuilderVSString.StringContactListToArray(_stringList);
        }

        [Benchmark]
        public void StringJoinListToArray()
        {
            StringBuilderVSString.StringJoinListToArray(_stringList);
        }

    }

    public class StringBuilderVSString_benchmark_50_2500_3000
    {
        private List<string> _stringList = RandomStringRowsGenerator.Generate(50, 2000, 3000);

        [Benchmark]
        public void StringPlusStringPlus()
        {
            StringBuilderVSString.StringPlusStringPlus_50rows(_stringList);
        }

        [Benchmark]
        public void StringPlusInCycle()
        {
            StringBuilderVSString.StringPlusInCycle(_stringList);
        }

        [Benchmark]
        public void StringBuilderAppendInCycle()
        {
            StringBuilderVSString.StringBuilderAppendInCycle(_stringList);
        }

        [Benchmark]
        public void StringContactListToArray()
        {
            StringBuilderVSString.StringContactListToArray(_stringList);
        }

        [Benchmark]
        public void StringJoinListToArray()
        {
            StringBuilderVSString.StringJoinListToArray(_stringList);
        }
    }

    public class StringBuilderVSString_benchmark_100_100_200
    {
        private List<string> _stringList = RandomStringRowsGenerator.Generate(100, 100, 200);

        [Benchmark]
        public void StringPlusStringPlus()
        {
            StringBuilderVSString.StringPlusStringPlus_100rows(_stringList);
        }

        [Benchmark]
        public void StringPlusInCycle()
        {
            StringBuilderVSString.StringPlusInCycle(_stringList);
        }

        [Benchmark]
        public void StringBuilderAppendInCycle()
        {
            StringBuilderVSString.StringBuilderAppendInCycle(_stringList);
        }

        [Benchmark]
        public void StringContactListToArray()
        {
            StringBuilderVSString.StringContactListToArray(_stringList);
        }

        [Benchmark]
        public void StringJoinListToArray()
        {
            StringBuilderVSString.StringJoinListToArray(_stringList);
        }

    }

    public class StringBuilderVSString_benchmark_100_2500_3000
    {
        private List<string> _stringList = RandomStringRowsGenerator.Generate(100, 2000, 3000);

        [Benchmark]
        public void StringPlusStringPlus()
        {
            StringBuilderVSString.StringPlusStringPlus_100rows(_stringList);
        }

        [Benchmark]
        public void StringPlusInCycle()
        {
            StringBuilderVSString.StringPlusInCycle(_stringList);
        }

        [Benchmark]
        public void StringBuilderAppendInCycle()
        {
            StringBuilderVSString.StringBuilderAppendInCycle(_stringList);
        }

        [Benchmark]
        public void StringContactListToArray()
        {
            StringBuilderVSString.StringContactListToArray(_stringList);
        }

        [Benchmark]
        public void StringJoinListToArray()
        {
            StringBuilderVSString.StringJoinListToArray(_stringList);
        }

    }

    public class StringBuilderVSString_benchmark_500_100_200
    {
        private List<string> _stringList = RandomStringRowsGenerator.Generate(500, 100, 200);

        [Benchmark]
        public void StringPlusInCycle()
        {
            StringBuilderVSString.StringPlusInCycle(_stringList);
        }

        [Benchmark]
        public void StringBuilderAppendInCycle()
        {
            StringBuilderVSString.StringBuilderAppendInCycle(_stringList);
        }

        [Benchmark]
        public void StringContactListToArray()
        {
            StringBuilderVSString.StringContactListToArray(_stringList);
        }

        [Benchmark]
        public void StringJoinListToArray()
        {
            StringBuilderVSString.StringJoinListToArray(_stringList);
        }

    }

    public class StringBuilderVSString_benchmark_500_2500_3000
    {
        private List<string> _stringList = RandomStringRowsGenerator.Generate(500, 2500, 3000);

        [Benchmark]
        public void StringPlusInCycle()
        {
            StringBuilderVSString.StringPlusInCycle(_stringList);
        }

        [Benchmark]
        public void StringBuilderAppendInCycle()
        {
            StringBuilderVSString.StringBuilderAppendInCycle(_stringList);
        }

        [Benchmark]
        public void StringContactListToArray()
        {
            StringBuilderVSString.StringContactListToArray(_stringList);
        }

        [Benchmark]
        public void StringJoinListToArray()
        {
            StringBuilderVSString.StringJoinListToArray(_stringList);
        }

    }
}
