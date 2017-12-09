using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example4
{
    // caller
    public class Example4_40
    {
        public static void DoProc()
        {
            // WCFアプリケーションを作成
            // WCFアプリケーションをAzureのApp Serviceにpublishする（deployと同じ）
            // 利用する側のプロジェクトでServiceReferenceとして追加する
            // 追加する際はurl+svcファイルがパスになる（ここではサービス名をServiceReference1とした）
            // あとはサービス提供側のinterface（OperationContract）で定義したメソッドをサービスとして呼び出す
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            string result = client.DoWork("John", "Doe");
            Console.WriteLine(result);
        }
    }
}

