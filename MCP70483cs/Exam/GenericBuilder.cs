using System;
using MCP70483cs.Example4;

namespace MCP70483cs.Exam
{
    internal class GenericBuilder<T> : IDisposable
        where T : new()
    {
        private T resrouce;

        public void Dispose()
        {
            Console.WriteLine("Dispose called");
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public T Build()
        {
            resrouce = new T();
            return resrouce;
        }

        ~GenericBuilder()
        {
            // managed resrouce
            Console.WriteLine("finalizer called");
            Dispose(false);
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
                if (resrouce != null) (resrouce as IDisposable)?.Dispose();
        }
    }

    public class GenericBuilderWork
    {
        public static void DoProc()
        {
            // if unmanaged resource, surround by using
            //using (var builder = new GenericBuilder<Person4>())
            //{
            //    var instance = builder.Build();
            //    Console.WriteLine(instance.ToString());
            //}

            // if not unmanaged resource
            var builder = new GenericBuilder<Person4>();
            var instance = builder.Build();
            Console.WriteLine(instance.ToString());


        }
    }
}