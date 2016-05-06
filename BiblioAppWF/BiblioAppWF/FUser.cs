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
    public partial class FUser : Form
    {
        Bibliothek bib;
        public FUser()
        {
            InitializeComponent();
            bib = Bibliothek.GetBib();
            rdUserBindingSource.DataSource = bib.RdUsers;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bib.AddRdUser(textBox1.Text, textBox2.Text);
        }
    }
}
