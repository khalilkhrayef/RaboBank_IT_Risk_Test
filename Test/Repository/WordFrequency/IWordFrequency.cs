using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Repository.WordFrequency
{
    public interface IWordFrequency
    {
        string Word { get; }
        int Frequency { get; }
    }
}
