using System;

namespace Rules.LexicalAnalyzer
{
    public class Semantico : Constants.Constants
    {
        public void executeAction(int action, Token token)
        {
            Console.WriteLine("Ação #" + action + ", Token: " + token);
        }
    }
}