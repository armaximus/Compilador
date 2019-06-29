using Rules.Analyzer;
using Rules.Analyzer.Constants;
using Rules.Analyzer.Exceptions;
using System;
using System.Text;

namespace Rules
{
    public class Compiler
    {
        public string Assembly { get; private set; }

        public bool Compile(string programa)
        {
            Sintatico sintatico = new Sintatico();

            programa = programa.Trim();

            if (string.IsNullOrWhiteSpace(programa))
                return false;

            try
            {
                Lexico lexico = new Lexico(programa);
                Semantico semantico = new Semantico();

                sintatico.Parse(lexico, semantico);

                ProcessarPrograma(lexico);

                Assembly = string.Join(Environment.NewLine, semantico.Codigo);

                return true;
            }
            catch (LexicalException ex)
            {
                throw new LexicalException(string.Format("Erro na linha {0}: {1}", GetLine(programa, ex.Position), ex.Message));
            }
            catch (SyntaticException ex)
            {
                throw new SyntaticException(string.Format("Erro na linha {0}: encontrado {1} esperado {2}", GetLine(programa, ex.Position), sintatico.CurrentToken.Lexeme, ex.Message));
            }
            catch (SemanticException ex)
            {
                throw new SemanticException(string.Format("Erro na linha {0}: {1}", GetLine(programa, ex.Position), ex.Message));
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Erro desconhecido: {0} {1}{1}{2}", ex.Message, Environment.NewLine, ex.StackTrace));
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
