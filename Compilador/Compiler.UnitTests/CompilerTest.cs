using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rules;
using Rules.Analyzer.Exceptions;

namespace Compiler.UnitTests
{
    [TestClass]
    public class CompilerTest
    {
        public readonly string CabecalhoFixo = ".assembly extern mscorlib {}" + Environment.NewLine +
                                               ".assembly _codigo_objeto {}" + Environment.NewLine +
                                               ".module   _codigo_object.exe" + Environment.NewLine +
                                               "" + Environment.NewLine +
                                               ".class public _UNICA {" + Environment.NewLine +
                                               "" + Environment.NewLine +
                                               ".method static public void _principal() {" + Environment.NewLine +
                                               "    .entrypoint" + Environment.NewLine +
                                               "" + Environment.NewLine;

        public readonly string Ret = Environment.NewLine +
                                     "    ret" + Environment.NewLine +
                                     "    }" + Environment.NewLine +
                                     "}";
        
        [TestMethod]
        public void Teste01()
        {
            string programa = "main begin write(1, \\s, 2.5, \\t, \"teste\", \\n). end";

            string expected = CabecalhoFixo +
                              "    ldc.i8 1" + Environment.NewLine +
                              "    conv.r8" + Environment.NewLine +
                              "    conv.i8" + Environment.NewLine +
                              "    call void [mscorlib]System.Console::Write(int64)" + Environment.NewLine +
                              "    ldstr \" \"" + Environment.NewLine +
                              "    call void [mscorlib]System.Console::Write(string)" + Environment.NewLine +
                              "    ldc.r8 2.5" + Environment.NewLine +
                              "    call void [mscorlib]System.Console::Write(float64)" + Environment.NewLine +
                              "    ldstr \"\\t\"" + Environment.NewLine +
                              "    call void [mscorlib]System.Console::Write(string)" + Environment.NewLine +
                              "    ldstr \"teste\"" + Environment.NewLine +
                              "    call void [mscorlib]System.Console::Write(string)" + Environment.NewLine +
                              "    ldstr \"\\n\"" + Environment.NewLine +
                              "    call void [mscorlib]System.Console::Write(string)" + Environment.NewLine +
                              Ret;
            
            var compilador = new Rules.Compiler();

            compilador.Compile(programa);

            Assert.IsFalse(string.IsNullOrWhiteSpace(compilador.Assembly));
            Assert.AreEqual(expected, compilador.Assembly);
        }

        [TestMethod]
        public void Teste02()
        {
            string programa = "main begin" + Environment.NewLine +
                             "    int: lado, area." + Environment.NewLine +
                             "    write (\"digite um valor para lado: \")." + Environment.NewLine +
                             "    read (lado)." + Environment.NewLine +
                             "    area = lado * lado." + Environment.NewLine +
                             "    write (area)." + Environment.NewLine +
                             "end ";

            string expected = CabecalhoFixo +
                              "    .locals(int64 lado)" + Environment.NewLine +
                              "    .locals(int64 area)" + Environment.NewLine +
                              "    ldstr \"digite um valor para lado: \"" + Environment.NewLine +
                              "    call void [mscorlib]System.Console::Write(string)" + Environment.NewLine +
                              "    call string [mscorlib]System.Console::ReadLine()" + Environment.NewLine +
                              "    call int64 [mscorlib]System.Int64::Parse(string)" + Environment.NewLine +
                              "    stloc lado" + Environment.NewLine +
                              "    ldloc lado" + Environment.NewLine +
                              "    conv.r8" + Environment.NewLine +
                              "    ldloc lado" + Environment.NewLine +
                              "    conv.r8" + Environment.NewLine +
                              "    mul" + Environment.NewLine +
                              "    conv.i8" + Environment.NewLine +
                              "    stloc area" + Environment.NewLine +
                              "    ldloc area" + Environment.NewLine +
                              "    conv.r8" + Environment.NewLine + // verificar se esta linha derveria existir
                              "    conv.i8" + Environment.NewLine + // verificar se esta linha derveria existir
                              "    call void [mscorlib]System.Console::Write(int64)" + Environment.NewLine +
                              Ret;

            var compilador = new Rules.Compiler();

            compilador.Compile(programa);

            Assert.IsFalse(string.IsNullOrWhiteSpace(compilador.Assembly));
            Assert.AreEqual(expected, compilador.Assembly);
        }

