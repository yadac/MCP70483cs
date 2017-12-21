using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Exam
{
    class MainWindow<T> : MyWindow
        where T : INotifyPropertyChanging, new ()
    {
        public T DataContext { get; set; }

        public MainWindow()
        {
            this.DataContext = new T();
        }

        public MainWindow(T viewModel)
        {
            this.DataContext = viewModel;
        }
    }

    internal class MyWindow
    {
    }

    internal class MyContext { }
}
