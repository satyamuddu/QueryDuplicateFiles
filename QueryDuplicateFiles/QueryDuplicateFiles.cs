using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryDuplicateFiles
{
    public class QueryDuplicateFiles
    {
        public static string startFolder;
        public static string extension = "*";
        public static IEnumerable<IEnumerable<IEnumerable<string>>> QueryDuplicatesByFileName()
        {
            // Make the the lines shorter for the console display
            int charsToSkip = startFolder.Length;

            // Take a snapshot of the file system.
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(startFolder);
            IEnumerable<System.IO.FileInfo> fileList = dir.GetFiles(extension, System.IO.SearchOption.AllDirectories);
            IEnumerable<IGrouping<QueryByFileName, string>> queryDupFiles = LinqQuery<QueryByFileName>(fileList);

            var list = queryDupFiles.ToList();

            int i = queryDupFiles.Count();

            yield return PageOutput<QueryByFileName, string>(queryDupFiles);
        }

        private static IEnumerable<IGrouping<T, string>> LinqQuery<T>(IEnumerable<System.IO.FileInfo> fileList)
        {
            var queryDupFiles =
                            from file in fileList
                            group file.FullName by
                            //group file.FullName.Substring(charsToSkip) by
                            new QueryByFileNameAndLength { Name = file.Name } into fileGroup
                            where fileGroup.Count() > 1
                            select fileGroup;
            return (IEnumerable<IGrouping<T, string>>)queryDupFiles;
        }

        public static IEnumerable<IEnumerable<IEnumerable<string>>> QueryDuplicatesByFileNameAndLength()
        {
            if (String.IsNullOrEmpty(startFolder))
            {
                yield break;
            }
            // Make the the lines shorter for the console display
            int charsToSkip = startFolder.Length;
            //startFolder = @"C:\Users\212486177\Pictures";
            // Take a snapshot of the file system.
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(startFolder);
            IEnumerable<System.IO.FileInfo> fileList = dir.GetFiles(extension, System.IO.SearchOption.AllDirectories);


            IEnumerable<IGrouping<QueryByFileNameAndLength, string>> queryDupFiles = LinqQuery<QueryByFileNameAndLength>(fileList);


            var queryDupFiles2 =
                from file in fileList
                group file.FullName.Substring(charsToSkip) by
                new QueryByFileNameAndLength { Name = file.Name, Length = file.Length } into fileGroup
                where fileGroup.Count() > 1
                select fileGroup;

            var list = queryDupFiles.ToList();

            int i = queryDupFiles.Count();

            yield return PageOutput<QueryByFileNameAndLength, string>(queryDupFiles);
        }
        public static IEnumerable<IEnumerable<IEnumerable<string>>> QueryDuplicatesByFileNameAndLengthAndCreationTime()
        {
            // Make the the lines shorter for the console display
            int charsToSkip = startFolder.Length;

            // Take a snapshot of the file system.
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(startFolder);
            IEnumerable<System.IO.FileInfo> fileList = dir.GetFiles(extension, System.IO.SearchOption.AllDirectories);
            IEnumerable<IGrouping<QueryByFileNameAnddLengthAndCreationDate, string>> queryDupFiles = LinqQuery<QueryByFileNameAnddLengthAndCreationDate>(fileList);

            //var queryDupFiles =
            //    from file in fileList
            //    group file.FullName.Substring(charsToSkip) by
            //    new QueryByFileNameAnddLengthAndCreationDate { Name = file.Name, Length=file.Length, CreationTime=file.CreationTime } into fileGroup
            //    where fileGroup.Count() > 1
            //    select fileGroup;

            var list = queryDupFiles.ToList();

            int i = queryDupFiles.Count();

            yield return PageOutput<QueryByFileNameAnddLengthAndCreationDate, string>(queryDupFiles);
        }
        // A generic method to page the output of the QueryDuplications methods
        // Here the type of the group must be specified explicitly. "var" cannot
        // be used in method signatures. This method does not display more than one
        // group per page.
        private static IEnumerable<IEnumerable<V>> PageOutput<K, V>(IEnumerable<System.Linq.IGrouping<K, V>> groupByExtList)
        {
            // Flag to break out of paging loop.
            bool goAgain = true;

            // "3" = 1 line for extension + 1 for "Press any key" + 1 for input cursor.
            int numLines = 5;

            // Iterate through the outer collection of groups.
            foreach (var filegroup in groupByExtList)
            {
                // Start a new extension at the top of a page.
                int currentLine = 0;

                // Output only as many lines of the current group as will fit in the window.
                do
                {
                    //Console.Clear();
                    //Console.WriteLine("Filename = {0}", filegroup.Key.ToString() == String.Empty ? "[none]" : filegroup.Key.ToString());

                    // Get 'numLines' number of items starting at number 'currentLine'.
                    var resultPage = filegroup.Skip(currentLine).Take(numLines);

                    //QueryResultByPage(resultPage);
                    yield return resultPage;
                    // Increment the line counter.
                    currentLine += numLines;

                    // Give the user a chance to escape.
                    //Console.WriteLine("Press any key to continue or the 'End' key to break...");
                    //ConsoleKey key = Console.ReadKey().Key;
                    //if (key == ConsoleKey.End)
                    //{
                    //    goAgain = false;
                    //    break;
                    //}
                } while (currentLine < filegroup.Count());

                if (goAgain == false)
                    break;
            }
        }

        private static void QueryResultByPage<V>(IEnumerable<V> resultPage)
        {
            //Execute the resultPage query
            foreach (var fileName in resultPage)
            {
                Console.WriteLine("\t{0}", fileName);
            }
        }
    }
}
