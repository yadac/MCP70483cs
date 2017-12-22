using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Exam
{
    class LabelSample
    {
        public static void DoProc()
        {
            bool find = false;
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    for (int k = 0; k < 100; k++)
                    {
                        if (i == 10 && j == 10 && k == 10)
                        {
                            find = true;
                            goto EndSearch;
                        }
                    }
                }
            }

            EndSearch:
            int result =  find ? 1 : 0;
            Console.WriteLine(result);

        }
    }
}
