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

            var path = (args.Length > 0) ? args[0] : @"c:\Users\Valeriia_Danilova\source\repos\Mentoring\DotNet\Task4\Task1\";
            var filterPattern = (args.Length > 1) ? args[1] : @".*\.cs$";


            visitor.GetFileList(new FileNameRegexFilter(filterPattern), path);
        }
    }
}