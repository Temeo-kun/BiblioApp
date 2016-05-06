using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioAppWF.Classes
{
    public class Book
    {
        public string uid { get; set; }

        public string name { get; set; }
        public string descript { get; set; }

        public string location { get; set; }

        public Serial serial { get; set; }
        public Author author { get; set; }

        public string isbn { get; set; }
        public string code { get; set; }

        public int pages { get; set; }

        public string label_pic_path { get; set; }

        public Book() { }
        public Book (string _name, string _desc, string _location, Serial _serial, 
                    Author _Author, string _isbn, string _code, int _pages, string _path)
        {
            name = _name;
            descript = _desc;
            location = _location;
            serial = _serial;
            author = _Author;
            isbn = _isbn;
            code = _code;
            pages = _pages;
            label_pic_path = _path;
        }
    }
}
