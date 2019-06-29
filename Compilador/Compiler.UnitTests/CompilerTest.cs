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
        [TestMethod]
        public void EsquemaTraducao_V1()
        {
            string programa = "main begin write(1, \\s, 2.5, \\t, \"teste\", \\n). end";
            string expected = ".assembly extern mscorlib {}" + Environment.NewLine +
                              ".assembly _codigo_objeto {}" + Environment.NewLine +
                              ".module   _codigo_object.exe" + Environment.NewLine +
                              "" + Environment.NewLine +
                              ".class public _UNICA {" + Environment.NewLine +
                              "" + Environment.NewLine +
                              ".method static public void _principal() {" + Environment.NewLine +
                              "    .entrypoint" + Environment.NewLine +
                              "" + Environment.NewLine +
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
                              "" + Environment.NewLine +
                              "    ret" + Environment.NewLine +
                              "    }" + Environment.NewLine +
                              "}";

            var compilador = new Rules.Compiler();

            compilador.Compile(programa);

            Assert.IsFalse(string.IsNullOrWhiteSpace(compilador.Assembly));
            Assert.AreEqual(expected, compilador.Assembly);
        }
    }
}
