using System;

namespace Rules.LexicalAnalyzer.Exceptions
{
    public class AnalysisError : Exception
    {
        public int Position { get; private set; }

        public AnalysisError(string message) : this(message, -1)
        {
        }

        public AnalysisError(string message, int position) : base(message)
        {
            this.Position = position;
        }

        public override string ToString()
        {
            return base.ToString() + ", @ " + Position;
        }
    }
}
