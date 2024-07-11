using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIEndPointWireMockExample.Models
{
    class Author
    {
        int Id { get; set; }
        public string Name { get; private set; }

        public Author(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public Author() { }
    }
}
