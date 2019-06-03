using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rules.LexicalAnalyzer.Exceptions
{
    public class SemanticException : AnalysisException
    {
        public SemanticException(string message, int position) : base(message, position)
        {
        }

        public SemanticException(string message) : base(message)
        {
        }
    }
}
