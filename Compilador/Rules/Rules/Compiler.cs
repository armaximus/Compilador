using Rules.Analyzer;
using Rules.Analyzer.Exceptions;
using System;
using System.Text;

namespace Rules
{
    public class Compiler
    {
        public string Compile(string programa)
        {
            Sintatico sintatico = new Sintatico();

            programa = programa.Trim();

            if (string.IsNullOrWhiteSpace(programa))
                return "Nenhum programa para compilar.";

            try
            {
                Lexico lexico = new Lexico(programa);
                Semantico semantico = new Semantico();

                sintatico.Parse(lexico, semantico);

                ProcessarPrograma(lexico);

                return "Programa compilado com sucesso.";

            }
            catch (LexicalException ex)
            {
                return string.Format("Erro na linha {0}: {1}", GetLine(programa, ex.Position), ex.Message);
            }
            catch (SyntaticException ex)
            {
                return string.Format("Erro na linha {0}: encontrado {1} esperado {2}", GetLine(programa, ex.Position), sintatico.CurrentToken.Lexeme, ex.Message);
            }
            catch (SemanticException ex)
            {
                return string.Format("Erro na linha {0}: {1}", GetLine(programa, ex.Position), ex.Message);
            }
            catch (Exception ex)
            {
                return string.Format("Erro desconhecido: {0}", ex.Message);
            }
        }

        private void ProcessarPrograma(Lexico lexico)
        {
            Token t = lexico.NextToken();

            while (t != null)
            {
                t = lexico.NextToken();
            }
        }

        private int GetLine(string input, int position)
        {
            return input.Substring(0, position).Split('\n').Length;
        }
    }
}
