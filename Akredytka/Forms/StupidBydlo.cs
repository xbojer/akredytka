using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Akredytka.Forms
{
    public partial class StupidBydlo : Form
    {
        public StupidBydlo()
        {
            InitializeComponent();
        }

        public string imie = "";
        public string nazwisko = "";
        public string pesel = "";
        public string dowod = "";
        public string adres = "";


        private void button2_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text.Length == 0
                || textBox2.Text.Length == 0
                || textBox3.Text.Length == 0
                || textBox4.Text.Length == 0
                || textBox5.Text.Length == 0
            )
            {
                MessageBox.Show("NIE PODAŁEŚ WYMAGANYCH DANYCH!");
            }
            else
            {
                imie = textBox1.Text;
                nazwisko = textBox3.Text;
                pesel = textBox4.Text;
                dowod = textBox5.Text;
                adres = textBox2.Text;
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
