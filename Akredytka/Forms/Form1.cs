using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BrightIdeasSoftware;
using BrightIdeasSoftware.Design;
using Akredytka.DB;
using Akredytka.Classes;
using System.Data.Objects;
using Akredytka.Forms;

namespace Akredytka
{
    public partial class Form1 : Form
    {
        C L;
        public Form1()
        {
            InitializeComponent();
            if ((new Auth()).ShowDialog() != DialogResult.OK)
            {
                if (Application.MessageLoop == true)
                {
                    Application.Exit();
                }
                else
                {
                    System.Environment.Exit(1);
                }
                throw new Exception("Błąd autoryzacji!");
            }
            LDB.init();
            L = new C();
        }
        #region TextBox Focus
        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "TU WPISZ DANE OSOBY")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "TU WPISZ DANE OSOBY";
                textBox1.ForeColor = Color.FromArgb(224, 224, 224);
            }
        }
        private void fastObjectListView1_Click(object sender, EventArgs e)
        {
            textBox1.Focus();
        }
        #endregion
        #region TextBox KeyUpDown
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                textBox1.Text = "";
            }
            TextBox tb = (TextBox)sender;
            string t = tb.Text;
            if (t.Length >= 1)
            {
                string[] a = t.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                ObjectQuery<Bydlo> c = L.Bydloes.Where("it.jest = false");

                int i = 0;
                foreach (string b in a)
                {
                    c = c.Where("it.imie LIKE @param" + i.ToString() + 
                        " OR it.nazwisko LIKE @param" + i.ToString() +
                        " OR it.nick LIKE @param" + i.ToString() +
                        " OR it.pesel LIKE @param" + i.ToString() +
                        " OR it.dowod LIKE @param" + i.ToString(),
                        new ObjectParameter("param" + i.ToString(), String.Format("%{0}%", b))
                    );
                    i++;
                }
                List<Bydlo> r = c.ToList();
                RL.SetObjects(r);
                if (r.Count == 0)
                {
                    RL.EmptyListMsg = "Brak danych";
                }
            }
            else
            {
                RL.EmptyListMsg = "Zacznij wpisywać dane...";
                RL.ClearObjects();
            }
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                button2_Click(null, null);
            }
            else if (e.KeyCode == Keys.Up)
            {
                e.SuppressKeyPress = true;
                if (RL.SelectedIndex == -1) RL.SelectedIndex = 0;
                else if (RL.SelectedIndex == 0) RL.SelectedIndex = RL.GetItemCount() - 1;
                else RL.SelectedIndex--;
                if (RL.SelectedItem != null) RL.SelectedItem.EnsureVisible();
            }
            else if (e.KeyCode == Keys.Down)
            {
                e.SuppressKeyPress = true;
                if (RL.SelectedIndex == -1) RL.SelectedIndex = 0;
                else if (RL.SelectedIndex == RL.GetItemCount() - 1) RL.SelectedIndex = 0;
                else RL.SelectedIndex++;
                if (RL.SelectedItem != null) RL.SelectedItem.EnsureVisible();
            }
            else if (e.KeyCode == Keys.L && e.Control && !e.Shift && !e.Alt)
            {
                Hide();
                if ((new Auth()).ShowDialog() != DialogResult.OK)
                {
                    if (Application.MessageLoop == true)
                    {
                        Application.Exit();
                    }
                    else
                    {
                        System.Environment.Exit(1);
                    }
                    throw new Exception("Błąd autoryzacji!");
                }
                Show();
            }
        }
        #endregion
        #region ResultList Misc
        private void fastObjectListView1_FormatCell(object sender, FormatCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                Bydlo data = (Bydlo)e.Model;
                e.Item.Text = "";
                NamedDescriptionDecoration decoration = new NamedDescriptionDecoration();
                decoration.Title = data.Nazwisko + " " + data.Imie;
                decoration.Description = data.pesel + ";" + data.dowod;
                e.SubItem.Decoration = decoration;
            }
        }
        #endregion

        private void button3_Click(object sender, EventArgs e)
        {
            StupidBydlo sb = new StupidBydlo();
            if (sb.ShowDialog() == DialogResult.OK)
            {
                Bydlo nowy = new Bydlo();
                nowy.Id = (int)DateTime.Now.Ticks;
                nowy.Imie = sb.imie;
                nowy.Nazwisko = sb.nazwisko;
                nowy.dowod = sb.dowod;
                nowy.pesel = sb.pesel;
                nowy.adres = sb.adres;
                nowy.jest = true;
                L.AddToBydloes(nowy);
                L.SaveChanges();
                MessageBox.Show("Dane zapisane.");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (RL.SelectedObject != null)
            {
                Bydlo p = (Bydlo)RL.SelectedObject;
                DialogResult r = MessageBox.Show(null, 
                    "Czy na pewno wpuścić osobę:\n" +
                    p.Imie + " " + p.Nazwisko + "\n" +
                    "PESEL: "+ p.pesel + "\n" +
                    "na konwent?",
                    "Potwierdź tożsamość", 
                    MessageBoxButtons.YesNo
                );
                if (r == DialogResult.Yes)
                {
                    p.jest = true;
                    L.SaveChanges();
                }
            }

            else
            {
                MessageBox.Show("Nie ma kogo wpuścić?!");
            }
        }
        private void cofnij_Click(object sender, EventArgs e)
        {

        }
    }
}
