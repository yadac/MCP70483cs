using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Exam
{
    public class QuerySample
    {
        public static void DoProc()
        {
            var books = Book.GetBooks();
            // var result = books.Select(b => new { b.ISBN, b.Title, b.Publisher.Name });
            var result = from n in books
                         select new { n.ISBN, n.Title, n.Publisher.Name };
            foreach (var item in result)
            {
                Console.WriteLine($"isbn = {item.ISBN}, title = {item.Title}, publisher = {item.Name}");
            }
        }

    }

    public class Publisher
    {
        public string Name;
    }

    public class Book
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public Publisher Publisher { get; set; }

        public static List<Book> GetBooks()
        {
            return new List<Book>()
            {
                new Book
                {
                    ISBN = "aaa",
                    Title = "C#",
                    Publisher = new Publisher {Name = "eron"}
                },
                new Book
                {
                    ISBN = "qqq",
                    Title = "Q#",
                    Publisher = new Publisher {Name = "mask"}
                },
            };
        }

    }
}
