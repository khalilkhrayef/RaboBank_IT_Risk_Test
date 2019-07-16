using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Test.Repository.WordFrequency;

namespace Test.Repository.WordFrequencyAnalyzer
{
    public class WordFrequencyAnalyzer : IWordFrequencyAnalyzer
    {

        /// <summary>
        /// This function to calculate the most highest repeated word in a sentence
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public int CalculateHighestFrequency(string text)
        {
            if (string.IsNullOrEmpty(text)) return 0;

            text = Regex.Replace(text, @"[^0-9a-zA-Z]+", " ");

            var sentenceSplit = text.ToLower().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> WordList = new Dictionary<string, int>();

            foreach (string item in sentenceSplit)
            {
                if (!WordList.ContainsKey(item))
                {
                    int wordCount = sentenceSplit.Where(x => x == item).ToList().Count();

                    WordList.Add(item, wordCount);
                }
            }

            int max = WordList.Values.Max();

            return max;
        }

        //public int CalculateHighestFrequency(string text)
        //{

        //    Dictionary<string, int> WordList = FillinDictionary(text);
        //    int max = WordList.Values.Max();
        //    return max;
        //}


        /// <summary>
        /// function to calculate the Frequency of a given word
        /// </summary>
        /// <param name="text"></param>
        /// <param name="word"></param>
        /// <returns></returns>
        public int CalculateFrequencyForWord(string text, string word)
        {
            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(word))

                return 0;

            Dictionary<string, int> wordList = FillinDictionary(text);

            return wordList[word.ToLower()];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="n"></param>
        /// <returns></returns>

        public IList<IWordFrequency> CalculateMostFrequentNWords(string text, int n)
        {

            if (n != 0 || !string.IsNullOrEmpty(text))
            {
                Dictionary<string, int> wordList = FillinDictionary(text);

                var ordered = wordList.OrderByDescending(w => w.Value).ThenBy(w => w.Key).Take(n);

                return ordered.Select(w => new WordFrequency.WordFrequency() { Word = w.Key, Frequency = w.Value }).Cast<IWordFrequency>().ToList();
            }
            return new List<IWordFrequency>();
           
        }

        /// <summary>
        /// a function to fillin the Dictionary
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private Dictionary<string,int> FillinDictionary(string text)
        {
            text = Regex.Replace(text, @"[^0-9a-zA-Z]+", " ");

            var sentenceSplit = text.ToLower().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, int> wordList = new Dictionary<string, int>();

            foreach (string w in sentenceSplit)
            {
                if (wordList.ContainsKey(w))
                {
                    ++wordList[w];
                }

                else
                {
                    wordList.Add(w, 1);
                }
            }
            return wordList;
        }
    }
}

