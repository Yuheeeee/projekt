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
    public partial class Autok : Form
    {
        DataTable autotabla = new DataTable();
        private  List<string> felvesz = new List<string>();
        private string ir;
        private string olvas;

        private void ElsoBetolt()
        {
            autotabla.Columns.Add("Dátum", typeof(string));
            autotabla.Columns.Add("Azonosító", typeof(string));
            autotabla.Columns.Add("Márka", typeof(string));
            autotabla.Columns.Add("Tipus", typeof(string));
            autotabla.Columns.Add("Évjárat", typeof(string));
            autotabla.Columns.Add("Ülésszám", typeof(string));
            autotabla.Columns.Add("Váltó", typeof(string));
            autotabla.Columns.Add("Üzemanyag", typeof(string));
            autotabla.Columns.Add("Rendszám", typeof(string));
            autotabla.Columns.Add("Árkategória", typeof(string));
            autotabla.Columns.Add("Csomagtartó", typeof(string));
            autotabla.Columns.Add("GPS", typeof(string));
            autotabla.Columns.Add("Ajtószám", typeof(string));
            autotabla.Columns.Add("URL", typeof(string));

            dataGridView1.DataSource = autotabla;

        }
        private void Clear()
        {
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;
            comboBox5.SelectedIndex = -1;
            comboBox8.Text = string.Empty;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox8.Clear();
            textBox10.Clear();
        }             
        private void AzoBetolt()
        {
                MySqlConnection kapcsolat = new MySqlConnection("Server=localhost;User ID=root;Database=vizsga");
                kapcsolat.Open();
                MySqlCommand azonosito = new MySqlCommand("Select azo FROM auto", kapcsolat);
                MySqlDataReader mrd = azonosito.ExecuteReader();

                while (mrd.Read())
                {
                    comboBox8.Items.Add(mrd["azo"].ToString());
                }
                kapcsolat.Close();
        }
        private void MezoKitolt()
        {
            MySqlConnection kapcsolat = new MySqlConnection("Server=localhost;User ID=root;Database=vizsga");
            kapcsolat.Open();
            MySqlCommand azonosito = new MySqlCommand("SELECT azo, marka, tipus, evjarat, ulesszam, valto, uzemanyag, rendszam, arkategoria, csomagtarto, gps, ajtoszam, url FROM auto WHERE azo=@azo", kapcsolat);
            azonosito.Parameters.AddWithValue("@azo", int.Parse(comboBox8.Text));
            MySqlDataReader mrd = azonosito.ExecuteReader();

            while (mrd.Read())
            {
                textBox1.Text = mrd.GetValue(12).ToString();
                textBox2.Text = mrd.GetValue(1).ToString();
                textBox3.Text = mrd.GetValue(2).ToString();
                textBox4.Text = mrd.GetValue(3).ToString();
                textBox5.Text = mrd.GetValue(4).ToString();
                textBox8.Text = mrd.GetValue(7).ToString();               
                textBox10.Text = mrd.GetValue(9).ToString();
                comboBox1.Text = mrd.GetValue(5).ToString();
                comboBox2.Text = mrd.GetValue(6).ToString();
                comboBox3.Text = mrd.GetValue(8).ToString();
                comboBox4.Text = mrd.GetValue(10).ToString();
                comboBox5.Text = mrd.GetValue(11).ToString();
                
            }
            
            kapcsolat.Close();
        }
        private void Felvetel()
        {
            MySqlConnection kapcsolat = new MySqlConnection("Server=localhost;User ID=root;Database=vizsga");
            kapcsolat.Open();
            MySqlCommand felvitel = new MySqlCommand("INSERT INTO auto(marka, tipus, evjarat, ulesszam, valto, uzemanyag, rendszam, arkategoria, csomagtarto, gps, ajtoszam, url) VALUES(@marka, @tipus, @evjarat, @ulesszam, @valto, @uzemanyag, @rendszam, @arkategoria, @csomagtarto, @gps, @ajtoszam, @url)", kapcsolat);           
            felvitel.Parameters.AddWithValue("@marka", textBox2.Text);
            felvitel.Parameters.AddWithValue("@tipus", textBox3.Text);
            felvitel.Parameters.AddWithValue("@evjarat", int.Parse(textBox4.Text));
            felvitel.Parameters.AddWithValue("@ulesszam", int.Parse(textBox5.Text));
            felvitel.Parameters.AddWithValue("@valto", comboBox1.Text);
            felvitel.Parameters.AddWithValue("@uzemanyag", comboBox2.Text);
            felvitel.Parameters.AddWithValue("@rendszam", textBox8.Text);
            felvitel.Parameters.AddWithValue("@arkategoria", comboBox3.Text);
            felvitel.Parameters.AddWithValue("@csomagtarto", int.Parse(textBox10.Text));
            felvitel.Parameters.AddWithValue("@gps", comboBox4.Text);
            felvitel.Parameters.AddWithValue("@ajtoszam", int.Parse(comboBox5.Text));
            felvitel.Parameters.AddWithValue("@url", textBox1.Text);
            felvitel.ExecuteNonQuery();
            kapcsolat.Close();
            MessageBox.Show("Új autó felvétele megtörtént!");

        }
        private void Modosit()
        {
            MySqlConnection kapcsolat = new MySqlConnection("Server=localhost;User ID=root;Database=vizsga");
            kapcsolat.Open();
            MySqlCommand modosito = new MySqlCommand("UPDATE auto set marka=@marka, tipus=@tipus, evjarat=@evjarat, ulesszam=@ulesszam, valto=@valto, uzemanyag=@uzemanyag, rendszam=@rendszam, arkategoria=@arkategoria, csomagtarto=@csomagtarto, gps=@gps, ajtoszam=@ajtoszam, url=@url WHERE azo=@azo", kapcsolat);
            modosito.Parameters.AddWithValue("@azo", int.Parse(comboBox8.Text));
            modosito.Parameters.AddWithValue("@marka", textBox2.Text);
            modosito.Parameters.AddWithValue("@tipus", textBox3.Text);
            modosito.Parameters.AddWithValue("@evjarat", int.Parse(textBox4.Text));
            modosito.Parameters.AddWithValue("@ulesszam", int.Parse(textBox5.Text));
            modosito.Parameters.AddWithValue("@valto", comboBox1.Text);
            modosito.Parameters.AddWithValue("@uzemanyag", comboBox2.Text);
            modosito.Parameters.AddWithValue("@rendszam", textBox8.Text);
            modosito.Parameters.AddWithValue("@arkategoria", comboBox3.Text);
            modosito.Parameters.AddWithValue("@csomagtarto", int.Parse(textBox10.Text));
            modosito.Parameters.AddWithValue("@gps", comboBox4.Text);
            modosito.Parameters.AddWithValue("@ajtoszam", int.Parse(comboBox5.Text));
            modosito.Parameters.AddWithValue("@url", textBox1.Text);
            modosito.ExecuteNonQuery();
            kapcsolat.Close();
            MessageBox.Show("Kijelölt autó módosítása megtörtént!");
        }    
        private void Torles()
        {
            MySqlConnection kapcsolat = new MySqlConnection("Server=localhost;User ID=root;Database=vizsga");
            kapcsolat.Open();
            MySqlCommand torol = new MySqlCommand("DELETE FROM auto WHERE azo=@azo", kapcsolat);
            torol.Parameters.AddWithValue("@azo", int.Parse(comboBox8.Text));
            torol.ExecuteNonQuery();
   
            kapcsolat.Close();
            MessageBox.Show("Kijelölt autó törlése megtörtént megtörtént!");
        }
        private void FelveszAdd()
        {
            felvesz.Add(DateTime.Now.ToString());
            felvesz.Add(comboBox8.Text);
            felvesz.Add(textBox2.Text);
            felvesz.Add(textBox3.Text);
            felvesz.Add(textBox4.Text);
            felvesz.Add(textBox5.Text);
            felvesz.Add(comboBox1.Text);
            felvesz.Add(comboBox2.Text);
            felvesz.Add(textBox8.Text);
            felvesz.Add(comboBox3.Text);
            felvesz.Add(textBox10.Text);
            felvesz.Add(comboBox4.Text);
            felvesz.Add(comboBox5.Text);
            felvesz.Add(textBox1.Text);
        }
        private void FileIr()
        {
           

            if (comboBox7.Text == "Új autó felvétele") { ir = "autofelvett.txt"; }
            if (comboBox7.Text == "Autó módosítása") { ir= "automodosit.txt"; }           
            if (comboBox7.Text == "Autó törlése") { ir= "autotorolt.txt"; }
         
            StreamWriter iras = File.AppendText(ir);
            for (int i = 0; i < felvesz.Count-1; i++)
            {
                iras.Write(felvesz[i] + ",");
            }
            iras.Write(felvesz[felvesz.Count-1]);
            iras.Write("\n");
            iras.Close();
            felvesz.Clear();

        }
        private void FileOlvas()
        {            
            if (comboBox6.Text == "Felvitt autók listája") { olvas = "autofelvett.txt"; }
            if (comboBox6.Text == "Módosított autók listája") { olvas = "automodosit.txt"; }
            if (comboBox6.Text == "Törölt autók listája") { olvas = "autotorolt.txt"; }

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

                autotabla.Rows.Add(row);
            }
            sorok.DefaultIfEmpty();
            
        }
        private void VisszaModosit()
        {
            List<string> visszamod = new List<string>();
            for (int i = 1; i < autotabla.Columns.Count; i++)
            {
                visszamod.Add(dataGridView1.SelectedRows[0].Cells[i].Value.ToString());
            }

            MySqlConnection kapcsolat = new MySqlConnection("Server=localhost;User ID=root;Database=vizsga");
            kapcsolat.Open();
            MySqlCommand modosit = new MySqlCommand("UPDATE auto set marka=@marka, tipus=@tipus, evjarat=@evjarat, ulesszam=@ulesszam, valto=@valto, uzemanyag=@uzemanyag, rendszam=@rendszam, arkategoria=@arkategoria, csomagtarto=@csomagtarto, gps=@gps, ajtoszam=@ajtoszam, url=@url WHERE azo=@azo", kapcsolat);
            modosit.Parameters.AddWithValue("@azo", int.Parse(visszamod[0]));
            modosit.Parameters.AddWithValue("@marka", visszamod[1]);
            modosit.Parameters.AddWithValue("@tipus", visszamod[2]);
            modosit.Parameters.AddWithValue("@evjarat", int.Parse(visszamod[3]));
            modosit.Parameters.AddWithValue("@ulesszam", int.Parse(visszamod[4]));
            modosit.Parameters.AddWithValue("@valto", visszamod[5]);
            modosit.Parameters.AddWithValue("@uzemanyag", visszamod[6]);
            modosit.Parameters.AddWithValue("@rendszam", visszamod[7]);
            modosit.Parameters.AddWithValue("@arkategoria", visszamod[8]);
            modosit.Parameters.AddWithValue("@csomagtarto", int.Parse(visszamod[9]));
            modosit.Parameters.AddWithValue("@gps", visszamod[10]);
            modosit.Parameters.AddWithValue("@ajtoszam", int.Parse(visszamod[11]));
            modosit.Parameters.AddWithValue("@url", visszamod[12]);
            modosit.ExecuteNonQuery();
            kapcsolat.Close();
            MessageBox.Show("Kijelölt autó módosításának visszaállítása megtörtént!");
            visszamod.Clear();
        }
        private void VisszaTorol()
        {
            List<string> visszatorol = new List<string>();
            for (int i = 2; i < autotabla.Columns.Count; i++)
            {
                visszatorol.Add(dataGridView1.SelectedRows[0].Cells[i].Value.ToString());
            }
            MySqlConnection kapcsolat = new MySqlConnection("Server=localhost;User ID=root;Database=vizsga");
            kapcsolat.Open();
            MySqlCommand felvitel = new MySqlCommand("INSERT INTO auto(marka, tipus, evjarat, ulesszam, valto, uzemanyag, rendszam, arkategoria, csomagtarto, gps, ajtoszam, url) VALUES(@marka, @tipus, @evjarat, @ulesszam, @valto, @uzemanyag, @rendszam, @arkategoria, @csomagtarto, @gps, @ajtoszam, @url)", kapcsolat);
            felvitel.Parameters.AddWithValue("@marka", visszatorol[0]);
            felvitel.Parameters.AddWithValue("@tipus", visszatorol[1]);
            felvitel.Parameters.AddWithValue("@evjarat", int.Parse(visszatorol[2]));
            felvitel.Parameters.AddWithValue("@ulesszam", int.Parse(visszatorol[3]));
            felvitel.Parameters.AddWithValue("@valto", visszatorol[4]);
            felvitel.Parameters.AddWithValue("@uzemanyag", visszatorol[5]);
            felvitel.Parameters.AddWithValue("@rendszam", visszatorol[6]);
            felvitel.Parameters.AddWithValue("@arkategoria", visszatorol[7]);
            felvitel.Parameters.AddWithValue("@csomagtarto", int.Parse(visszatorol[8]));
            felvitel.Parameters.AddWithValue("@gps", visszatorol[9]);
            felvitel.Parameters.AddWithValue("@ajtoszam", int.Parse(visszatorol[10]));
            felvitel.Parameters.AddWithValue("@url", visszatorol[11]);
            felvitel.ExecuteNonQuery();
            kapcsolat.Close();
            MessageBox.Show("Törölt autó visszaállítása megtörtént!");
            visszatorol.Clear();
        }
            
        public Autok()
        {
            InitializeComponent();
        }
        private void Autok_Load(object sender, EventArgs e)
        {
            ElsoBetolt();
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox8.Items.Clear();
            Clear();
            if (comboBox7.Text == "Új autó felvétele")
            {              
                comboBox8.Enabled = false;
            }
            if (comboBox7.Text == "Autó módosítása" || comboBox7.Text == "Autó törlése")
            {
                comboBox8.Enabled = true;
                AzoBetolt();
            }      
        }
        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox7.Text == "Autó módosítása" || comboBox7.Text == "Autó törlése")
            {
                MezoKitolt();
                FelveszAdd();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox7.Text == "Új autó felvétele")
            {
                DialogResult felv = MessageBox.Show("Valóban hozzá szeretné adni az autót az adatbázishoz?", "Insert", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (felv == DialogResult.Yes)
                {
                    FelveszAdd();
                    FileIr();
                    Felvetel();
                    Clear();
                }
            }
            if (comboBox7.Text == "Autó módosítása" && comboBox8.Text.Length>0)
            {
                DialogResult mod = MessageBox.Show("Valóban módosítani szeretné a kijelölt autó adatait?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (mod == DialogResult.Yes)
                {
                    FileIr();
                    Modosit();
                    Clear();
                }
            }
            if(comboBox7.Text == "Autó törlése" && comboBox8.Text.Length > 0)
            {
                DialogResult torl = MessageBox.Show("Valóban törölni szeretné a kijelölt autót?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
            if (comboBox6.Text == "")
            { MessageBox.Show("Kérem válasszon a balra található listából!"); }
            else
            {
                autotabla.Rows.Clear();
                FileOlvas();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox6.Text == "Módosított autók listája") ;
            { 
                VisszaModosit();
                if (comboBox7.Text == "Autó módosítása" || comboBox7.Text == "Autó törlése") { AzoBetolt(); }
            }
            if (comboBox6.Text == "Törölt autók listája")
            { 
                VisszaTorol();
                if (comboBox7.Text == "Autó módosítása" || comboBox7.Text == "Autó törlése") { AzoBetolt(); }
            }                     
        }


        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

     
    }
}
