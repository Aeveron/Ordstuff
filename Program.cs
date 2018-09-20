
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Xml.Schema;

namespace OrdStuff
{
    class Program
    {
        private static readonly Random Random = new Random();

        static void Main(string[] args)
        {
            var allLines = File.ReadAllLines(@"ordliste.txt");
            var lastWord = string.Empty;
            var words = WordListArray(allLines, lastWord);             
            var randomWordIndex = Random.Next(words.Length);

            var word1 = words[randomWordIndex];
            var lastWordIndex = string.Empty;
            //Console.WriteLine(word1);

            var ending = word1.Substring(randomWordIndex, words[0].Length - 3);

            Console.WriteLine(ending);
            var x = 3;
            //foreach (var word in words)
            //{
            //    var compareWordAndRandomWord = word.Substring(randomWord, 3);
            //    if (!word.StartsWith) continue;
            //    Console.WriteLine(word);
            //    Console.WriteLine(randomWord);
            //}

        }

        private static string[] WordListArray(string[] allLines, string lastWord)
        {
            var wordList = new List<string>();
            foreach (var line in allLines)
            {
                var parts = line.Split('\t');
                var word = parts[1];

                if (word != lastWord && word.Length > 7 && word.Length < 11 && !word.Contains('-'))
                {
                    wordList.Add(word);
                    //Console.WriteLine(word);

                }

                lastWord = word;
            }

            return wordList.ToArray();
        }
    }
}
