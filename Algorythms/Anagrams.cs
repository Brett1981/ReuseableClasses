using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Re_useable_Classes.Algorythms
{
    internal class Anagrams
    {
        private const int MaxLength = 10;
        private const string FileName = "anagrams.txt";
        private const string InputFile = "enable1.txt";
        private Dictionary<string, List<string>> _dict;

        /// <summary>
        ///     Display all the anagrams for the parameter word.
        /// </summary>
        /// <param name="wordIn">The word you want to find anagrams for.</param>
        public void FindAnagramsFor(string wordIn)
        {
            string alpha = Alpha(wordIn);

            List<string> anagramList;
            if (!_dict.TryGetValue
                     (
                         alpha,
                         out anagramList))
            {
                return;
            }
            Console.WriteLine(wordIn + @":");
            foreach (string anagram in anagramList)
            {
                Console.WriteLine(@" " + anagram);
            }
        }

        /// <summary>
        ///     Read in the dictionary file to build the anagram data structure.
        /// </summary>
        public void ReadDictionary()
        {
            _dict = new Dictionary<string, List<string>>();

            using (var reader = new StreamReader(FileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(';');

                    List<string> localList;
                    if (_dict.TryGetValue
                        (
                            parts[0],
                            out localList))
                    {
                        localList.Add(parts[1]);
                    }
                    else
                    {
                        localList = new List<string>
                                    {
                                        parts[1]
                                    };
                        _dict.Add
                            (
                                parts[0],
                                localList);
                    }
                }
            }
        }

        /// <summary>
        ///     Write a file containing all the key/value anagram pairs.
        /// </summary>
        public void WriteDictionary()
        {
            if (File.Exists(FileName))
            {
                return;
            }

            var wordLists = new List<string>[MaxLength];
            for (int i = 0;
                 i < MaxLength;
                 i++)
            {
                wordLists[i] = new List<string>();
            }

            var alphaDictionary = new Dictionary<string, List<string>>();

            using (var reader = new StreamReader(InputFile))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    line = line.Trim();
                    if (line.Length >= MaxLength)
                    {
                        continue;
                    }

                    string alphaString = Alpha(line);
                    if (alphaDictionary.ContainsKey(alphaString))
                    {
                        bool found = alphaDictionary[alphaString].Any(lineThere => lineThere == line);
                        if (found == false)
                        {
                            alphaDictionary[alphaString].Add(line);
                        }
                    }
                    else
                    {
                        alphaDictionary.Add
                            (
                                alphaString,
                                new List<string>());
                        alphaDictionary[alphaString].Add(line);
                        wordLists[alphaString.Length].Add(alphaString);
                    }
                }
            }

            using (var writer = new StreamWriter(FileName))
            {
                var alphaList = new List<string>(alphaDictionary.Keys);
                alphaList.Sort();

                foreach (string alpha in alphaList)
                {
                    List<string> actualWords = alphaDictionary[alpha];

                    foreach (string realWord in actualWords)
                    {
                        writer.WriteLine(alpha + ";" + realWord);
                    }
                }
            }
        }

        /// <summary>
        ///     Alphabetize the word received as a parameter. This will create
        ///     a key from the word that is always the same for words with
        ///     equal letter frequencies.
        /// </summary>
        /// <param name="wordIn">The word you need to alphabetize.</param>
        /// <returns>The alphabetized string.</returns>
        private static string Alpha(string wordIn)
        {
            char[] arr = wordIn.ToCharArray();
            Array.Sort(arr);
            return new string(arr);
        }
    }
}
