using Rules.LexicalAnalyzer;
using Rules.LexicalAnalyzer.Constants;
using Rules.LexicalAnalyzer.Exceptions;
using System.Text;

namespace Rules
{
    public class Compiler
    {
        public string Compile(string programa)
        {
            StringBuilder retorno = new StringBuilder();

            Lexico lexico = new Lexico(programa.Trim());

            Sintatico sintatico = new Sintatico();

            Semantico semantico = new Semantico();

            if (programa.Trim().Length == 0)
            {
                return "Nenhum programa para compilar";
            }

            try
            {
                sintatico.Parse(lexico, semantico);

                Token t = null;

                while ((t = lexico.NextToken()) != null)
                {
                    // if (t.Id != Constants.t_bloco)
                    retorno.AppendLine(string.Format("{0} {1}", GetLine(programa, t.Position), t.ToString()));
                }

                if (retorno.Length > 0)
                    retorno.AppendLine();

                retorno.AppendLine("Programa compilado com sucesso.");
            }
            catch (LexicalError e)
            {
                return string.Format("Erro na linha {0}: {1}.", GetLine(programa, e.Position), e.Message);
            }
            catch (SyntaticError e)
            {
                return string.Format("Erro na linha {0}: {1}.", GetLine(programa, e.Position), e.Message);
            }

            return retorno.ToString().Trim();
        }

        private int GetLine(string input, int position)
        {
            return input.Substring(0, position).Split('\n').Length;
        }
    }
}
