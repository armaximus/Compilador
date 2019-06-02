namespace Rules.LexicalAnalyzer.Exceptions
{
    public class LexicalError : AnalysisError
    {
        public LexicalError(string message, int position) : base(message, position)
        {
        }

        public LexicalError(string message) : base(message)
        {
        }
    }
}
