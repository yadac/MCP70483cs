using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CSharp;

namespace MCP70483cs.Example2
{
    class Example2_74
    {
        public static void DoProc()
        {
            CodeCompileUnit compileUnit = new CodeCompileUnit();
            CodeNamespace myNamespace = new CodeNamespace("MyNamespace");
            myNamespace.Imports.Add(new CodeNamespaceImport("System"));
            CodeTypeDeclaration myClass = new CodeTypeDeclaration("MyClass");
            CodeEntryPointMethod start = new CodeEntryPointMethod();
            CodeMethodInvokeExpression csl = new CodeMethodInvokeExpression(
                new CodeTypeReferenceExpression("Console"),
                "WriteLine",
                new CodePrimitiveExpression("Hello World!"));

            compileUnit.Namespaces.Add(myNamespace);
            myNamespace.Types.Add(myClass);
            myClass.Members.Add(start);
            start.Statements.Add(csl);

            CSharpCodeProvider provider = new CSharpCodeProvider();
            using (StreamWriter sw = new StreamWriter("243.cs", false))
            {
                IndentedTextWriter tw = new IndentedTextWriter(sw, "    ");
                provider.GenerateCodeFromCompileUnit(compileUnit
                    , tw
                    , new CodeGeneratorOptions());
                tw.Close();
            }
        }




    }
}
