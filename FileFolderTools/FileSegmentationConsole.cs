/*
 * FileSegmentationConsole.cs
 * 
 * A C-Sharp program to divide a file of any number of lines (ending with newline
 * characters) and output segmented files of up to X bytes each.
 * 
 * */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Re_useable_Classes.FileFolderTools
{
    /// <summary>
    ///     This program reads in files containing any number of lines (separated by newline characters)
    ///     and then breaks up the lines into sequential, segmented files containing up to a certain number
    ///     of total bytes. Thus, if you have to upload a 20 MB CSV file to a server, but it only takes
    ///     files of X megabytes, this program can divide your CSV file into 10, two-megabyte files without
    ///     data loss.
    ///     Note that you are on your own if you have non-English, Unicode characters, or other complex
    ///     requirements. If a single line is longer than the maximum segment size, it will fail.
    ///     I think the easiest way to run console apps in Windows is to simply put your input file in the
    ///     same folder as the application (FileSegmentationConsole.exe) and then rename it so that the
    ///     program will find it, and then double-click on it.
    /// </summary>
    public class FileSegmentationConsole
    {
        /// <summary>
        ///     The number of bytes in a kibibyte.
        /// </summary>
        private const int Kibibyte = 1024;

        /// <summary>
        ///     Number of bytes in 2 megabytes.
        /// </summary>
        private const int _2Mb = 2*1000*Kibibyte;

        /// <summary>
        ///     Begin the SegmentFile program. Pass this program the file name of a file of lines that
        ///     you wish to be divided into smaller files of a certain size. The result will be X files
        ///     of less than or equal to 2 megabytes. Exact numbers can be configured within the code.
        ///     The program will yield files named "out_NN.txt" where NN is the number of the file in
        ///     the result series.
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            // get the file name passed in, or just use the default "def_file.txt"
            string inFile = null;
            inFile = args.Length == 0
                         ? "def_file.txt"
                         : args[0];

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
            const string baseFileName = "out_";

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
            foreach (string t in lines)
            {
                int length = t.Length;
                string thisLine = t;

                // see if we need to make a new file to write this line.
                if (runningTotal + length >= _2Mb) // 2 mibibytes
                {
                    if (length >= _2Mb)
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

                    Console.WriteLine
                        (
                            @"Writing " + FileName
                                              (
                                                  baseFileName,
                                                  fileNum));
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
