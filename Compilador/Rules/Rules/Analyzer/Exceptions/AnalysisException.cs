using System;

namespace Rules.Analyzer.Exceptions
{
    public class AnalysisException : Exception
    {
        public int Position { get; private set; }

        public AnalysisException(string message) : this(message, -1)
        {
        }

        public AnalysisException(string message, int position) : base(message)
        {
            this.Position = position;
        }

        public override string ToString()
        {
            return base.ToString() + ", @ " + Position;
        }
    }
}
