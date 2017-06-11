using RainyTool.ClassLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RainyTool.ClassLib.FileHelper
{
    public class FileManager
    {
        public static IEnumerable<String> GetAllFilesInDirectory(
            String i_initialPath,
            String i_searchPattern
            )
        {
            var files = new List<String>();

            foreach (var directory in Directory.GetDirectories(i_initialPath, "*", SearchOption.AllDirectories))
            {
                foreach (var file in Directory.GetFiles(directory, i_searchPattern, SearchOption.AllDirectories))
                {
                    files.Add(file);
                }
            }

            return files;
        }

        public static String UpdateFileNameByPattern(
            String i_source,
            String i_matchPattern,
            String i_newPattern
            )
        {
            var regex = new Regex(i_matchPattern);

            if (regex.IsMatch(i_source))
            {
                var result = regex.Replace(i_source, i_newPattern);

                return result;
            }
            else
            {
                throw new ArgumentException(String.Format("Input:{0} is unmatched with {1}", i_source, i_matchPattern));
            }
        }

        private static void DoAction(
            RenameFileArgument i_renameFileArgument,
            String i_fileName,
            String i_targetFileName,
            Int32 i_index,
            Int32 i_total
            )
        {
            if (i_renameFileArgument.Action != null)
            {
                i_renameFileArgument.Action(i_fileName, i_targetFileName, i_index, i_total);
            }
        }

        public static void RenameFileNameByBatch(
           RenameFileArgument i_renameFileArgument
            )
        {
            const String FailedToRename = "Unable to rename, please handle it manually."; 

            var totalFileNumber = i_renameFileArgument.Files.Count();
            var files = i_renameFileArgument.Files;

            var index = 0;

            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);

                var directoryName = fileInfo.DirectoryName;

                var fileName = fileInfo.Name;

                var updatedFileName = String.Empty;

                try
                {
                    index++;

                    updatedFileName = UpdateFileNameByPattern(
                        fileName, i_renameFileArgument.MatchPattern, i_renameFileArgument.ReplacePattern);

                    var newFileName = Path.Combine(directoryName, updatedFileName);

                    fileInfo.MoveTo(newFileName);

                    DoAction(i_renameFileArgument, file, updatedFileName, index, totalFileNumber);
                }
                catch (Exception)
                {
                    if (i_renameFileArgument.ContinueIfFailed)
                    {
                        DoAction(i_renameFileArgument, file, FailedToRename, index, totalFileNumber);
                    }
                    else
                    {
                        return ;
                    }
                }
            }
        }
    }
}

