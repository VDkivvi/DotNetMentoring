using FileFinder.Events;

namespace FileFinder.FilesExplorer
{
    public class FileSystemVisitor
    {
        public event EventHandler? FireState;
        private readonly CustomEvents _customEvents = new ();


        //just to try Queues and to not use recursion.
        public List<string> GetFileList(Func<string, bool> fileSearchPattern, string dirPath)
        {
            _customEvents.Notify_event(FireState, new CustomEventArgs("Starting search"));
            Console.WriteLine($"Searching in {dirPath}");
            Queue<string> pending = new();
            pending.Enqueue(dirPath);
            
            List<string> finalResult = new();
            while (pending.Count > 0)
            {
                dirPath = pending.Dequeue();
                using (var sequenceEnum = FindFile(dirPath))
                {
                    while (sequenceEnum.MoveNext())
                    {
                        if (!fileSearchPattern(sequenceEnum.Current)) continue;

                        var promptArgs = new PromptFileEventArgs(sequenceEnum.Current);
                        _customEvents.Prompt_event(FireState, promptArgs);
                           
                        if (!promptArgs.ExcludeFromSearch)
                            finalResult.Add(sequenceEnum.Current);
                        if (promptArgs.StopSearch)
                            break;
                    }
                }

                var dirs = Directory.GetDirectories(dirPath);
                foreach (var dir in dirs)
                {
                    pending.Enqueue(dir);
                }
            }

            _customEvents.Notify_event(FireState, new CustomEventArgs($"Finishing search. Found {finalResult.Count} results."));

            finalResult.ForEach(Console.WriteLine);
            return finalResult;
        }


        public static IEnumerator<string> FindFile(string dirPath)
        {
            var filesList = Directory.GetFiles(dirPath);
            foreach (var filePath in filesList)
            {
                yield return filePath;
            }
        }
    }
}
