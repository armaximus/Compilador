namespace Rules.Analyzer.Exceptions
{
    public class LexicalException : AnalysisException
    {
        public LexicalException(string message, int position) : base(message, position)
        {
        }

        public LexicalException(string message) : base(message)
        {
        }
    }
}
