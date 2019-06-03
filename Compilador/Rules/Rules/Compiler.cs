using Rules.LexicalAnalyzer;
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

                Token t = lexico.NextToken();

                while (t != null)
                {
                    t = lexico.NextToken();
                }

                if (retorno.Length > 0)
                    retorno.AppendLine();

                retorno.AppendLine("Programa compilado com sucesso.");

            }
            catch (LexicalException e)
            {
                return string.Format("Erro na linha {0}: {1} {2}.", GetLine(programa, e.Position), e.Data, e.Message);
            }
            catch (SyntaticException e)
            {
                //TO DO - PEGAR O QUE FOI ENCONTRADO
                return string.Format("Erro na linha {0} - encontrado {1}  {2}.", GetLine(programa, e.Position), string.Empty, e.Message);
            }

            return retorno.ToString().Trim();
        }

        private int GetLine(string input, int position)
        {
            return input.Substring(0, position).Split('\n').Length;
        }
    }
}
