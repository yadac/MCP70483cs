using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Exam
{
    class ExamProduct : INotifyPropertyChanging
    {
        private double _listPrice;

        public double ListPrice
        {
            get { return this._listPrice; }
            set
            {
                if (value != this._listPrice)
                {
                    this.OnListPropertyChanging(value);
                    this.OnPropertyChanging("ListPrice");
                    this._listPrice = value;
                }
            }
        }

        private void OnListPropertyChanging(double value)
        {
            Console.WriteLine("OnListPropertyChanging called");
        }

        public ExamProduct()
        {
            // allcates process to event
            PropertyChanging += (sender, args) =>
            {
                Console.WriteLine($"{args.PropertyName} is changed!!");
            };
        }

        public event PropertyChangingEventHandler PropertyChanging;

        protected virtual void OnPropertyChanging(string propertyName)
        {
            var ev = this.PropertyChanging;
            if (ev != null)
            {
                ev(this, new PropertyChangingEventArgs(propertyName));
            }
        }

    }

    public class ExamProductWork
    {
        public static void DoProc()
        {
            var product = new ExamProduct();
            product.ListPrice = 100.0;
        }
    }
}
