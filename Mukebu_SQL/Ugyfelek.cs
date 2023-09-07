using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;

namespace Mukebu_SQL
{
    public partial class Ugyfelek : Form
    {
        DataTable ugyfeltabla = new DataTable();
        private List<string> felvesz = new List<string>();
        private string ir;
        private string olvas;

        private void ElsoBetolt()
        {
            ugyfeltabla.Columns.Add("Dátum", typeof(string));
            ugyfeltabla.Columns.Add("Ügyfélazonosító", typeof(string));
            ugyfeltabla.Columns.Add("Név", typeof(string));
            ugyfeltabla.Columns.Add("Ország", typeof(string));
            ugyfeltabla.Columns.Add("Irányítószám", typeof(string));
            ugyfeltabla.Columns.Add("Település", typeof(string));
            ugyfeltabla.Columns.Add("Cím", typeof(string));
            ugyfeltabla.Columns.Add("Email", typeof(string));
            ugyfeltabla.Columns.Add("Telefon", typeof(string));          

            dataGridView1.DataSource = ugyfeltabla;
            
        }
        private void AzoBetolt()
        {
            MySqlConnection kapcsolat = new MySqlConnection("Server=localhost;User ID=root;Database=vizsga");
            kapcsolat.Open();
            MySqlCommand azonosito = new MySqlCommand("SELECT ugyfelazo FROM ugyfel", kapcsolat);
            MySqlDataReader mrd = azonosito.ExecuteReader();

            while (mrd.Read())
            {
                comboBox8.Items.Add(mrd["ugyfelazo"].ToString());
            }

            kapcsolat.Close();
        }
        private void MezoKitolt()
        {
            MySqlConnection kapcsolat = new MySqlConnection("Server=localhost;User ID=root;Database=vizsga");
            kapcsolat.Open();
            MySqlCommand azonosito = new MySqlCommand("SELECT ugyfelazo, nev, iranyitoszam, orszag, telepules, cim, email, telefon FROM ugyfel WHERE ugyfelazo=@ugyfelazo", kapcsolat);
            azonosito.Parameters.AddWithValue("@ugyfelazo", int.Parse(comboBox8.Text));
            MySqlDataReader mrd = azonosito.ExecuteReader();

            while (mrd.Read())
            {
                textBox2.Text = mrd.GetValue(1).ToString();
                textBox3.Text = mrd.GetValue(5).ToString();
                textBox4.Text = mrd.GetValue(2).ToString();
                textBox5.Text = mrd.GetValue(3).ToString();
                textBox1.Text = mrd.GetValue(4).ToString();
                textBox8.Text = mrd.GetValue(6).ToString();
                textBox6.Text = mrd.GetValue(7).ToString();             
            }

            kapcsolat.Close();
        }
        private void Clear()
        {              
            comboBox8.Text = string.Empty;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox8.Clear();
        }
        private void Felvetel()
        {
            MySqlConnection kapcsolat = new MySqlConnection("Server=localhost;User ID=root;Database=vizsga");
            kapcsolat.Open();
            MySqlCommand felvitel = new MySqlCommand("INSERT INTO ugyfel(nev, iranyitoszam, orszag, telepules, cim, email, telefon) VALUES(@nev, @iranyitoszam, @orszag, @telepules, @cim, @email, @telefon)", kapcsolat);           
            felvitel.Parameters.AddWithValue("@nev", textBox2.Text);
            felvitel.Parameters.AddWithValue("@iranyitoszam", int.Parse(textBox4.Text));
            felvitel.Parameters.AddWithValue("@orszag", textBox5.Text);
            felvitel.Parameters.AddWithValue("@telepules", textBox1.Text);
            felvitel.Parameters.AddWithValue("@cim", textBox3.Text);
            felvitel.Parameters.AddWithValue("@email", textBox8.Text);
            felvitel.Parameters.AddWithValue("@telefon", textBox6.Text);           
            felvitel.ExecuteNonQuery();
            kapcsolat.Close();
            MessageBox.Show("Új ügyfél felvétele megtörtént!");

        }
        private void Modosit()
        {
            MySqlConnection kapcsolat = new MySqlConnection("Server=localhost;User ID=root;Database=vizsga");
            kapcsolat.Open();
            MySqlCommand modosito = new MySqlCommand("UPDATE ugyfel SET ugyfelazo=@ugyfelazo, nev=@nev, iranyitoszam=@iranyitoszam, orszag=@orszag, telepules=@telepules, cim=@cim, email=@email, telefon=@telefon WHERE ugyfelazo=@ugyfelazo", kapcsolat);
            modosito.Parameters.AddWithValue("@ugyfelazo", int.Parse(comboBox8.Text));
            modosito.Parameters.AddWithValue("@nev", textBox2.Text);
            modosito.Parameters.AddWithValue("@iranyitoszam", int.Parse(textBox4.Text));
            modosito.Parameters.AddWithValue("@orszag", textBox5.Text);
            modosito.Parameters.AddWithValue("@telepules", textBox1.Text);
            modosito.Parameters.AddWithValue("@cim", textBox3.Text);
            modosito.Parameters.AddWithValue("@email", textBox8.Text);
            modosito.Parameters.AddWithValue("@telefon", textBox6.Text);
            modosito.ExecuteNonQuery();
            kapcsolat.Close();
            MessageBox.Show("Kijelölt ügyfél adatainak módosítása megtörtént!");
        }
        private void Torles()
        {
            MySqlConnection kapcsolat = new MySqlConnection("Server=localhost;User ID=root;Database=vizsga");
            kapcsolat.Open();
            MySqlCommand torol = new MySqlCommand("DELETE FROM ugyfel WHERE ugyfelazo=@ugyfelazo", kapcsolat);
            torol.Parameters.AddWithValue("@Ugyfelazo", int.Parse(comboBox8.Text));
            torol.ExecuteNonQuery();

            kapcsolat.Close();
            MessageBox.Show("Kijelölt ügyfél törlése megtörtént!");
        }
        private void FileIr()
        {
            if (comboBox7.Text == "Új ügyfél felvétele") { ir = "ugyfelfelvett.txt"; }
            if (comboBox7.Text == "Ügyfél adatainak módosítása") { ir = "ugyfelmodosit.txt"; }
            if (comboBox7.Text == "Ügyfél törlése") { ir = "ugyfeltorol.txt"; }

            StreamWriter iras = File.AppendText(ir);
            for (int i = 0; i < felvesz.Count - 1; i++)
            {
                iras.Write(felvesz[i] + ",");
            }
            iras.Write(felvesz[felvesz.Count - 1]);
            iras.Write("\n");
            iras.Close();
            felvesz.Clear();
        }
        private void FileOlvas()
        {
            if (comboBox1.Text == "Felvitt ügyfelek listája") { olvas = "ugyfelfelvett.txt"; }
            if (comboBox1.Text == "Módosított ügyfelek listája") { olvas = "ugyfelmodosit.txt"; }
            if (comboBox1.Text == "Törölt ügyfelek listája") { olvas = "ugyfeltorol.txt"; }

            string[] sorok = File.ReadAllLines(olvas);
            string[] ertekek;
            for (int i = 0; i < sorok.Length; i++)
            {
                ertekek = sorok[i].ToString().Split(',');
                string[] row = new string[ertekek.Length];

                for (int j = 0; j < ertekek.Length; j++)
                {
                    row[j] = ertekek[j].Trim();
                }
                ugyfeltabla.Rows.Add(row);
                ertekek.DefaultIfEmpty();
            }
            sorok.DefaultIfEmpty();
        }
        private void VisszaModosit()
        {
            List<string> visszamod = new List<string>();
            for (int i = 1; i < ugyfeltabla.Columns.Count; i++)
            {
                visszamod.Add(dataGridView1.SelectedRows[0].Cells[i].Value.ToString());
            }

            MySqlConnection kapcsolat = new MySqlConnection("Server=localhost;User ID=root;Database=vizsga");
            kapcsolat.Open();
            MySqlCommand modosit = new MySqlCommand("UPDATE ugyfel SET ugyfelazo=@ugyfelazo, nev=@nev, iranyitoszam=@iranyitoszam, orszag=@orszag, telepules=@telepules, cim=@cim, email=@email, telefon=@telefon WHERE ugyfelazo=@ugyfelazo", kapcsolat);
            modosit.Parameters.AddWithValue("@ugyfelazo", int.Parse(visszamod[0]));
            modosit.Parameters.AddWithValue("@nev", visszamod[1]);
            modosit.Parameters.AddWithValue("@iranyitoszam", int.Parse(visszamod[3]));
            modosit.Parameters.AddWithValue("@orszag", visszamod[2]);
            modosit.Parameters.AddWithValue("@telepules", visszamod[4]);
            modosit.Parameters.AddWithValue("@cim", visszamod[5]);
            modosit.Parameters.AddWithValue("@email", visszamod[6]);
            modosit.Parameters.AddWithValue("@telefon", visszamod[7]);
            modosit.ExecuteNonQuery();
            kapcsolat.Close();
            MessageBox.Show("Kijelölt ügyfél módosításának visszaállítása megtörtént!");
            visszamod.Clear();
        }
        private void VisszaTorol()
        {
            List<string> visszator = new List<string>();
            for (int i = 2; i < ugyfeltabla.Columns.Count; i++)
            {
                visszator.Add(dataGridView1.SelectedRows[0].Cells[i].Value.ToString());
            }
            MySqlConnection kapcsolat = new MySqlConnection("Server=localhost;User ID=root;Database=vizsga");
            kapcsolat.Open();
            MySqlCommand felvetel = new MySqlCommand("INSERT INTO ugyfel(nev, iranyitoszam, orszag, telepules, cim, email, telefon) VALUES(@nev, @iranyitoszam, @orszag, @telepules, @cim, @email, @telefon)", kapcsolat);
            felvetel.Parameters.AddWithValue("@nev", visszator[0]);
            felvetel.Parameters.AddWithValue("@iranyitoszam", int.Parse(visszator[2]));
            felvetel.Parameters.AddWithValue("@orszag", visszator[1]);
            felvetel.Parameters.AddWithValue("@telepules", visszator[3]);
            felvetel.Parameters.AddWithValue("@cim", visszator[4]);
            felvetel.Parameters.AddWithValue("@email", visszator[5]);
            felvetel.Parameters.AddWithValue("@telefon", visszator[6]);
            felvetel.ExecuteNonQuery();
            kapcsolat.Close();
            MessageBox.Show("Törölt ügyfél visszaállítása megtörtént!");
            visszator.Clear();
        }
        public Ugyfelek()
        {
            InitializeComponent();
        }

