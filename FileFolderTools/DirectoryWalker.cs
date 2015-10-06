/*
 * DirectoryWalker.cs
 * 
 * Some functions for getting lists (arrays) of file names from directories
 * and subdirectories. Recursive directory finding based on a single folder.
 * Useful for import code, etc.
 * 
 * */

using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Re_useable_Classes.FileFolderTools
{
    /// <summary>
    ///     Error codes for the Directory Walker.
    /// </summary>
    internal enum ImportErrorCode
    {
        None = 0,
        TooManyFiles = 1,
        GeneralError = 2
    };

    /// <summary>
    ///     An object that is capable of exploring a tree of directories. Contains
    ///     methods for both getting all directories and exploring them, and getting
    ///     all files at a directory.
    /// </summary>
    internal class DirectoryWalker
    {
        /// <summary>
        ///     The maximum number of files it can encounter before giving up.
        /// </summary>
        private const int MaxFileNumber = 100000;

        /// <summary>
        ///     Where it stores the file names.
        /// </summary>
        private readonly List<string> _fileList = new List<string>();

        /// <summary>
        ///     The error code that corresponds to the failure type.
        /// </summary>
        private ImportErrorCode _errorCode;

        /// <summary>
        ///     A list storing all the file names found in subdirectories.
        /// </summary>
        public List<string> FileList
        {
            get { return _fileList; }
        }

        /// <summary>
        ///     The public error code. Use this to see why the walker failed (or if it didn't).
        /// </summary>
        public ImportErrorCode ErrorCode
        {
            get { return _errorCode; }
        }

        /// <summary>
        ///     Start walking directories beginning at the parameter directory. Will
        ///     match all files of all types.
        /// </summary>
        /// <param name="baseDir">Where to start recursing from.</param>
        public void WalkDirectories(string baseDir)
        {
            WalkDirectories
                (
                    baseDir,
                    "*.*");
        }

        /// <summary>
        ///     Begin walking subdirectories starting at the parameter directory. Filter
        ///     all file results by the file filter string.
        /// </summary>
        /// <param name="baseDir">Directory to begin in.</param>
        /// <param name="fileFilter">A standard file filter string (such as *.*).</param>
        public void WalkDirectories
            (
            string baseDir,
            string fileFilter)
        {
            try
            {
                WalkFiles
                    (
                        baseDir,
                        fileFilter);
                if (_errorCode == ImportErrorCode.None)
                {
                    foreach (string dirName in Directory.GetDirectories(baseDir))
                    {
                        WalkDirectories
                            (
                                dirName,
                                fileFilter);
                        if (_errorCode != ImportErrorCode.None)
                        {
                            break;
                        }
                    }
                }
            }
            catch (IOException)
            {
                _errorCode = ImportErrorCode.GeneralError;
            }
        }

        /// <summary>
        ///     Get all files at this directory. (Can be used publicly or privately.)
        /// </summary>
        /// <param name="baseDir">Start walking at this directory.</param>
        public void WalkFiles(string baseDir)
        {
            WalkFiles
                (
                    baseDir,
                    "*.*");
        }

        /// <summary>
        ///     Get all files at this directory. Matches all files according to the filter
        ///     passed in.
        /// </summary>
        /// <param name="baseDir">Start at this directory.</param>
        /// <param name="fileFilter">Use this filter.</param>
        public void WalkFiles
            (
            string baseDir,
            string fileFilter)
        {
            foreach (string fileName in Directory.GetFiles
                (
                    baseDir,
                    fileFilter))
            {
                if (_fileList.Count >= MaxFileNumber)
                {
                    _errorCode = ImportErrorCode.TooManyFiles;
                    return;
                }
                _fileList.Add(fileName);
                Debug.WriteLine(fileName);
            }
            _errorCode = (_fileList.Count >= MaxFileNumber)
                             ? ImportErrorCode.TooManyFiles
                             : ImportErrorCode.None;
        }
    }
}
