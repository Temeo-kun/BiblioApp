using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiblioAppWF.Classes;
using System.Xml.Serialization;
using System.Xml;

namespace BiblioAppWF.Controllers
{
    public class Bibliothek
    {
        private static Bibliothek bib;

        public List<Author> Authors { get; set; }
        public List<Serial> Serials { get; set; }
        public List<RdUser> RdUsers { get; set; }

        public List<Book> Books { get; set; }
        public List<UseBook> UseBook_s { get; set; }

        private Bibliothek()
        {
            
        }

        public static void Load()
        {
            try
            {
                var s = new XmlSerializer(typeof(Bibliothek));
                var w = XmlReader.Create("Biblio.xml");
                var dc = (s.Deserialize(w)) as Bibliothek;
                w.Close();
                bib = dc;
            }
            catch (Exception)
            {
                bib = new Bibliothek();
                bib.Authors = new List<Author>();
                bib.Serials = new List<Serial>();
                bib.RdUsers = new List<RdUser>();

                bib.Books = new List<Book>();
                bib.UseBook_s = new List<UseBook>();
                Messenger.GetMsg("Не удалось загрузить данные");
            }
        }
        public static void Save()
        {
            try
            {
                var s1 = new XmlSerializer(typeof(Bibliothek));
                var w1 = XmlWriter.Create("Biblio.xml");
                s1.Serialize(w1, bib);
                w1.Close();
            }
            catch {
                throw;
                Messenger.GetMsg("Не удалось сохранить данные");
            }            
        }

        public static Bibliothek GetBib()
        {
            if (bib == null )
            {
                bib = new Bibliothek();
                try
                {
                    Load();
                }
                catch { }
            }
            return bib;
        }

        public void AddSerial(string name, SerialInd ind)
        {
            if (name != "")
            {
                try
                {
                    Serial s = Serials.FirstOrDefault(x => x.name.ToLower() == name.ToLower());
                    if (s == null)
                    {
                        s = new Serial(name, ind);
                        Serials.Add(s);
                    }
                }
                catch (Exception)
                {
                    Messenger.GetMsg("Ошибка при создании серии");
                }
            }
            else
            {
                Messenger.GetMsg("Не введено имя серии");
            }
        }
        public void AddAuthor(string uid, string fullfio)
        {
            int space1 = 0;
            int space2 = 0;
            string family = "";
            string name = "";
            string lastname = "";
            space1 = fullfio.IndexOf(" ");
            if (space1 < 1)
            {
                family = fullfio;
                name = "";
                lastname = "";
            }
            else
            {
                family = fullfio.Substring(0, space1);
                fullfio = fullfio.Remove(0, space1 + 1);

                space2 = fullfio.IndexOf(" ");
                if (space2 < 1)
                {
                    name = fullfio;
                    lastname = "";
                }
                else
                {
                    name = fullfio.Substring(0, space2);
                    lastname = fullfio.Substring(space2 + 1);
                }
            }

            Author a = Authors.FirstOrDefault(x => x.family == family && x.name == name);
            if (a == null)
            {
                a = Authors.FirstOrDefault(x => x.family == family);
            }
            if (a == null)
            {
                a = new Author(family, name, lastname);
                Authors.Add(a);
            }
        }
        public void AddRdUser(string name, string email)
        {
            var ru = RdUsers.FirstOrDefault(x => x.mail == email);
            if (ru == null)
            {
                ru = RdUsers.FirstOrDefault(x => x.name == name);
            }
            if (ru == null)
            {
                RdUsers.Add(new RdUser(name, email));
            }
        }
    }
}
