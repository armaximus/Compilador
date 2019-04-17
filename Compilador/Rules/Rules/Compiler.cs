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
                    retorno += t.ToString();
                }
                retorno += "\n programa compilado com sucesso";
            }
            catch (LexicalError e)
            {
                //VERIFICAR FORMA DE APRESENTAR A LINHA AQUI AO INVES DA POSICÇÃO
                //VERIFICAR FORMA DE PEGAR O TOKEN AQUI TBM
                retorno += "Erro na linha " + e.Position  + " - " + e.Message;
            }
            return retorno;
        }
    }  
}
