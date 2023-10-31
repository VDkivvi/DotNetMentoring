using System.Text.RegularExpressions;

namespace FileFinder.Filters
{
    public abstract class FilterBase
    {
        protected Regex _pattern;

        public FilterBase(string pattern) {
            _pattern = new Regex(pattern);
        }

        public abstract bool Filter(string filePath);
    }
}
