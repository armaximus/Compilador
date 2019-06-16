using Rules.Analyzer.Exceptions;
using Rules.Analyzer.Constants;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace Rules.Analyzer
{
    public partial class Semantico : Constants.Constants
    {
        public Stack<string> Pilha { get; set; }
        public static List<string> Codigo { get; set; }
        public string OperadorRelacional { get; set; }

        public Semantico()
        {
            Pilha = new Stack<string>();
            Codigo = new List<string>();
        }

        public void ExecuteAction(int action, Token token)
        {
            switch (action)
            {
                case ADD:
                    ExecuteAdd();
                    break;
                case SUB:
                    ExecuteSub();
                    break;
                case MUL:
                    ExecuteMul();
                    break;
                case DIV:
                    ExecuteDiv();
                    break;
                case INT:
                    ExecuteInt(token);
                    break;
                case FLOAT:
                    ExecuteFloat(token);
                    break;
                case PLUS:
                    ExecutePlus();
                    break;
                case MINUS:
                    ExecuteMinus();
                    break;
                case TRUE:
                    ExecuteTrue();
                    break;
                case FALSE:
                    ExecuteFalse();
                    break;
                case NOT:
                    ExecuteNot();
                    break;
                case TIPO:
                    ExecuteTipo();
                    break;
                case MAIN:
                    ExecuteMain();
                    break;
                case BEGIN:
                    ExecuteBegin();
                    break;
                case END:
                    ExecuteEnd();
                    break;
                default:
                    break;
            }
        }

        private void PrepareStackForArithmeticOperation()
        {
            var tipo1 = Pilha.Pop();
            var tipo2 = Pilha.Pop();

            if (tipo1 == float64 || tipo2 == float64)
                Pilha.Push(float64);
            else
                Pilha.Push(int64);
        }

        private void ExecuteAdd()
        {
            PrepareStackForArithmeticOperation();
            Codigo.Add(add);
        }

        private void ExecuteSub()
        {
            PrepareStackForArithmeticOperation();
            Codigo.Add(sub);
        }

        private void ExecuteMul()
        {
            PrepareStackForArithmeticOperation();
            Codigo.Add(mul);
        }

        private void ExecuteDiv()
        {
            PrepareStackForArithmeticOperation();
            Codigo.Add(div);
        }

        private void ExecuteInt(Token token)
        {
            Pilha.Push(int64);
            Codigo.Add(ldci8 + " " + token.Lexeme);
            Codigo.Add(convr8);
        }

        private void ExecuteFloat(Token token)
        {
            Pilha.Push(float64);
            Codigo.Add(ldci8 + " " + token.Lexeme);
        }

        private void ExecutePlus()
        {
            var tipo = Pilha.Pop();

            if (tipo == float64 || tipo == int64)
                Pilha.Push(tipo);
            else
                throw new SemanticException("Tipos incompatíveis em expressão aritmética.");
        }

        private void ExecuteMinus()
        {
            var tipo = Pilha.Pop();

            if (tipo == float64 || tipo == int64)
                Pilha.Push(tipo);
            else
                throw new SemanticException("Tipos incompatíveis em expressão aritmética.");

            Codigo.Add(ldci8 + " -1");
            Codigo.Add(convr8);
            Codigo.Add(mul);
        }

        private void ExecuteTipo()
        {
            var tipo = Pilha.Pop();

            if (tipo == int64)
                Codigo.Add(convr8);

            Codigo.Add(string.Format("call void [mscorlib]System.Console::Write({0})", tipo));
        }

        private void ExecuteMain()
        {
            Codigo.Add(@"
                         .assembly extern mscorlib {}
                         .assembly _codigo_objeto {}
                         .module   _codigo_object.exe
                         
                         .class public _UNICA {
                        ");
        }

        private void ExecuteBegin()
        {
            Codigo.Add(@"
                        .method static public void _principal() {
                            .entrypoint
                        ");
        }

        private void ExecuteEnd()
        {
            Codigo.Add(@"
                            ret
                            }
                        }
                        ");
        }

        private void ExecuteTrue()
        {
            Pilha.Push(Bool);
            Codigo.Add(True);
        }

        private void ExecuteFalse()
        {
            Pilha.Push(Bool);
            Codigo.Add(False);
        }

        private void ExecuteNot()
        {
            var tipo = Pilha.Pop();

            if (tipo == Bool)
                Pilha.Push(Bool);
            else
                throw new SemanticException("Tipo não lógico.");

            Codigo.Add(True);
            Codigo.Add(xor);
        }
    }
}