using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace BenchmarkTests
{
    public partial class DateRegex
    {
        [StringSyntax(StringSyntaxAttribute.Regex)]
        private const string _patern = @"\b\d{2}/\d{2}/\d{4}\b";

        [GeneratedRegex(_patern, RegexOptions.None)]
        private static partial Regex GetDateRegex();

        private static Regex _compiledRegex = new(_patern, RegexOptions.Compiled);

        private static Regex _defaultRegex = new(_patern);

        public static Match GenMatch(string text)
        {
            return GetDateRegex().Match(text);  
        }

        public static Match CompilMatch(string text)
        {
            return _compiledRegex.Match(text);
        }

        public static Match DefMatch(string text)
        {
            return _defaultRegex.Match(text);
        }

    }
}