using Rules.LexicalAnalyzer.Exceptions;
using Rules.LexicalAnalyzer.Constants;
using System;

namespace Rules.LexicalAnalyzer
{
    public class Lexico : Constants.Constants
    {
        private int Position { get; set; }

        private string Input { get; set; }

        private bool HasInput
        {
            get
            {
                return Position < Input.Length;
            }
        }

        private char NextChar
        {
            get
            {
                if (HasInput)
                    return Input[Position++];
                else
                    return char.MinValue;
            }
        }

        public Lexico() : this(string.Empty)
        {
        }

        public Lexico(string input)
        {
            this.Input = input;
            this.Position = 0;
        }

        public Token NextToken()
        {
            try
            {
                if (!HasInput)
                    return null;

                int start = Position, state = 0, lastState = 0, endState = -1, end = -1;

                while (HasInput)
                {
                    lastState = state;
                    state = NextState(NextChar, state);

                    if (state < 0)
                        break;
                    else if (TokenForState(state) >= 0)
                    {
                        endState = state;
                        end = Position;
                    }
                }

                if (endState < 0 || (endState != state && TokenForState(lastState) == -2))
                    throw new LexicalError(SCANNER_ERROR[lastState], start);

                Position = end;

                int token = TokenForState(endState);

                if (token == 0)
                    return NextToken();
                else
                {
                    string lexeme = GetLexeme(Input, start, end);
                    token = LookupToken(token, lexeme);

                    return new Token(token, lexeme, start);
                }
            }
            catch (Exception ex)
            {
                throw new LexicalError(ex.Message, Position);
            }
        }

        private int LookupToken(int token, string key)
        {
            int start = SPECIAL_CASES_INDEXES[token];
            int end = SPECIAL_CASES_INDEXES[token + 1] - 1;

            while (start <= end)
            {
                int half = (start + end) / 2;
                int comp = SPECIAL_CASES_KEYS[half].CompareTo(key);

                if (comp == 0)
                    return SPECIAL_CASES_VALUES[half];
                else if (comp < 0)
                    start = half + 1;
                else
                    end = half - 1;
            }

            return token;
        }

        private string GetLexeme(string input, int start, int end)
        {
            return input.Substring(start, (end - start));
        }

        private int NextState(char c, int state)
        {
            int start = SCANNER_TABLE_INDEXES[state];
            int end = SCANNER_TABLE_INDEXES[state + 1] - 1;

            while (start <= end)
            {
                int half = (start + end) / 2;

                if (SCANNER_TABLE[half, 0] == c)
                    return SCANNER_TABLE[half, 1];
                else if (SCANNER_TABLE[half, 0] < c)
                    start = half + 1;
                else
                    end = half - 1;
            }

            return -1;
        }

        private int TokenForState(int state)
        {
            return (state < 0 || state >= TOKEN_STATE.Length) ? -1 : TOKEN_STATE[state];
        }
    }
}