        [TestMethod]
        public void Teste03()
        {
            string programa = "main begin" + Environment.NewLine +
                              "    int: lado, area." + Environment.NewLine +
                              "    read (lado)." + Environment.NewLine +
                              "    area = 0." + Environment.NewLine +
                              "    (lado > 0) ifTrueDo area = lado * lado. end." + Environment.NewLine +
                              "    write (area)." + Environment.NewLine +
                              "end ";

            string expected = CabecalhoFixo +
                              "    .locals(int64 lado)" + Environment.NewLine +
                              "    .locals(int64 area)" + Environment.NewLine +
                              "    call string [mscorlib]System.Console::ReadLine()" + Environment.NewLine +
                              "    call int64 [mscorlib]System.Int64::Parse(string)" + Environment.NewLine +
                              "    stloc lado" + Environment.NewLine +
                              "    ldc.i8 0" + Environment.NewLine +
                              "    conv.r8" + Environment.NewLine +
                              "    conv.i8" + Environment.NewLine +
                              "    stloc area" + Environment.NewLine +
                              "    label1:" + Environment.NewLine +
                              "    ldloc lado" + Environment.NewLine +
                              "    conv.r8" + Environment.NewLine +
                              "    ldc.i8 0" + Environment.NewLine +
                              "    conv.r8" + Environment.NewLine +
                              "    cgt" + Environment.NewLine +
                              "    brfalse label2" + Environment.NewLine +
                              "    ldloc lado" + Environment.NewLine +
                              "    conv.r8" + Environment.NewLine +
                              "    ldloc lado" + Environment.NewLine +
                              "    conv.r8" + Environment.NewLine +
                              "    mul" + Environment.NewLine +
                              "    conv.i8" + Environment.NewLine +
                              "    stloc area" + Environment.NewLine +
                              "    label2:" + Environment.NewLine +
                              "    ldloc area" + Environment.NewLine +
                              "    conv.r8" + Environment.NewLine + // verificar se esta linha derveria existir
                              "    conv.i8" + Environment.NewLine + // verificar se esta linha derveria existir
                              "    call void [mscorlib]System.Console::Write(int64)" + Environment.NewLine +
                              Ret;

            var compilador = new Rules.Compiler();

            compilador.Compile(programa);

            Assert.IsFalse(string.IsNullOrWhiteSpace(compilador.Assembly));
            Assert.AreEqual(expected, compilador.Assembly);
        }

        [TestMethod]
        public void Teste04()
        {
            string programa = "main begin" + Environment.NewLine +
                              "    float: valor." + Environment.NewLine +
                              "    read (valor)." + Environment.NewLine +
                              "    (valor > 0.0) ifTrueDo write (\"maior\")." + Environment.NewLine +
                              "                  ifFalseDo write (\"menor ou igual\"). end." + Environment.NewLine +
                              "end";

            string expected = CabecalhoFixo +
                              "    .locals(float64 valor)" + Environment.NewLine +
                              "    call string [mscorlib]System.Console::ReadLine()" + Environment.NewLine +
                              "    call float64 [mscorlib]System.Double::Parse(string)" + Environment.NewLine +
                              "    stloc valor" + Environment.NewLine +
                              "    label1:" + Environment.NewLine +
                              "    ldloc valor" + Environment.NewLine +
                              "    ldc.r8 0.0" + Environment.NewLine +
                              "    cgt" + Environment.NewLine +
                              "    brfalse label2" + Environment.NewLine +
                              "    ldstr \"maior\"" + Environment.NewLine +
                              "    call void [mscorlib]System.Console::Write(string)" + Environment.NewLine +
                              "    br label3" + Environment.NewLine +
                              "    label2:" + Environment.NewLine +
                              "    ldstr \"menor ou igual\"" + Environment.NewLine +
                              "    call void [mscorlib]System.Console::Write(string)" + Environment.NewLine +
                              "    label3:" + Environment.NewLine +
                              Ret;

            var compilador = new Rules.Compiler();

            compilador.Compile(programa);

            Assert.IsFalse(string.IsNullOrWhiteSpace(compilador.Assembly));
            Assert.AreEqual(expected, compilador.Assembly);
        }

