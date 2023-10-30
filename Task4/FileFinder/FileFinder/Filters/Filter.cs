using System.Text.RegularExpressions;

namespace FileFinder.Filters
{
    internal class FileFilter
    {
        readonly string _fileName;
        readonly string _fileDir;
        readonly string _filePath;

        internal FileFilter(string filePath)
        {
            _fileName = Path.GetFileName(filePath.Trim());
            _fileDir = Path.GetDirectoryName(filePath.Trim());
            _filePath = filePath;
        }

        public bool FileNameByRegex(string pattern)
            => new Regex(pattern).IsMatch(_fileName);

        public bool FileNameStartsWith(string pattern)
            => _fileName.StartsWith(pattern);

        public bool FileDirByRegex(string pattern)
            => new Regex(pattern).IsMatch(_fileDir);

        public bool FullPathByRegex(string pattern)
            => new Regex(pattern).IsMatch(_filePath);

    }
}
