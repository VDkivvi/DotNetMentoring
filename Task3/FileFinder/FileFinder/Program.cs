using FileFinder.FilesExplorer;
using FileFinder.Filters;

namespace FileFinder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var visitor = new FileSystemVisitor();
            visitor.FireState += (_, _) => { };

            var path = (args.Length > 0) ? args[0] : @"c:\\Projects\\source\\repos\\Mentoring\\DotNet\\Task4\\FileFinder\\FileFinder\\";
            var filterPattern = (args.Length > 1) ? args[1] : @".*\.cs$";


            visitor.GetFileList(f => new FileFilter(f).FileNameByRegex(filterPattern), path);
        }
    }
}