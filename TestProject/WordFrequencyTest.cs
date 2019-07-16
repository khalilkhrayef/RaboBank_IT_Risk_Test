using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Repository.WordFrequency;
using Test.Repository.WordFrequencyAnalyzer;

namespace TestProject
{
    [TestFixture]
    public class WordFrequencyTest
    {
        [Test]
        public void given_Empty_String()
        {
            WordFrequencyAnalyzer WordFr = new WordFrequencyAnalyzer();

            Assert.That(WordFr.CalculateHighestFrequency(""), Is.EqualTo(0), "You give an empty Entry");
        }


        [Test]

        public void given_text_with_repeated_THE()
        {
            WordFrequencyAnalyzer WordFr = new WordFrequencyAnalyzer();

            Assert.That(WordFr.CalculateHighestFrequency("The sun is the most beautiful thing in the world"), Is.EqualTo(3), "the Word THE repeated 3 times");
        }

        [Test]
        public void given_text_with_repeated_THE_with_special_characters()
        {
            WordFrequencyAnalyzer WordFr = new WordFrequencyAnalyzer();

            Assert.That(WordFr.CalculateHighestFrequency("The sun; ; ; ; is, the most, beautiful; thing in the world"), Is.EqualTo(3), "the Word THE repeated 3 times");
        }

        [Test]
        public void given_empty_text_and_word()
        {
            WordFrequencyAnalyzer WordFr = new WordFrequencyAnalyzer();

            Assert.That(WordFr.CalculateFrequencyForWord("", ""), Is.EqualTo(0), "You give an empty Entries");
        }

        [Test]
        public void given_text_and_specific_word()
        {
            WordFrequencyAnalyzer WordFr = new WordFrequencyAnalyzer();

            Assert.That(WordFr.CalculateFrequencyForWord("The sun is the most beautiful thing in the world", "the"), Is.EqualTo(3), "the Word THE repeated 3 times");
        }


        [Test]
        public void given_text_and_specific_word_with_special_characters()
        {
            WordFrequencyAnalyzer WordFr = new WordFrequencyAnalyzer();

            Assert.That(WordFr.CalculateFrequencyForWord("The sun; ; ; ; is, the most, beautiful; thing in the world", "the"), Is.EqualTo(3), "the Word THE repeated 3 times");
        }

        [Test]
        public void given_empty_text_and_Nword()
        {
            WordFrequencyAnalyzer WordFr = new WordFrequencyAnalyzer();

            Assert.That(WordFr.CalculateMostFrequentNWords(" ", 0), Is.EqualTo(new List<IWordFrequency>()), "You give an empty Entries");
        }

        [Test]
        public void given_text_and_Nword()
        {
            WordFrequencyAnalyzer WordFr = new WordFrequencyAnalyzer();

            var output = WordFr.CalculateMostFrequentNWords("the sun is the most beautiful thing in the world because the sun is a source of happiness where it is shining in the day ",2).ToList();
            var expected = new List<IWordFrequency>()
            {
                new WordFrequency { Word = "the", Frequency = 5 },
                new WordFrequency{ Word = "is", Frequency = 3 }
            };

            bool isGood = true;

            for(int i = 0; i < Math.Min(output.Count,expected.Count); ++i)
            {
                if (output[i].Word != expected[i].Word || output[i].Frequency != expected[i].Frequency)
                {
                    isGood = false;
                    break;
                }
            }

            Assert.That(isGood);

        }

    }
}
