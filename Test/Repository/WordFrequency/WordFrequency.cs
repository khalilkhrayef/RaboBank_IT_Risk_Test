﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Repository.WordFrequency
{
    public class WordFrequency : IWordFrequency
    {
        public string Word { get; set; }
        public int Frequency { get; set; }

        public override string ToString()
        {
            return $"(Word: {Word} Frequency: {Frequency})";
        }
    }
}
