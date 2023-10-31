using System.Text.RegularExpressions;

namespace FileFinder.Filters
{
    internal class FileNameRegexFilter : FilterBase
    {
        internal FileNameRegexFilter(string pattern) : base(pattern) { }

        public override bool Filter(string fileName)
            => _pattern.IsMatch(fileName);
    }

    internal class WildCardFilter : FilterBase
    {
        internal WildCardFilter(string pattern) : base(pattern) 
        {
            _pattern = new Regex($"^{Regex.Escape(pattern).Replace("\\?", ".").Replace("\\*", ".*")}$");
        }

        public override bool Filter(string filepath)
            => _pattern.IsMatch(filepath);

    }
}
