using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioAppWF.Classes
{
    public class RdUser
    {
        public string uid { get; set; }
        public string name { get; set; }
        public string mail { get; set; }

        public string getnamemail
        {
            get
            {
                return name + " (" + mail + ")";
            }
        }

        public RdUser()
        {

        }

        public RdUser (string _name, string _email)
        {
            uid = Guid.NewGuid().ToString();
            name = _name;
            mail = _email;
        }

    }
}
