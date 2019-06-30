using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rules;

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
        public void EsquemaTraducao_V1()
        {
            string programa = "main begin write(1, \\s, 2.5, \\t, \"teste\", \\n). end";

            string expected = CabecalhoFixo +
                              "    ldc.i8 1" + Environment.NewLine +
                              "    conv.r8" + Environment.NewLine +
                              "    conv.i8" + Environment.NewLine +
                              "    call void [mscorlib]System.Console::Write(int64)" + Environment.NewLine +
                              "    ldstr \" \"" + Environment.NewLine +
                              "    call void [mscorlib]System.Console::Write(string)" + Environment.NewLine +
                              "    ldc.i8 2.5" + Environment.NewLine +
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
                              "    conv.r8" + Environment.NewLine +
                              "    conv.i8" + Environment.NewLine +
                              "    call void [mscorlib]System.Console::Write(int64)" + Environment.NewLine +
                              Ret;

            var compilador = new Rules.Compiler();

            compilador.Compile(programa);

            Assert.IsFalse(string.IsNullOrWhiteSpace(compilador.Assembly));
            Assert.AreEqual(expected, compilador.Assembly);
        }
    }
}
