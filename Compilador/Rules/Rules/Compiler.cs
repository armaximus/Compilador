using Rules.LexicalAnalyzer;
using Rules.LexicalAnalyzer.Constants;
using Rules.LexicalAnalyzer.Exceptions;
using System;
using System.Text;
using System.Windows.Forms;

namespace Rules
{
    public class Compiler
    {
        public string Compile(string programa)
        {
            StringBuilder retorno = new StringBuilder();
            
            Lexico lexico = new Lexico(programa.Trim());

            try
            {
                Token t = null;

                while ((t = lexico.NextToken()) != null)
                {
                    retorno.AppendLine(t.ToString());
                }

                if (retorno.Length > 0)
                    retorno.AppendLine();

                retorno.AppendLine("Programa compilado com sucesso.");
            }
            catch (LexicalError e)
            {
                // TODO : Trazer o token
                return string.Format("Erro na linha {0} - {1}.", GetLine(programa, e.Position), e.Message);
            }

            return retorno.ToString().Trim();
        }

        private int GetLine(string input, int position)
        {
            return input.Substring(0, position).Split('\n').Length + 1;
        }
    }
}
