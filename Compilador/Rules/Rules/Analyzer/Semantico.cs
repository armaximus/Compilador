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
        public List<string> Codigo { get; set; }
        public string OperadorRelacional { get; set; }
        private List<string> Idents { get; set; }

        public Semantico()
        {
            Pilha = new Stack<string>();
            Codigo = new List<string>();
            Idents = new List<string>();
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
                case OPERATOR:
                    OperadorRelacional = token.Lexeme;
                    break;
                case RELACIONALOPERATION:
                    ExecuteRelacionalOperation();
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
                case AND:
                    throw new SemanticException("Ação AND (#18) não implementada.");
                case OR:
                    throw new SemanticException("Ação OR (#19) não implementada.");
                case CHAR:
                case STRING:
                    ExecuteString(token);
                    break;
                default:
                    throw new SemanticException(string.Format("Ação #{0} não implementada.", action));
            }
        }

        private void ExecuteString(Token token)
        {
            AddCode();

            string lexeme = token.Lexeme;

            if (lexeme == "\\s")
                lexeme = "\" \"";
            else if (lexeme == "\\t" || lexeme == "\\n")
                lexeme = string.Format("\"{0}\"", lexeme);

            AddCode(ldstr + " " + lexeme);
            AddCode(convr8);
            Pilha.Push(str);
        }

        private void PrepareStackForArithmeticOperation()
        {
            var tipo1 = Pilha.Pop();
            var tipo2 = Pilha.Pop();

            if (!ValidTypeForArithmeticOperation(tipo1) || !ValidTypeForArithmeticOperation(tipo2))
                throw new SemanticException("Tipo(s) incompatível(is) em expressão aritmética.");

            if (tipo1 == float64 || tipo2 == float64)
                Pilha.Push(float64);
            else
                Pilha.Push(int64);
        }

        private bool ValidTypeForArithmeticOperation(string type)
        {
            return type == int64 || type == float64;
        }

        private void ExecuteAdd()
        {
            PrepareStackForArithmeticOperation();
            AddCode(add);
        }

        private void ExecuteSub()
        {
            PrepareStackForArithmeticOperation();
            AddCode(sub);
        }

        private void ExecuteMul()
        {
            PrepareStackForArithmeticOperation();
            AddCode(mul);
        }

        private void ExecuteDiv()
        {
            PrepareStackForArithmeticOperation();
            AddCode(div);
        }

        private void ExecuteInt(Token token)
        {
            Pilha.Push(int64);
            AddCode(ldci8 + " " + token.Lexeme);
            AddCode(convr8);
        }

        private void ExecuteFloat(Token token)
        {
            Pilha.Push(float64);
            AddCode(ldci8 + " " + token.Lexeme);
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

            AddCode(ldci8 + " -1");
            AddCode(convr8);
            AddCode(mul);
        }

        private void ExecuteTipo()
        {
            var tipo = Pilha.Pop();

            if (tipo == int64)
                AddCode(convi8);

            AddCode(string.Format("call void [mscorlib]System.Console::Write({0})", tipo));
        }

        private void ExecuteMain()
        {
            Codigo.Add(".assembly extern mscorlib {}");
            Codigo.Add(".assembly _codigo_objeto {}");
            Codigo.Add(".module   _codigo_object.exe");
            AddCode();
            Codigo.Add(".class public _UNICA {");
            AddCode();
        }

        private void ExecuteBegin()
        {
            Codigo.Add(".method static public void _principal() {");
            Codigo.Add("    .entrypoint");
            AddCode();
            Idents.Add(Ident);
        }

        private void ExecuteEnd()
        {
            AddCode();
            AddCode("ret");
            AddCode("}");
            Idents.RemoveAt(Idents.Count - 1);
            AddCode("}");
        }

        private void ExecuteTrue()
        {
            Pilha.Push(Bool);
            AddCode(True);
        }

        private void ExecuteFalse()
        {
            Pilha.Push(Bool);
            AddCode(False);
        }

        private void ExecuteNot()
        {
            var tipo = Pilha.Pop();

            if (tipo == Bool)
                Pilha.Push(Bool);
            else
                throw new SemanticException("Tipo(s) incompatível(is) em expressão lógica.");

            AddCode(True);
            AddCode(xor);
        }

        private void ExecuteRelacionalOperation()
        {
            var tipo1 = Pilha.Pop();
            var tipo2 = Pilha.Pop();

            if (tipo1 == tipo2)
                Pilha.Push(Bool);
            else
                throw new SemanticException("Tipos incompatíveis em expressão relacional.");

            switch (OperadorRelacional)
            {
                case ">":
                    AddCode(cgt);
                    break;
                case "<":
                    AddCode(clt);
                    break;
                case "==":
                    AddCode(ceq);
                    break;
                default:
                    break;
            }
        }

        private void AddCode()
        {
            Codigo.Add(string.Empty);
        }

        private void AddCode(string code)
        {
            string ident = string.Join(string.Empty, Idents);
            Codigo.Add(ident + code);
        }
    }
}