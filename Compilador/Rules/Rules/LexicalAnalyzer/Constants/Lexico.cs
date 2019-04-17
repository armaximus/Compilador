using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rules.LexicalAnalyzer.Exceptions;

namespace Rules.LexicalAnalyzer.Constants
{
    public class Lexico : Constants
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
            if (!HasInput)
                return null;

            int start = Position;

            int state = 0;
            int lastState = 0;
            int endState = -1;
            int end = -1;

            while (HasInput)
            {
                lastState = state;
                state = NextState(NextChar, state);

                if (state < 0)
                    break;

                else
                {
                    if (TokenForState(state) >= 0)
                    {
                        endState = state;
                        end = Position;
                    }
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
                string lexeme = Input.Substring(start, end);
                return new Token(token, lexeme, start);
            }
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
                else  //(SCANNER_TABLE[half, 0] > c)
                    end = half - 1;
            }

            return -1;
        }

        private int TokenForState(int state)
        {
            return (state < 0 || state >= TOKEN_STATE.Length) ? -1 :TOKEN_STATE[state];
        }
    }
}
