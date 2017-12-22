using System;
using System.ComponentModel;

namespace MCP70483cs.Exam
{
    internal class ExamProduct : INotifyPropertyChanging
    {
        private double _listPrice;

        public ExamProduct()
        {
            // allcates process to event
            PropertyChanging += (sender, args) => { Console.WriteLine($"{args.PropertyName} is changed!!"); };
        }

        public double ListPrice
        {
            get => _listPrice;
            set
            {
                if (value != _listPrice)
                {
                    OnListPropertyChanging(value);
                    OnPropertyChanging("ListPrice");
                    _listPrice = value;
                }
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        private void OnListPropertyChanging(double value)
        {
            Console.WriteLine("OnListPropertyChanging called");
        }

        protected virtual void OnPropertyChanging(string propertyName)
        {
            var ev = PropertyChanging;
            if (ev != null)
                ev(this, new PropertyChangingEventArgs(propertyName));
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