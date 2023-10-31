using FileFinder.Events;
using FileFinder.Filters;

namespace FileFinder.FilesExplorer
{
    public class FileSystemVisitor
    {
        public event EventHandler? FireState;
        private readonly CustomEvents _customEvents = new ();


        //just to try Queues and to not use recursion.
        public List<string> GetFileList(FilterBase fileSearchPattern, string dirPath)
        {
            _customEvents.Notify_event(FireState, 
                new ConsoleNotifyEventArgs($"Starting search in directory {dirPath}"));

            Queue<string> pending = new();
            var promptArgs = new PromptFileEventArgs();
            List<string> finalResult = new();

            pending.Enqueue(dirPath);
            while (pending.Count > 0)
            {
                dirPath = pending.Dequeue();
                using (var sequenceEnum = FindFile(dirPath))
                {
                    while (sequenceEnum.MoveNext())
                    {
                        if (sequenceEnum.Current == null) continue;
                        if (!fileSearchPattern.Filter(sequenceEnum.Current)) continue;

                        promptArgs.File = sequenceEnum.Current;
                        _customEvents.Prompt_event(FireState, promptArgs);
                           
                        if (!promptArgs.ExcludeFromSearch)
                            finalResult.Add(sequenceEnum.Current);

                        if (promptArgs.StopSearch)
                            break;
                    }
                }

                if (promptArgs.StopSearch)
                    break;

                var dirs = Directory.GetDirectories(dirPath);
                foreach (var dir in dirs)
                {
                    pending.Enqueue(dir);
                }
            }

            _customEvents.Notify_event(FireState, 
                new ConsoleNotifyEventArgs($"Finishing search. Found {finalResult.Count} results.\n{string.Join("\n", finalResult)}"));

            return finalResult;
        }


        public static IEnumerator<string?> FindFile(string dirPath)
        {
            string?[] filesList = Directory.GetFiles(dirPath);
            foreach (var filePath in filesList)
            {
                yield return filePath;
            }
        }
    }
}
