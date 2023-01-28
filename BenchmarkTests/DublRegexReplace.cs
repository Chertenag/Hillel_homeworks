using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace BenchmarkTests
{
    public partial class DublRegexReplace
    {
        [StringSyntax(StringSyntaxAttribute.Regex)]
        private const string _pattern = @"\b(?<dubl1>\w+)\b(?<dubl2>\s\b\<dubl1>)\b";

        [GeneratedRegex(_pattern, RegexOptions.IgnoreCase)]
        private static partial Regex GeneratedRegex();

        private static Regex _compiledRegex = new(_pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
        
        private static Regex _defaultRegex = new(_pattern, RegexOptions.IgnoreCase);

        public static string RemoveDubl_generated(string inputText)
        {
            return GeneratedRegex().Replace(inputText, "${dubl1}");
        }
        public static string RemoveDubl_compiled(string inputText)
        {
            return _compiledRegex.Replace(inputText, "${dubl1}");
        }
        public static string RemoveDubl_default(string inputText)
        {
            return _defaultRegex.Replace(inputText, "${dubl1}");
        }
    }
    public partial class DublRegexReplace2
    {
        [StringSyntax(StringSyntaxAttribute.Regex)]
        private const string _pattern = @"(?<dubl1>\w+)(?<dubl2>\s\<dubl1>)";

        [GeneratedRegex(_pattern, RegexOptions.IgnoreCase)]
        private static partial Regex GeneratedRegex();

        private static Regex _compiledRegex = new(_pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);

        private static Regex _defaultRegex = new(_pattern, RegexOptions.IgnoreCase);

        public static string RemoveDubl_generated(string inputText)
        {
            return GeneratedRegex().Replace(inputText, "${dubl1}");
        }
        public static string RemoveDubl_compiled(string inputText)
        {
            return _compiledRegex.Replace(inputText, "${dubl1}");
        }
        public static string RemoveDubl_default(string inputText)
        {
            return _defaultRegex.Replace(inputText, "${dubl1}");
        }
    }
}