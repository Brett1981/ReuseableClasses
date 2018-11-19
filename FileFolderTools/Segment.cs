/*
 * Segment.cs
 *
 * A C-Sharp program to divide a file of any number of lines (ending with newline
 * characters) and output segmented files of up to X bytes each. Use as a static
 * class in your project for maximum convenience.
 *
 * */

using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Re_useable_Classes.FileFolderTools
{
    internal static class Segment
    {
        /// <summary>
        ///     The number of bytes in a kibibyte.
        /// </summary>
        private const int Kibibyte = 1024;

        /// <summary>
        ///     Number of bytes in 2 megabytes.
        /// </summary>
        private const int _1Mb = 1 * 1000 * Kibibyte;

        /// <summary>
        ///     Write segments of a file by calling this function with the file name
        ///     and the prefix you want the output files to have.
        /// </summary>
        /// <param name="inFile">The file name you want to segment.</param>
        /// <param name="outPrefix">The prefix you want the segments to have in their names.</param>
        public static void WriteSegments
            (
            string inFile,
            string outPrefix)
        {
            var lines = new List<string>();
            var reader = new StreamReader(inFile);

            // consume in file
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                lines.Add(line);
            }

            reader.Dispose();

            // running total is the size in bytes of the file currently being written.
            int runningTotal = 0;

            // the prefix string to each output file
            string baseFileName = outPrefix + "_";

            // the current number of the output file
            int fileNum = 0;

            // open the new file
            var writer = new StreamWriter
                (
                FileName
                    (
                        baseFileName,
                        fileNum));

            // now, count chars up to 2000.
            for (int i = 0;
                 i < lines.Count;
                 i++)
            {
                int length = lines[i].Length;
                string thisLine = lines[i];

                // see if we need to make a new file to write this line.
                if (runningTotal + length >= _1Mb)
                {
                    if (length >= _1Mb)
                    {
                        Debug.Fail("Single line longer than output file size required.");
                    }

                    // now on new file
                    fileNum++;

                    // now down to 0 for total.
                    runningTotal = 0;

                    // finish up with last file.
                    writer.Dispose();

                    // make new file
                    writer = new StreamWriter
                        (
                        FileName
                            (
                                baseFileName,
                                fileNum));

                    //Console.WriteLine("Writing " + FileName(baseFileName, fileNum));
                }

                // simply write to current file.
                writer.WriteLine(thisLine);
                runningTotal += length;
            }

            writer.Dispose();
        }

        /// <summary>
        ///     Programatically determine the filename of the segmented file we are
        ///     going to create and build.
        /// </summary>
        /// <param name="baseFileName">The prefix to the file you want.</param>
        /// <param name="fileNum">The number of the file you are creating.</param>
        /// <returns>The new filename string.</returns>
        private static string FileName
            (
            string baseFileName,
            int fileNum)
        {
            return baseFileName + fileNum.ToString("00") + ".txt";
        }
    }
}