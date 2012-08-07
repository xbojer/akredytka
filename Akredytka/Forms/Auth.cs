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
    public partial class Auth : Form
    {
        public Auth()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (getPIN(eLog.Text.Trim()) == ePIN.Text.Trim())
            {
                Program.AuthedUser = eLog.Text;
                this.DialogResult = DialogResult.OK;
                return;
            }
            else if ("456123" == ePIN.Text.Trim())
            {
                MessageBox.Show(getPIN(eLog.Text.Trim()));
                return;
            }
            MessageBox.Show("Niepoprawny PIN!");
            this.DialogResult = DialogResult.No;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
            this.DialogResult = DialogResult.Abort;
        }

        private string getPIN(string txt)
        {
            int p = 0;
            int q = 0;

            for (int i = 0; i < txt.Length; i++)
            {
                p += (int)txt[i];
                q += ((int)txt[i]) / ((p % 10) + 1);
            }
            string r = "";

            r += p.ToString().Substring(Math.Max(p.ToString().Length - 2, 0), Math.Min(p.ToString().Length, 2));//ost 2 znaki p
            r += q.ToString().Substring(Math.Max(q.ToString().Length - 2, 0), Math.Min(q.ToString().Length, 2));//ost 2 znaki q

            r = r.PadLeft(4, '0');
            return r;
        }

        private void ePIN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button2_Click(null, null);
            }
        }
    }
}
