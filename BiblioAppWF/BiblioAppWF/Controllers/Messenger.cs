using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BiblioAppWF.Controllers
{
    public static class MyAppInfo
    {
        public static string ExecuteFolder
        {
            get
            {
                string str = Application.ExecutablePath;
                string namef = "";
                for (int i = 0; i <= str.LastIndexOf('\\'); i++)
                {
                    namef = namef + str[i];
                }
                string filename = namef;
                return filename;
            }
        }
    }
    public static class History
    {
        private static List<Bibliothek> states;

        public static void Pop(Bibliothek bib)
        {
            if (states == null)
            {
                states = new List<Bibliothek>();
                states.Add(bib);
            }

        }
        public static Bibliothek Push()
        {
            if (states.Count > 0)
            {
                Bibliothek bib = states.Last();
                states.RemoveAt(states.Count - 1);
                return bib;
            }
            else
            {
                return null;
            }
        }
    }
    public static class Messenger
    {
        public static void GetMsg(string msg)
        {
            var now = DateTime.Now;
            MessageBox.Show(msg);
            File.AppendAllText(MyAppInfo.ExecuteFolder + "log.txt", string.Format("\r\n{0:dd.MM.yyyy_HH:mm} _: {1}", now, msg));
        }
    }
}
