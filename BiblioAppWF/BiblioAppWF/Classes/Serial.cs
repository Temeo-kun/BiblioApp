using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioAppWF.Classes
{
    public enum SerialInd {All=0, Book=1, Discover=2}
    public class Serial
    {
        public string name { get; set; }
        public SerialInd serialind { get; set; }

        public string getname
        {
            get
            {
                string prefix = "";

                switch ((int)serialind)
                {
                    case 1:
                        prefix = "Серия книг ";
                        break;
                    case 2:
                        prefix = "Серия журналов ";
                        break;
                    default:
                        break;
                }
                return prefix + name;
            }
        }

        public Serial() { }
        public Serial(string _name, SerialInd sr_nd)
        {
            name = _name;
            serialind = sr_nd;
        }
    }
}
