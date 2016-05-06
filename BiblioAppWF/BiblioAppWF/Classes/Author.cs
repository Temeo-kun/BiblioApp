using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioAppWF.Classes
{
    public class Author
    {
        public string uid { get; set; }

        public string family { get; set; }
        public string name { get; set; }
        public string secondname { get; set; }

        public string fio_light
        {
            get
            {
                string res = family;
                if (name.Length >= 1)
                {
                    res = res + " " + name[0] + ".";
                    if (secondname.Length >= 1)
                    {
                        res = res + secondname[0] + ".";
                    }
                }
                return res;
            }
        }

        public string fio_full
        {
            get
            {
                string res = family;
                if (name.Length >= 1)
                {
                    res = res + " " + name;
                    if (secondname.Length >= 1)
                    {
                        res = res + " " + secondname;
                    }
                }
                return res;
            }
        }

        public Author() { }

        public Author(string _fio, string _name, string _secondname)
        {
            uid = Guid.NewGuid().ToString();
            family = _fio;
            name = _name;
            secondname = _secondname;
        }
    }
}
