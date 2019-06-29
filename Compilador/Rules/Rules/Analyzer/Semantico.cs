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
        public string OperadorRelacional { get; private set; }
        public List<string> Codigo { get; private set; }
        public Stack<string> PilhaTipos { get; private set; }
        public Stack<string> PilhaRotulos { get; private set; }
        public List<string> ListaIdentificadores { get; private set; }
        public Dictionary<string, string> TabelaSimbolos { get; private set; }
        public string TipoVariavel { get; private set; }
        private Stack<string> Idents { get; set; }

        public Semantico()
        {
            Codigo = new List<string>();
            PilhaTipos = new Stack<string>();
            PilhaRotulos = new Stack<string>();
            ListaIdentificadores = new List<string>();
            TabelaSimbolos = new Dictionary<string, string>();
            Idents = new Stack<string>();
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
                    ExecuteAnd();
                    break;
                case OR:
                    ExecuteOr();
                    break;
                case CHAR:
                case STRING:
                    ExecuteString(token);
                    break;
                case VAR:
                    ExecuteVar(token);
                    break;
                case IDENTIFIERLIST:
                    ExecuteIdentifierList();
                    break;
                case IDENTIFIER:
                    ExecuteIdentifier(token);
                    break;
                case FATOR:
                    ExecuteFator(token);
                    break;
                case EXPRESSION:
                    ExecuteExpression();
                    break;
                case READ:
                    ExecuteRead();
                    break;
                case ASSIGNMENTOPERATOR:
                    ExecuteAssignment(token);
                    break;
                case COMMAND:
                    ExecuteCommand();
                    break;
                case IFTRUE:
                    ExecuteIf("true");
                    break;
                case ENDSELECTION:
                    ExecuteEndCycle("selection");
                    break;
                case IFFALSE:
                    ExecuteIf("false");
                    break;
                case CONDITIONTYPE:
                    ExecuteConditionType();
                    break;
                case ENDREPETITION:
                    ExecuteEndCycle("selection");
                    break;
                default:
                    throw new SemanticException(string.Format("Ação #{0} não implementada.", action));
            }
        }

        private void PrepareStackForArithmeticOperation()
        {
            var tipo1 = PilhaTipos.Pop();
            var tipo2 = PilhaTipos.Pop();

            if (!ValidTypeForArithmeticOperation(tipo1) || !ValidTypeForArithmeticOperation(tipo2))
                throw new SemanticException("Tipo(s) incompatível(is) em expressão aritmética.");

            if (tipo1 == float64 || tipo2 == float64)
                PilhaTipos.Push(float64);
            else
                PilhaTipos.Push(int64);
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
            PilhaTipos.Push(int64);
            AddCode(ldci8 + " " + token.Lexeme);
            AddCode(convr8);
        }

        private void ExecuteFloat(Token token)
        {
            PilhaTipos.Push(float64);
            AddCode(ldci8 + " " + token.Lexeme);
        }

        private void ExecutePlus()
        {
            var tipo = PilhaTipos.Pop();

            if (tipo == float64 || tipo == int64)
                PilhaTipos.Push(tipo);
            else
                throw new SemanticException("Tipos incompatíveis em expressão aritmética.");
        }

        private void ExecuteMinus()
        {
            var tipo = PilhaTipos.Pop();

            if (tipo == float64 || tipo == int64)
                PilhaTipos.Push(tipo);
            else
                throw new SemanticException("Tipos incompatíveis em expressão aritmética.");

            AddCode(ldci8 + " -1");
            AddCode(convr8);
            AddCode(mul);
        }

        private void ExecuteTipo()
        {
            var tipo = PilhaTipos.Pop();

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
            Idents.Push(Ident);
        }

        private void ExecuteEnd()
        {
            AddCode();
            AddCode("ret");
            AddCode("}");
            Idents.Pop();
            AddCode("}");
        }

        private void ExecuteAnd()
        {
            /*
             v1 = Desempilha
             v2 = Desempilha

             Empilha(v1 && v2)
             */

            PilhaTipos.Push(Bool);
        }

        private void ExecuteOr()
        {
            /*
             v1 = Desempilha
             v2 = Desempilha

             Empilha(v1 || v2)
             */

            PilhaTipos.Push(Bool);
        }

        private void ExecuteTrue()
        {
            PilhaTipos.Push(Bool);
            AddCode(True);
        }

        private void ExecuteFalse()
        {
            PilhaTipos.Push(Bool);
            AddCode(False);
        }

        private void ExecuteNot()
        {
            var tipo = PilhaTipos.Pop();

            if (tipo == Bool)
                PilhaTipos.Push(Bool);
            else
                throw new SemanticException("Tipo(s) incompatível(is) em expressão lógica.");

            AddCode(True);
            AddCode(xor);
        }

        private void ExecuteRelacionalOperation()
        {
            var tipo1 = PilhaTipos.Pop();
            var tipo2 = PilhaTipos.Pop();

            if (tipo1 == tipo2)
                PilhaTipos.Push(Bool);
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

        private void ExecuteString(Token token)
        {
            string lexeme = token.Lexeme;

            if (lexeme == "\\s")
                lexeme = "\" \"";
            else if (lexeme == "\\t" || lexeme == "\\n")
                lexeme = string.Format("\"{0}\"", lexeme);

            AddCode(ldstr + " " + lexeme);
            PilhaTipos.Push(str);
        }

        private void ExecuteVar(Token token)
        {
            switch (token.Lexeme)
            {
                case "int":
                    TipoVariavel = Semantico.int64;
                    break;
                case "real":
                    TipoVariavel = Semantico.float64;
                    break;
                default:
                    break;
            }
        }

        private void ExecuteIdentifierList()
        {
            foreach (var identificador in ListaIdentificadores)
            {
                if (TabelaSimbolos.ContainsKey(identificador))
                    throw new SemanticException(string.Format("{0} já declarado", identificador));
                TabelaSimbolos[identificador] = TipoVariavel;
                AddCode(string.Format(".locals({0} {1})", TipoVariavel, identificador));
            }
            ListaIdentificadores.Clear();
        }

        private void ExecuteIdentifier(Token token)
        {
            ListaIdentificadores.Add(token.Lexeme);
        }

        private void ExecuteFator(Token token)
        {
            string identificador = token.Lexeme;

            if (!TabelaSimbolos.ContainsKey(identificador))
                throw new SemanticException(string.Format("{0} não declarado", identificador));

            string tipoIdentificador = TabelaSimbolos[identificador];
            PilhaTipos.Push(tipoIdentificador);
            AddCode(ldloc + " " + identificador);

            if (tipoIdentificador == int64)
                AddCode(convr8);
        }

        private void ExecuteExpression()
        {
            // listaId.retira = retirar qual? KKKKKKK
            string identificador = ListaIdentificadores[ListaIdentificadores.Count - 1];

            if (!TabelaSimbolos.ContainsKey(identificador))
                throw new SemanticException(string.Format("{0} não declarado", identificador));

            string tipoIdentificador = TabelaSimbolos[identificador];
            string tipoExpressao = PilhaTipos.Pop();

            if (tipoIdentificador != tipoExpressao)
                throw new SemanticException("Tipo incompatível para atribuição");

            if (tipoIdentificador == int64)
                AddCode(convi8);

            AddCode(stloc + " " + identificador);
        }

        private void ExecuteRead()
        {
            foreach (var identificador in ListaIdentificadores)
            {
                if (!TabelaSimbolos.ContainsKey(identificador))
                    throw new SemanticException(string.Format("{0} não declarado", identificador));

                string tipoIdentificador = TabelaSimbolos[identificador];
                string classe = string.Empty;

                if (tipoIdentificador == int64)
                    classe = "Int64";
                else if (tipoIdentificador == float64)
                    classe = "Double";

                AddCode("call string [mscorlib]System.Console::ReadLine()");
                AddCode(string.Format("call {0} [mscorlib]System.{1}::Parse(string)", tipoIdentificador, classe));
                AddCode(stloc + " " + "identificador");
            }
        }

        private void ExecuteAssignment(Token token)
        {
            string lexeme = token.Lexeme;

            if (lexeme == "+=" || lexeme == "-=")
            {
                // Carregar o valor armazenado no identificador (ldloc)
            }

            // Gerar codigo para atribuir o resultado da expressão ao identificador (stloc)

            //Para o operador +=, somar (add) o valor armazenado ao resultado da expressão e atribuir o resultado da expressão ao identificador (stloc)

            //Para o operador -=, somar (sub) o valor armazenado ao resultado da expressão e atribuir o resultado da expressão ao identificador (stloc)
        }

        private void ExecuteCommand()
        {
            // WhileTrueDo
            // Rotular o primeiro comando da expressão
            // Verificar se o resultado da expressão é false, se sim, desviar para o primeiro comando após o end
            // Gerar codigo para desviar para o primeiro comando da expressão e rotular o primeiro comando após o end

            // WhileFalseDo
            // Rotular o primeiro comando da expressão
            // Verificar se o resultado da expressão é true, se sim, desviar para o primeiro comando após o end
            // Gerar codigo para desviar para o primeiro comando da expressão e rotular o primeiro comando após o end
        }

        private void ExecuteIf(string tipo)
        {
            // IfTrueDo
            // Verifica o resultado da expressão
            // Se for false:
            // Quando existe ifFlaseDo, desviar para este bloco
            // Senão, vai para o end (rotular)

            // IfFalseDo
            // Verifica o resultado da expressão
            // se for false, desviar para este bloco
            // Senão, vai para o end (rotular)
        }

        private void ExecuteEndCycle(string tipo)
        {
            //Aparentemente, é para sair do ciclo de seleção ou repetição
        }

        private void ExecuteConditionType()
        {
            //Aparentemente, é para representar o tipo de verificação (whileTrueDo/whileFalseDo)
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