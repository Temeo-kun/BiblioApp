using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BiblioAppWF.Classes;
using BiblioAppWF.Controllers;

namespace BiblioAppWF
{
    public partial class FSerial : Form
    {
        Bibliothek bib;
        public FSerial()
        {
            InitializeComponent();
            bib = Bibliothek.GetBib();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SerialInd ind = SerialInd.Book;
            try
            {
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        ind = SerialInd.Book;
                        break;
                    case 1:
                        ind = SerialInd.Discover;
                        break;
                    default:
                        ind = SerialInd.Book;
                        break;
                }
            }
            catch { }

            bib.AddSerial(textBox1.Text, ind);
        }
    }
}
