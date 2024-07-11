using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIEndPointWireMockExample.Models
{
    class LibraryItem
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public LibraryItem(int id, string title)
        {
            Id = id;
            Title = title; 
        }

        public override string ToString()
        {
            return $"Id= {Id}, + Title= {Title}";
        }
    }
}