        private void Ugyfelek_Load(object sender, EventArgs e)
        {
            ElsoBetolt();
        }
        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox8.Items.Clear();
                    Clear();
                    if (comboBox7.Text == "Új ügyfél felvétele")
                    {
                        comboBox8.Enabled = false;
                    }
                    if (comboBox7.Text == "Ügyfél adatainak módosítása" || comboBox7.Text == "Ügyfél törlése")
                    {
                        comboBox8.Enabled = true;
                        AzoBetolt();
                    }

        }
        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox7.Text == "Ügyfél adatainak módosítása" || comboBox7.Text == "Ügyfél törlése")
            {
                MezoKitolt();

                felvesz.Add(DateTime.Now.ToString());
                felvesz.Add(comboBox8.Text);
                felvesz.Add(textBox2.Text);
                felvesz.Add(textBox5.Text);
                felvesz.Add(textBox4.Text);
                felvesz.Add(textBox1.Text);
                felvesz.Add(textBox3.Text);
                felvesz.Add(textBox8.Text);
                felvesz.Add(textBox6.Text);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox7.Text == "Új ügyfél felvétele")
            {
                DialogResult felv = MessageBox.Show("Valóban hozzá szeretné adni az ügyfelet az adatbázishoz?", "Insert", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (felv == DialogResult.Yes)
                {
                  
                        felvesz.Add(DateTime.Now.ToString());
                        felvesz.Add(comboBox8.Text);
                        felvesz.Add(textBox2.Text);
                        felvesz.Add(textBox5.Text);
                        felvesz.Add(textBox4.Text);
                        felvesz.Add(textBox1.Text);
                        felvesz.Add(textBox3.Text);
                        felvesz.Add(textBox8.Text);
                        felvesz.Add(textBox6.Text);
               
                    FileIr();
                    Felvetel();
                    Clear();
                }
            }
            if (comboBox7.Text == "Ügyfél adatainak módosítása" && comboBox8.Text.Length > 0)
            {
                DialogResult mod = MessageBox.Show("Valóban módosítani szeretné a kijelölt ügyfél adatait?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (mod == DialogResult.Yes)
                {
                    FileIr();
                    Modosit();
                    Clear();
                }
            }
            if (comboBox7.Text == "Ügyfél törlése" && comboBox8.Text.Length > 0)
            {
                DialogResult torl = MessageBox.Show("Valóban törölni szeretné a kijelölt ügyfelet?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (torl == DialogResult.Yes)
                {
                    FileIr();
                    Torles();
                    Clear();
                }
            }
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            { MessageBox.Show("Kérem válasszon a balra található listából!"); }
            else
            {
                ugyfeltabla.Rows.Clear();
                FileOlvas();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Módosított ügyfelek listája") ;
            { 
                VisszaModosit();
                if (comboBox7.Text == "Ügyfél adatainak módosítása" || comboBox7.Text == "Ügyfél törlése") { AzoBetolt(); }
            }
            if (comboBox1.Text == "Törölt ügyfelek listája")
            { 
                VisszaTorol();
                if (comboBox7.Text == "Ügyfél adatainak módosítása" || comboBox7.Text == "Ügyfél törlése") { AzoBetolt(); }
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       
    }
}
