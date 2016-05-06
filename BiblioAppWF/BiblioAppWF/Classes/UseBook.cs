using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioAppWF.Classes
{
    public class UseBook
    {
        public Book book { get; set; }
        public RdUser ruser { get; set; }

        public DateTime dateuse_start { get; set; }
        public DateTime dateuse_end { get; set; }

        bool notdateend { get; set; }
        bool overdue { get; set; }

        public string book_name
        {
            get
            {
                return book.name;
            }
        }
        public string user_name
        {
            get
            {
                return ruser.name;
            }
            set
            {
                if (value != "")
                {
                    ruser.name = value;
                }
            }
        }
        public string user_mail
        {
            get
            {
                return ruser.mail;
            }
            set
            {
                if (value != "")
                {
                    ruser.mail = value;
                }
            }
        }
        public string overdue_st
        {
            get
            {
                if (notdateend)
                {
                    if (overdue)
                    {
                        return "возвращена";
                    }
                    else
                    {
                        return "на руках";
                    }
                }
                else
                {
                    if (overdue)
                    {
                        return "возвращена";
                    }
                    else
                    {
                        if (DateTime.Today.Date <= dateuse_end.Date)
                        {
                            return "на руках";
                        }
                        else
                        {
                            return "не возвращена";
                        }
                    }
                }
            }
        }
    }
}
