using Rules.LexicalAnalyzer.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rules.LexicalAnalyzer.Constants
{
    public static class Translator
    {
        public static string GetToken(int constant)
        {
            if (EhPalavraReservada(constant))
                return "palavra reservada";

            if (EhSimboloEspecial(constant))
                return "símbolo especial";

            switch (constant)
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
                case Constants.t_bloco:
                    return "bloco";
                case Constants.t_voidentificador:
                    return "void entificador";
                default:
                    throw new LexicalError("Token não identificado");
            }
        }

        private static bool EhPalavraReservada(int constant)
        {
            int[] palavrasReservadas = new int[]
            {
                Constants.t_and, Constants.t_begin,
                Constants.t_bool, Constants.t_char,
                Constants.t_end, Constants.t_false,
                Constants.t_float, Constants.t_forward,
                Constants.t_ifFalseDo, Constants.t_ifTrueDo,
                Constants.t_int, Constants.t_main,
                Constants.t_module, Constants.t_not,
                Constants.t_not, Constants.t_or,
                Constants.t_read, Constants.t_string,
                Constants.t_true, Constants.t_whileTrueDo,
                Constants.t_whileFalseDo, Constants.t_write
            };

            return palavrasReservadas.Contains(constant);
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
                Constants.t_TOKEN_48, Constants.t_TOKEN_49,
                Constants.t_TOKEN_50
            };

            return simbolosEspeciais.Contains(constant);
        }
    }
}
