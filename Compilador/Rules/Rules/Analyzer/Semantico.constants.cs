namespace Rules.Analyzer
{
    public partial class Semantico
    {
        private const string Ident = "    ";

        public const string float64 = "float64";
        public const string int64 = "int64";
        public const string Bool = "bool";
        public const string str = "string";

        public const string True = "ldc.i4.1";
        public const string False = "ldc.i4.0";
        public const string convr8 = "conv.r8";
        public const string convi8 = "conv.i8";
        public const string cgt = "cgt";
        public const string clt = "clt";
        public const string ceq = "ceq";
        public const string ldloc = "ldloc";
        public const string stloc = "stloc";
        public const string ldci8 = "ldc.i8";
        public const string ldstr = "ldstr";

        public const string xor = "xor";
        public const string add = "add";
        public const string sub = "sub";
        public const string mul = "mul";
        public const string div = "div";

        public const int ADD = 1;
        public const int SUB = 2;
        public const int MUL = 3;
        public const int DIV = 4;
        public const int INT = 5;
        public const int FLOAT = 6;
        public const int PLUS = 7;
        public const int MINUS = 8;
        public const int OPERATOR = 9;
        public const int RELACIONALOPERATION = 10;
        public const int TRUE = 11;
        public const int FALSE = 12;
        public const int NOT = 13;
        public const int TIPO = 14;
        public const int MAIN = 15;
        public const int BEGIN = 16;
        public const int END = 17;
        public const int AND = 18;
        public const int OR = 19;
        public const int CHAR = 20;
        public const int STRING = 21;
        public const int VAR = 30;
        public const int IDENTIFIERLIST = 31;
        public const int IDENTIFIER = 32;
        public const int FATOR = 33;
        public const int EXPRESSION = 34;
        public const int READ = 35;
        public const int ASSIGNMENTOPERATOR = 36;
        public const int COMMAND = 37;
        public const int IFTRUE = 38;
        public const int ENDSELECTION = 39;
        public const int IFFALSE = 40;
        public const int CONDITIONTYPE = 41;
        public const int ENDREPETITION = 42;
    }
}
