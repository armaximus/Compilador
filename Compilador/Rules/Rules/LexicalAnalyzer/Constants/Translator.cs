using Rules.LexicalAnalyzer.Exceptions;
using System;
using System.Linq;

namespace Rules.LexicalAnalyzer.Constants
{
    public static class Translator
    {
        public static string GetToken(Token t)
        {
            if (EhPalavraReservada(t.Lexeme))
                return "palavra reservada";

            if (EhSimboloEspecial(t.Id))
                return "símbolo especial";

            switch (t.Id)
            {
                case Constants.t_identificador:
                    return "identificador";
                case Constants.t_constanteInteira:
                    return "constante inteira";
                case Constants.t_constanteReal:
                    return "constante real";
                case Constants.t_constanteString:
                    return "constante string";
                case Constants.t_constanteCaractere:
                    return "constante caractere";
                case Constants.t_void:
                    return "void";
                default:
                    throw new LexicalException("Token não identificado");
            }
        }

        private static bool EhPalavraReservada(String lexeme)
        {

            return ScannerConstants.SPECIAL_CASES_KEYS.Contains(lexeme);
        }

        private static bool EhSimboloEspecial(int constant)
        {
            int[] simbolosEspeciais = new int[]
            {
                Constants.t_TOKEN_30, Constants.t_TOKEN_31,
                Constants.t_TOKEN_32, Constants.t_TOKEN_33,
                Constants.t_TOKEN_34, Constants.t_TOKEN_35,
                Constants.t_TOKEN_36, Constants.t_TOKEN_37,
                Constants.t_TOKEN_38, Constants.t_TOKEN_39,
                Constants.t_TOKEN_40, Constants.t_TOKEN_41,
                Constants.t_TOKEN_42, Constants.t_TOKEN_43,
                Constants.t_TOKEN_44, Constants.t_TOKEN_45,
                Constants.t_TOKEN_46, Constants.t_TOKEN_47,
                Constants.t_TOKEN_48, Constants.t_TOKEN_29
            };

            return simbolosEspeciais.Contains(constant);
        }
    }
}
