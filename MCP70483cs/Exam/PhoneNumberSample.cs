using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Exam
{
    class PhoneNumberSample
    {
        private string _digits;

        public string Digits
        {
            get { return this._digits; }
            set
            {
                if (value.Length != 10) throw new ArgumentException();
                this._digits = value;
            }
        }
    }

    public class PhoneNumberSampleWork
    {
        public static void DoProc()
        {
            var instance = new PhoneNumberSample() { Digits = "0123456789" };
            var fp = new PhoneNumberFormatterSample();
            Console.WriteLine(string.Format(fp, "{0}", instance));

            // fp = providing an instance of any class that implements iformatprovider.
            // string.format() calls the GetFormat(), passing the ICustomerFormatter datatype as the argument.
            // string.format() calls the Format(), passing the format string, the object to be formatted, and the IFormatProvider instance. 
        }
    }

    public class PhoneNumberFormatterSample : ICustomFormatter, IFormatProvider
    {
        // 変換を行うフォーマッタを取得するための処理
        public object GetFormat(Type formatType)
        {
            // formaType = PhoneNumberFormatterSample.
            // ICustomFormatter and IFormatProvider implements same class. So return this.
            if (formatType == typeof(ICustomFormatter)) return this;
            else return null;
        }

        /// <summary>
        /// 書式指定子から適切な書式の文字列へと変換する処理 
        /// </summary>
        /// <param name="format">format string</param>
        /// <param name="arg">the object to be formatted</param>
        /// <param name="formatProvider">IFormatProvider instance</param>
        /// <returns></returns>
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            
            if (arg is PhoneNumberSample)
            {
                var num = (PhoneNumberSample)arg;
                return
                    $"({num.Digits.Substring(0, 3)}){ num.Digits.Substring(3, 3)}-{ num.Digits.Substring(6, 4)}";
            }
            else if (string.IsNullOrEmpty(format))
                return arg.ToString();
            else
                return string.Format("{0:" + format + "}", arg);
        }
    }
}
