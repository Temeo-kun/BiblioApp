using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BiblioAppWF.Controllers;
using BiblioAppWF.Classes;

namespace BiblioAppWF
{
    public partial class FAuthor : Form
    {
        Bibliothek bib;
        public FAuthor()
        {
            InitializeComponent();
            bib = Bibliothek.GetBib();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                Author a = new Author(textBox1.Text, textBox2.Text, textBox3.Text);
                var olda = bib.Authors.FirstOrDefault(x => x.fio_light == a.fio_light);
                if (olda == null)
                {
                    olda = bib.Authors.FirstOrDefault(x => x.family == a.family);
                }
                if (olda == null)
                {
                    bib.Authors.Add(a);
                }
            }
        }
    }
}
