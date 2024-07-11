using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIEndPointWireMockExample.Models
{
    class Book : LibraryItem
    {
        Author Author { get; set; }
        bool IsBorrowed { get; set; }

        public Book(int id, string title, Author author, bool isBorrowed)
            : base(id, title)
        {
            Author = author;
            IsBorrowed = isBorrowed;
        }

        public override string ToString()
        {
            return base.ToString() + $", Author = {Author.Name}, IsBorrowed = {IsBorrowed}";
        }
    }
}
