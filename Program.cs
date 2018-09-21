
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

            var randomWord = words[randomWordIndex];
            var lastWordIndex = string.Empty;
            var wordCounter = 200;
            

            var ending = randomWord.Substring(randomWord.Length -4);




            Console.WriteLine(randomWord);
            Console.WriteLine(ending);

            for (int i = 0; i < words.Length; i++)
            {
                if (CompareWordStartAndEnding(randomWord, words[i]))
                {
                    Console.WriteLine("\n" + words[i]);
                    return;
                }
            }
            

            //foreach (var word in words)
            //{
            //    var compareWordAndRandomWord = word.Substring(randomWord, 3);
            //    if (!word.StartsWith) continue;
            //    Console.WriteLine(word);
            //    Console.WriteLine(randomWord);
            //}

        }

        private static bool CompareWordStartAndEnding(string word1, string word2)
        {
            return CompareWordStartAndEnding(4, word1, word2)
                || CompareWordStartAndEnding(5, word1, word2)
                || CompareWordStartAndEnding(6, word1, word2);

        }

        private static bool CompareWordStartAndEnding(int commonlength, string word1, string word2)
        {
            var lastPartOfFirstWord = word1.Substring(word1.Length - commonlength, commonlength);
            var firstPartOfSecondWord = word2.Substring(0, commonlength);

            return lastPartOfFirstWord == firstPartOfSecondWord;
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
