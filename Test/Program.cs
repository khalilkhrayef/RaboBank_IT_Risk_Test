using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Repository.WordFrequencyAnalyzer;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            WordFrequencyAnalyzer Workf = new WordFrequencyAnalyzer();
             string s1;
            Console.Write("Enter a sentence: ");
            s1 = Console.ReadLine();
            Workf.CalculateHighestFrequency(s1);
            Console.WriteLine();
            Console.ReadLine();


            Console.Write("Choose your word: ");

            Console.WriteLine(Workf.CalculateFrequencyForWord(s1, Console.ReadLine()));


            Console.Write("Choose n: ");

            string s3 = Console.ReadLine();

            var items = Workf.CalculateMostFrequentNWords(s1, Convert.ToInt32(s3));

            foreach (var item in items)
                Console.WriteLine(item);
        }
    }
}
