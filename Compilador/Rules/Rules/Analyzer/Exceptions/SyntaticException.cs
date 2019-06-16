using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rules.Analyzer.Exceptions
{
    public class SyntaticException : AnalysisException
    {
        public SyntaticException(string message, int position) : base(message, position)
        {
        }

        public SyntaticException(string message) : base(message)
        {
        }
    }
}
