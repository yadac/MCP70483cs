using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Core;

namespace MCP70483cs
{

    internal delegate int Calc(int x, int y);

    class EHandlerSample
    {
        public event EventHandler Processed;

        public void DoSampleProc()
        {
            // delegate
            // delegate 戻り値 デリゲート型(引数)

            // .net 1.0
            // デリゲート型 変数 = new デリゲート型(移譲先メソッド)
            var calc = new Calc(SampleCalc1);

            // .net 2.0
            // デリゲート型 変数 = 移譲先メソッド
            calc += SampleCalc2;

            // override last called method, 10 * 20 = 200 is returned.
            var result = calc(10, 20);
            Console.WriteLine(result);

            // subscribe event
            Processed += SampleEvent1;
            Processed += SampleEvent2;
            Processed -= SampleEvent1;

            // no parameter
            Processed += (o, e) => ShowCompleted();

            // event raise
            Processed(this, EventArgs.Empty);

            // predicate
            Under10Array(new int[] { 8, 9, 10 }, IsUnder10);
        }

        public bool IsUnder10(int a)
        {
            return a < 10;
        }

        public int[] Under10Array(int[] array, Func<int, bool> pred)
        {
            return array.Where(i => pred(i)).ToArray();
        }

        public static void DoProc()
        {
            var ins = new EHandlerSample();
            ins.DoSampleProc();

        }

        private string ShowCompleted()
        {
            Console.WriteLine($"no parameter method {this.ToString()}");
            return "hello";
        }

        public void SampleEvent1(object sender, EventArgs e)
        {
            Console.WriteLine(System.Reflection.MethodInfo.GetCurrentMethod().Name);
        }
        public void SampleEvent2(object sender, EventArgs e)
        {
            Console.WriteLine(System.Reflection.MethodInfo.GetCurrentMethod().Name);
        }

        public int SampleCalc1(int x, int y)
        {
            return x + y;
        }

        public int SampleCalc2(int x, int y)
        {
            return x * y;
        }

    }
}