        [TestMethod]
        public void Teste05()
        {
            string programa = "main begin" + Environment.NewLine +
                              "    int: valor." + Environment.NewLine +
                              "    read (valor)." + Environment.NewLine +
                              "    (valor < 0) whileTrueDo read (valor). end." + Environment.NewLine +
                              "    (valor == 0) whileFalseDo write (valor, \\n)." + Environment.NewLine +
                              "                              valor -= 1. end." + Environment.NewLine +
                              "end";

            string expected = CabecalhoFixo +
                              "    .locals(int64 valor)" + Environment.NewLine +
                              "    call string [mscorlib]System.Console::ReadLine()" + Environment.NewLine +
                              "    call int64 [mscorlib]System.Int64::Parse(string)" + Environment.NewLine +
                              "    stloc valor" + Environment.NewLine +
                              "    label1:" + Environment.NewLine +
                              "    ldloc valor" + Environment.NewLine +
                              "    conv.r8" + Environment.NewLine +
                              "    ldc.i8 0" + Environment.NewLine +
                              "    conv.r8" + Environment.NewLine +
                              "    clt" + Environment.NewLine +
                              "    brfalse label2" + Environment.NewLine +
                              "    call string [mscorlib]System.Console::ReadLine()" + Environment.NewLine +
                              "    call int64 [mscorlib]System.Int64::Parse(string)" + Environment.NewLine +
                              "    stloc valor" + Environment.NewLine +
                              "    br label1" + Environment.NewLine +
                              "    label2:" + Environment.NewLine +
                              "    label3:" + Environment.NewLine +
                              "    ldloc valor" + Environment.NewLine +
                              "    conv.r8" + Environment.NewLine +
                              "    ldc.i8 0" + Environment.NewLine +
                              "    conv.r8" + Environment.NewLine +
                              "    ceq" + Environment.NewLine +
                              "    brtrue label4" + Environment.NewLine +
                              "    ldloc valor" + Environment.NewLine +
                              "    conv.r8" + Environment.NewLine +
                              "    conv.i8" + Environment.NewLine +
                              "    call void [mscorlib]System.Console::Write(int64)" + Environment.NewLine +
                              "    ldstr \"\\n\"" + Environment.NewLine +
                              "    call void [mscorlib]System.Console::Write(string)" + Environment.NewLine +
                              "    ldloc valor" + Environment.NewLine + 
                              "    conv.r8" + Environment.NewLine + 
                              "    ldc.i8 1" + Environment.NewLine +
                              "    conv.r8" + Environment.NewLine +
                              "    sub" + Environment.NewLine + 
                              "    conv.i8" + Environment.NewLine +
                              "    stloc valor" + Environment.NewLine +
                              "    br label3" + Environment.NewLine +
                              "    label4:" + Environment.NewLine +
                              Ret;

            var compilador = new Rules.Compiler();

            compilador.Compile(programa);

            Assert.IsFalse(string.IsNullOrWhiteSpace(compilador.Assembly));
            Assert.AreEqual(expected, compilador.Assembly);
        }

        [TestMethod]
        public void ErroLexico()
        {
            string programa = "main begin" + Environment.NewLine +
                             "    int: lado." + Environment.NewLine +
                             "    write (\"digite um valor para lado: )" + Environment.NewLine +
                             "    read (lado)." + Environment.NewLine +
                             "    area = lado * lado." + Environment.NewLine +
                             "    write (area)." + Environment.NewLine +
                             "end ";

            var compilador = new Rules.Compiler();

            Assert.ThrowsException<LexicalException>(() => compilador.Compile(programa));
        }

        [TestMethod]
        public void ErroSintatico()
        {
            string programa = "main begin" + Environment.NewLine +
                             "    int: lado." + Environment.NewLine +
                             "    write (\"digite um valor para lado: \")" + Environment.NewLine +
                             "    read (lado)." + Environment.NewLine +
                             "    area = lado * lado." + Environment.NewLine +
                             "    write (area)." + Environment.NewLine +
                             "end ";

            var compilador = new Rules.Compiler();

            Assert.ThrowsException<SyntaticException>(() => compilador.Compile(programa));
        }

        [TestMethod]
        public void ErroSemantico()
        {
            string programa = "main begin" + Environment.NewLine +
                             "    int: lado." + Environment.NewLine +
                             "    write (\"digite um valor para lado: \")." + Environment.NewLine +
                             "    read (lado)." + Environment.NewLine +
                             "    area = lado * lado." + Environment.NewLine +
                             "    write (area)." + Environment.NewLine +
                             "end ";

            var compilador = new Rules.Compiler();

            Assert.ThrowsException<SemanticException>(() => compilador.Compile(programa));
        }
    }
}
