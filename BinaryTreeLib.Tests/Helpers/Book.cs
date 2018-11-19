using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeLib.Tests.Helpers
{
    public class Book : IComparable<Book>
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int PagesAmount { get; set; }

        public Book(string title, string author, int pagesAmount)
        {
            if (pagesAmount <= 0)
            {
                throw new ArgumentNullException($"Amount of pages must be more than 0");
            }
            Title = title;
            Author = author;
            PagesAmount = pagesAmount;
        }
        public int CompareTo(Book other)
        {
            if (Title == other.Title && Author == other.Author)
                return 0;
            if (Title.Length < other.Title.Length)
            {
                return -1;
            }
            return 1;
        }
    }
}
