using Rules.LexicalAnalyzer;
using Rules.LexicalAnalyzer.Constants;
using Rules.LexicalAnalyzer.Exceptions;
using System;
using System.Windows.Forms;

namespace Rules
{
    public class Compiler
    {
        public String Compile(String programa)
        {

            Lexico lexico = new Lexico(programa);
            String retorno = "";

            try
            {
                Token t = null;
                while ((t = lexico.NextToken()) != null)
                {
                    retorno += t.Lexeme;
                }
            }
            catch (LexicalError e)
            {
                retorno += e.Message + "e;, em " + e.Position;
            }
            return retorno;
        }
    }  
}
