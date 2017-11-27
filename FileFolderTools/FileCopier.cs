using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace Re_useable_Classes.FileFolderTools
{
    public static class FileCopier
    {
        public static bool Filecopy
            (
            string fromLocation,
            string toLocation,
            string fileName,
            bool overwriteExisting)
        {
            var sourceDir = fromLocation;
            var targetDir = toLocation;
            foreach (var file in Directory.GetFiles(sourceDir))
                if (file != null)
                {
                    if (Path.GetFileName(file) == fileName)
                    {
                        File.Copy
                            (
                                file,
                                Path.Combine
                                    (
                                        targetDir,
                                        Path.GetFileName(file)),
                                overwriteExisting);
                    }
                    else
                    {
                        fromLocation = "";
                        toLocation = "";
                        fileName = "";
                        File.Copy
                        (
                            file,
                            Path.Combine
                                (
                                    targetDir,
                                    Path.GetFileName(file)),
                            overwriteExisting);
                    }
                }
            return false;
        }
    }
}
