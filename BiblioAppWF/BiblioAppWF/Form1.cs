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
    public partial class Form1 : Form
    {
        Bibliothek bib;
        Serial seria;
        Book book;
        public Form1()
        {
            InitializeComponent();
            bib = Bibliothek.GetBib();
            
            serialBindingSource.DataSource = bib.Serials;
            authorBindingSource.DataSource = bib.Authors;
            bookBindingSource.DataSource = bib.Books;

            book = null;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FSerial frm = new FSerial();
            frm.ShowDialog();
            serialBindingSource.DataSource = bib.Serials;
            serialBindingSource.ResetBindings(true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FUser frm = new FUser();
            frm.ShowDialog();
            rdUserBindingSource.DataSource = bib.RdUsers;
            rdUserBindingSource.ResetBindings(true);
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            FUser frm = new FUser();
            frm.ShowDialog();
            rdUserBindingSource.DataSource = bib.RdUsers;
            rdUserBindingSource.ResetBindings(true);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (book != null)
            {
                book.descript = tbISBN.Text;
            }
        }
        
        private void cbSerial1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                seria = cbSerial1.SelectedItem as Serial;
                if (seria.name == "Все")
                {
                    bookBindingSource.DataSource = bib.Books;
                }
                bookBindingSource.DataSource = bib.Books.Where(x => x.serial.name == seria.name);
            }
            catch
            {
                bookBindingSource.DataSource = bib.Books;
            }           
        }
        private void lbBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                book = bookBindingSource.List[lbBooks.SelectedIndex] as Book;
                tbNamebook.Text = book.name;
                tbISBN.Text = book.isbn;
                tbCode.Text = book.code;
                tbDesc.Text = book.descript;
                tbLocation.Text = book.location;
                if (book.label_pic_path.Length > 0)
                {
                    pictureBox1.Image = Image.FromFile(MyAppInfo.ExecuteFolder + "Pics\\" + book.label_pic_path);
                }
                else
                {
                    pictureBox1.Image = null;
                    GC.Collect(5, GCCollectionMode.Forced);
                }

            }
            catch (Exception)
            {
                book = null;
            }
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Bibliothek.Save();
        }
    }
}
