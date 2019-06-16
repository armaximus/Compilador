using Rules.Analyzer.Constants;

namespace Rules.Analyzer
{
    public class Token
    {
        public int Id { get; set; }
        public string Lexeme { get; set; }
        public int Position { get; set; }

        public Token(int id, string lexeme, int position)
        {
            this.Id = id;
            this.Lexeme = lexeme;
            this.Position = position;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", Translator.GetToken(this), Lexeme);
        }
    }
}
