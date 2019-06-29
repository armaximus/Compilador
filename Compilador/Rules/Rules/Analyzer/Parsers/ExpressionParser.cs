using Rules.Analyzer.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rules.Analyzer.Parsers
{
    public static class ExpressionParser
    {
        private static string[] Relational = { "==", "!=", "<", "<=", ">", ">=" };
        
        public static string GetResult(string firstOperator, string operador = "")
        {
            string result = string.Empty;

            switch (firstOperator)
            {
                case "constanteInteira":
                    result = Semantico.int64;
                    break;
                case "constanteReal":
                    result = Semantico.float64;
                    break;
                case "constanteCaractere":
                case "constanteString":
                    result = Semantico.str;
                    break;
                case Semantico.True:
                case Semantico.False:
                case Semantico.Bool:
                    result = Semantico.Bool;
                    break;
                case Semantico.int64:
                    if (new string[] { "+", "-" }.Contains(operador))
                        result = Semantico.int64;
                    break;
                case Semantico.float64:
                    result = Semantico.float64;
                    break;
            }

            if (string.IsNullOrWhiteSpace(result))
                throw new SemanticException(string.Format("Operando {0} não definido.", firstOperator));

            return result;
        }

        public static string GetResult(string firstOperator, string secondOperator, string operador = "")
        {
            string result = string.Empty;

            firstOperator = GetResult(firstOperator);
            secondOperator = GetResult(secondOperator);

            if (firstOperator == Semantico.int64 && secondOperator == Semantico.int64)
            {
                if (new string[] { "+", "-", "*" }.Contains(operador))
                    result = Semantico.int64;
                else if (operador == "/")
                    result = Semantico.float64;
                else
                    throw new SemanticException("Operador incompatível em expressão aritmética.");
            }
            else if ((firstOperator == Semantico.int64 || firstOperator == Semantico.float64) &&
                     (secondOperator == Semantico.int64 || secondOperator == Semantico.float64))
            {
                if (Relational.Contains(operador))
                    result = Semantico.Bool;
                else if ((firstOperator == Semantico.float64 || secondOperator == Semantico.float64) &&
                         new string[] { "+", "-", "*", "/" }.Contains(operador))
                    result = Semantico.float64;
                else
                    throw new SemanticException("Operador incompatível em expressão aritmética.");
            }
            else if (firstOperator == Semantico.str && secondOperator == Semantico.str)
            {
                if (Relational.Contains(operador))
                    result = Semantico.Bool;
                else
                    throw new SemanticException("Tipos incompatíveis em expressão aritmética.");
            }
            else if (firstOperator == Semantico.Bool && secondOperator == Semantico.Bool)
            {
                if (new string[] { "and", "or" }.Contains(operador))
                    result = Semantico.Bool;
                else
                    throw new SemanticException("Tipos incompatíveis em expressão relacional.");
            }
            else
                TratarExcecoes(firstOperator, secondOperator, operador);

            return result;
        }

        private static void TratarExcecoes(string firstOperator, string secondOperator, string operador)
        {
            string message = "Tipos incompatíveis";

            if (new string[] { "and", "or" }.Contains(operador) &&
                (Semantico.Bool != firstOperator || Semantico.Bool != secondOperator))
                message += " em expressão lógica";
            else if (Relational.Contains(operador))
            {
                var allowed = new string[] { Semantico.str, Semantico.int64, Semantico.float64 };

                if (!allowed.Contains(firstOperator) || !allowed.Contains(secondOperator))
                    message += " em expressão relacional";
            }
            else if (new string[] { "+", "-", "*", "/" }.Contains(operador))
            {
                var allowed = new string[] { Semantico.int64, Semantico.float64 };

                if (!allowed.Contains(firstOperator) || !allowed.Contains(secondOperator))
                    message += " em expressão artimética";
            }

            throw new SemanticException(message);
        }
    }
}
