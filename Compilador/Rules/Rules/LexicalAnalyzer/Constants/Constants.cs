using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rules.LexicalAnalyzer.Constants
{
    public abstract class Constants : ScannerConstants
    {
        public const int EPSILON = 0;
        public const int DOLLAR = 1;

        public const int t_identificador = 2;
        public const int t_constanteInteira = 3;
        public const int t_constanteReal = 4;
        public const int t_constanteString = 5;
        public const int t_constanteCaractere = 6;
        public const int t_bloco = 7;
        public const int t_and = 8;
        public const int t_begin = 9;
        public const int t_bool = 10;
        public const int t_char = 11;
        public const int t_end = 12;
        public const int t_false = 13;
        public const int t_float = 14;
        public const int t_forward = 15;
        public const int t_ifFalseDo = 16;
        public const int t_ifTrueDo = 17;
        public const int t_int = 18;
        public const int t_main = 19;
        public const int t_module = 20;
        public const int t_not = 21;
        public const int t_or = 22;
        public const int t_read = 23;
        public const int t_string = 24;
        public const int t_true = 25;
        public const int t_voidentificador = 26;
        public const int t_whileFalseDo = 27;
        public const int t_whileTrueDo = 28;
        public const int t_write = 29;
        public const int t_TOKEN_30 = 30; //"+"
        public const int t_TOKEN_31 = 31; //"-"
        public const int t_TOKEN_32 = 32; //"*"
        public const int t_TOKEN_33 = 33; //"/"
        public const int t_TOKEN_34 = 34; //"?"
        public const int t_TOKEN_35 = 35; //"("
        public const int t_TOKEN_36 = 36; //")"
        public const int t_TOKEN_37 = 37; //"=="
        public const int t_TOKEN_38 = 38; //"!="
        public const int t_TOKEN_39 = 39; //"<"
        public const int t_TOKEN_40 = 40; //"<="
        public const int t_TOKEN_41 = 41; //">"
        public const int t_TOKEN_42 = 42; //">="
        public const int t_TOKEN_43 = 43; //","
        public const int t_TOKEN_44 = 44; //"."
        public const int t_TOKEN_45 = 45; //";"
        public const int t_TOKEN_46 = 46; //":"
        public const int t_TOKEN_47 = 47; //"="
        public const int t_TOKEN_48 = 48; //"+="
        public const int t_TOKEN_49 = 49; //"-="
        public const int t_TOKEN_50 = 50; //"^"
    }
}
