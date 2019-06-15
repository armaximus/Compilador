using Rules.LexicalAnalyzer.Exceptions;
using Rules.LexicalAnalyzer.Constants;
using System;

namespace Rules.LexicalAnalyzer
{
    public class Semantico : Constants.Constants
    {
        public void ExecuteAction(int action, Token token)
        {
            Console.WriteLine("Ação #" + action + ", Token: " + token);
        }
    }
}